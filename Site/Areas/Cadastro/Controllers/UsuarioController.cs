using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Infra.Data.Email;
using Millenium.Util;
using Site.Areas.Administrativa.Models;
using Site.Areas.Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;

using System.Web.UI;
using System.Web.UI.WebControls;
namespace Site.Areas.Cadastro.Controllers
{
    [Authorize(Roles = "SUPER ADMINISTRADOR, GESTOR")]
    public class UsuarioController : Controller
    {
        private const string currentPage = "Index";
        private const string pathPageIndex = "/Cadastro/Usuario/Index";
        private const string pathEdit = "/Cadastro/Usuario/Edit";
        private const string pathDelete = "/Cadastro/Usuario/ExcluirUsuario";
        private const string displaNone = "display:none";
        private const string displayBlock = "display:block";
        private const string sessionName = "UsuarioLogado";
        private const string sessionExportacao = "ListaExportacaoUsuario";
        private const string pathPageDelete = "~/Areas/Administrativa/Views/Home/Excluir.cshtml";
        private const string pathPageSucess = "~/Areas/Administrativa/Views/Home/Sucesso.cshtml";
        private const string operationEdit = "Editar";
        private const string operationAdd = "Salvar";
        private const string operationResetPassword = "ResetPassword";

        private readonly IUsuarioAppService _usuarioApp;
        private readonly INivelAppService _nivelApp;
        private readonly IClienteAppService _clienteApp;

        public UsuarioController(
            IUsuarioAppService usuarioApp,
            INivelAppService nivelApp,
            IClienteAppService clienteApp)
        {
            _usuarioApp = usuarioApp;
            _nivelApp = nivelApp;
            _clienteApp = clienteApp;
        }

        //
        // GET: /Cadastro/Usuario/
        public ActionResult Index()
        {
            var vm = new UsuarioViewModel();
            vm = CarregarDropDownList(vm);
            @ViewBag.MyInitialValue = displaNone;
            Session[sessionExportacao] = new List<UsuarioViewModel>();
            return View(currentPage, vm);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var vm = new UsuarioViewModel { Ativo = true, SenhaExpira = true };
            vm = CarregarDropDownList(vm);
            @ViewBag.ValidadeSenha = displaNone;
            return View("Edit", vm);
        }

        [HttpGet]
        public ActionResult Buscar(UsuarioViewModel vm, string nome, string ativo, string button)
        {
            var usuarios = _usuarioApp.GetAll();

            switch (button)
            {
                case "Buscar":
                    vm = RetornarPesquisaUsuarios(usuarios);
                    vm = CarregarDropDownList(vm);
                    Session[sessionExportacao] = vm.ListaUsuarios;
                    @ViewBag.MyInitialValue = displayBlock;
                    return View(currentPage, vm);
                case "Exportar":
                    var listaExportacao = (List<UsuarioViewModel>)Session[sessionExportacao];
                    ExportarParaExcel(listaExportacao);
                    vm.ListaUsuarios = new List<UsuarioViewModel>();
                    Session[sessionExportacao] = new List<UsuarioViewModel>();
                    @ViewBag.MyInitialValue = displaNone;
                    return View(currentPage, vm);
            }

            return null;
        }

        private UsuarioViewModel RetornarPesquisaUsuarios(IEnumerable<Usuario> usuarios)
        {
            UsuarioViewModel vm;
            ModelState.Clear();
            vm = new UsuarioViewModel();

            foreach (var usuarioVm in usuarios.Select(item => new UsuarioViewModel
            {
                IdUsuario = item.IdUsuario,
                Nome = item.Nome,
                Ativo = item.Ativo
            }))
            {
                vm.ListaUsuarios.Add(usuarioVm);
            }
            return vm;
        }

        [HttpGet]
        public ActionResult RetornarPorId(string id)
        {
            var vm = new UsuarioViewModel();

            var obj = _usuarioApp.GetById(Convert.ToInt32(id));

            if (obj.IdUsuario == 0)
            {
                @ViewBag.MyInitialValue = displaNone;
                vm = CarregarDropDownList(vm);
                return View(currentPage, vm);
            }
            CarregarUsuarioPorId(vm, obj);

            vm = CarregarDropDownList(vm, obj.Nivel.IdNivel, obj.IdCliente);

            return View("Edit", vm);
        }

        private void CarregarUsuarioPorId(UsuarioViewModel vm, Usuario obj)
        {
            var senhaDescriptografada = string.Empty;

            if (obj.Senha != null)
                senhaDescriptografada = Md5Crypt.Descriptografar(obj.Senha);

            vm.IdUsuario = obj.IdUsuario;
            vm.Nome = obj.Nome;
            vm.Apelido = obj.Apelido;
            vm.Celular = obj.Celular;
            vm.DataAdmissao = obj.DataAdmissao;
            vm.Email = obj.Email;
            vm.Senha = senhaDescriptografada;
            vm.ConfirmarSenha = senhaDescriptografada;
            vm.ValidadeSenha = Convert.ToDateTime(obj.ValidadeSenha);
            vm.Login = obj.Login;
            vm.Ativo = obj.Ativo;

            MostrarOcultarValidadeSenha(vm, obj);
        }

        private void MostrarOcultarValidadeSenha(UsuarioViewModel vm, Usuario obj)
        {
            if (obj.ValidadeSenha != null)
            {
                vm.SenhaExpira = true;
                @ViewBag.ValidadeSenha = displayBlock;
            }
            else
            {
                vm.SenhaExpira = false;
                @ViewBag.ValidadeSenha = displaNone;
            }
        }

        [HttpPost]
        public ActionResult SalvarUsuario(UsuarioViewModel vm, string senha, string button)
        {
            var resultado = button == "Resetar Senha" ? operationResetPassword : vm.IdUsuarioView != "" ? operationEdit : operationAdd;

            switch (resultado)
            {
                case operationAdd:
                    ViewBag.Mensagem = Salvar(vm, senha) ? Properties.Resource.Salvar : Properties.Resource.Erro;
                    break;

                case operationEdit:
                    ViewBag.Mensagem = Editar(vm, senha) ? Properties.Resource.Editar : Properties.Resource.Erro;
                    break;

                case operationResetPassword:
                    ViewBag.Mensagem = GerarSenha(vm) ? Properties.Resource.ResetPassword : Properties.Resource.Erro;
                    break;
            }

            ViewBag.ActionVoltar = pathPageIndex;
            ViewBag.NovoRegistro = pathEdit;
            ViewBag.NomeTela = "Usuário";
            ModelState.Clear();

            return View(pathPageSucess);
        }

        #region Métodos

        public bool Salvar(UsuarioViewModel vm, string senha)
        {
            try
            {
                string novaSenha = GerarNovaSenha();
                Usuario obj = UserAdd(vm, novaSenha);
                _usuarioApp.Add(obj);

                new Email(obj, novaSenha);
            }
            catch (Exception ex)
            {
                throw new FormatException(message: ex.Message, innerException: ex);
            }

            return true;
        }

        public bool Editar(UsuarioViewModel vm, string senha)
        {
            try
            {
                Usuario obj = UserUpdate(vm, senha);
                _usuarioApp.Update(obj);
            }
            catch (Exception ex)
            {
                throw new FormatException(message: ex.Message, innerException: ex);
            }

            return true;
        }

        public bool GerarSenha(UsuarioViewModel vm)
        {
            try
            {
                string novaSenha = GerarNovaSenha();
                Usuario obj = UserNewPassword(vm, novaSenha);
                _usuarioApp.Update(obj);

                new Email(obj, novaSenha);
            }
            catch (Exception ex)
            {
                throw new FormatException(message: ex.Message, innerException: ex);
            }

            return true;
        }

        private Usuario UserAdd(UsuarioViewModel vm, string senha)
        {
            var user = new Usuario
            {
                Nome = vm.Nome,
                IdNivel = vm.IdNivel,
                IdCliente = vm.IdCliente,
                Apelido = vm.Apelido,
                Celular = vm.Celular,
                DataAdmissao = vm.DataAdmissao,
                Email = vm.Email,
                Login = vm.Login,
                Senha = Md5Crypt.Criptografar(senha),
                ValidadeSenha = !vm.SenhaExpira ? Convert.ToDateTime(vm.ValidadeSenha) : (DateTime?)null,
                Ativo = vm.Ativo,
                IdUsuarioCriacao = Convert.ToInt32(Session[sessionName]),
                DataHoraCriacao = DateTime.Now
            };

            return user;
        }

        private Usuario UserUpdate(UsuarioViewModel vm, string senha)
        {
            var user = _usuarioApp.GetById(vm.IdUsuario);
            user.IdUsuario = vm.IdUsuario;
            user.Nome = vm.Nome;
            user.IdNivel = vm.IdNivel;
            user.IdCliente = vm.IdCliente;
            user.Apelido = vm.Apelido;
            user.Celular = vm.Celular;
            user.DataAdmissao = vm.DataAdmissao;
            user.Email = vm.Email;
            user.Login = vm.Login;
            user.Senha = Md5Crypt.Criptografar(vm.Senha);
            user.ValidadeSenha = vm.SenhaExpira ? Convert.ToDateTime(vm.ValidadeSenha) : (DateTime?)null;
            user.Ativo = vm.Ativo;            
            user.IdUsuarioAlteracao = Convert.ToInt32(Session[sessionName]);
            user.DataHoraAlteracao = DateTime.Now;
            return user;
        }

        private Usuario UserNewPassword(UsuarioViewModel vm, string senha)
        {
            var user = _usuarioApp.GetById(vm.IdUsuario);
            user.IdUsuario = vm.IdUsuario;
            user.Nome = vm.Nome;
            user.IdNivel = vm.IdNivel;
            user.IdCliente = vm.IdCliente;
            user.Apelido = vm.Apelido;
            user.Celular = vm.Celular;
            user.DataAdmissao = vm.DataAdmissao;
            user.Email = vm.Email;
            user.Login = vm.Login;
            user.Senha = Md5Crypt.Criptografar(senha);
            user.ValidadeSenha = vm.SenhaExpira ? Convert.ToDateTime(vm.ValidadeSenha) : (DateTime?)null;
            user.Ativo = vm.Ativo;
            user.IdUsuarioAlteracao = Convert.ToInt32(Session[sessionName]);
            user.DataHoraAlteracao = DateTime.Now;
            return user;
        }

        private string GerarNovaSenha()
        {
            // Gera uma senha com 6 caracteres entre numeros e letras
            string chars = "abcdefghjkmnpqrstuvwxyz023456789";
            string pass = "";
            Random random = new Random();
            for (int f = 0; f < 6; f++)
            {
                pass = pass + chars.Substring(random.Next(0, chars.Length - 1), 1);
            }

            return pass;
        }

        public void ExportarParaExcel(List<UsuarioViewModel> lista)
        {
            var usuarios = new System.Data.DataTable("dataTableUsuario");
            usuarios.Columns.Add("Nome", typeof(string));
            usuarios.Columns.Add("Ativo", typeof(string));

            foreach (var t in lista)
            {
                usuarios.Rows.Add(t.Nome, t.AtivoGrid);
            }

            var grid = new GridView { DataSource = usuarios };
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ArquivoExcelUsuarios.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public UsuarioViewModel CarregarDropDownList(UsuarioViewModel vm, int idNivel = 0, int? idCliente = 0)
        {
            #region Nível de Usuário

            var lista = _nivelApp.GetAll();

            foreach (var obj in lista)
            {
                vm.IdNivel = obj.IdNivel;
                vm.DescricaoNivel = obj.Descricao;
                vm.ListaNivel.Add(new SelectListItem { Text = vm.DescricaoNivel, Value = vm.IdNivel.ToString(CultureInfo.InvariantCulture) });
            }

            vm.IdNivel = idNivel;

            #endregion

            #region Cliente

            var listaCliente = _clienteApp.GetAll();

            foreach (var obj in listaCliente)
            {
                vm.IdCliente = obj.IdCliente;
                vm.DescricaoCliente = obj.NomeFantasia;
                vm.ListaCliente.Add(new SelectListItem { Text = vm.DescricaoCliente, Value = vm.IdCliente.ToString(CultureInfo.InvariantCulture) });
            }

            vm.IdCliente = idCliente != null ? Convert.ToInt32(idCliente) : 0;

            #endregion

            return vm;
        }

        #endregion

        #region Excluir

        public ActionResult Excluir(ExcluirViewModel vm, string id)
        {
            ViewBag.ActionVoltar = pathPageIndex;
            ViewBag.ActionExcluir = pathDelete;
            ViewBag.NomeTela = "Usuário";
            vm.IdExclusao = Convert.ToInt32(id);

            return View(pathPageDelete, vm);
        }

        [HttpPost]
        public ActionResult ExcluirUsuario(ExcluirViewModel evm, string sim, string nao)
        {
            var vm = new UsuarioViewModel();

            if (sim == null)
            {
                @ViewBag.MyInitialValue = displaNone;
                @ViewBag.MensagemErro = displaNone;
                return View(currentPage, vm);
            }

            _usuarioApp.Remove(_usuarioApp.GetById(evm.IdExclusao));
            @ViewBag.MyInitialValue = displaNone;
            return View(currentPage, vm);
        }

        #endregion

    }
}
