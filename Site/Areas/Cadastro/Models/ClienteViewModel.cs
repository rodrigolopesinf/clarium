using Millenium.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Site.Areas.Cadastro.Models
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ListaClientes = new List<ClienteViewModel>();
            TipoCliente = new TipoCliente();
            SituacaoCliente = new SituacaoCliente();

            ListaTipoCliente = new List<SelectListItem>();
            ListaSituacaoCliente = new List<SelectListItem>();
            ListaTipoSolicitacao = new List<SelectListItem>();

            ContatoViewModel = new ContatoViewModel();
            EnderecoViewModel = new EnderecoViewModel();
            TipoSolicitacaoViewModel = new TipoSolicitacaoViewModel();
        }

        public TipoCliente TipoCliente { get; set; }
        public SituacaoCliente SituacaoCliente { get; set; }
        
        public ContatoViewModel ContatoViewModel { get; set; }
        public EnderecoViewModel EnderecoViewModel { get; set; }
        public TipoSolicitacaoViewModel TipoSolicitacaoViewModel { get; set; }

        public int IdCliente { get; set; }
        public string IdClienteView
        {
            get
            {
                return IdCliente != 0 ? IdCliente.ToString(CultureInfo.InvariantCulture) : "";
            }
        }

        public string CodigoCliente { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string Nome { get; set; }
        
        public string Cpf { get; set; }

        public string Cnpj { get; set; }

        public string EmailPrincipal { get; set; }

        public string TelefonePrincipal { get; set; }

        public string RamalPrincipal { get; set; }

        public string TelefoneSecundario { get; set; }

        public string RamalSecundario { get; set; }

        public bool FaturaEmail { get; set; }

        public string Observacao { get; set; }

        public bool Ativo { get; set; }
        public string AtivoGrid
        {
            get
            {
                return Ativo ? "Sim" : "Não";
            }
        }

        public decimal Preco { get; set; }

        public int? DiaVencimento { get; set; }

        public List<ClienteViewModel> ListaClientes { get; set; }

        public List<SelectListItem> ListaTipoCliente { get; set; }
        public int IdTipoCliente { get; set; }
        public string DescricaoTipoCliente { get; set; }
        
        public List<SelectListItem> ListaSituacaoCliente { get; set; }
        public int IdSituacaoCliente { get; set; }
        public string DescricaoSituacaoCliente { get; set; }

        public List<SelectListItem> ListaTipoSolicitacao { get; set; }
        public int IdTipoSolicitacao { get; set; }
        public string DescricaoTipoSolicitacao{ get; set; }
        
        public string DescricaoSituacaoGrid
        {
            get { return SituacaoCliente.Descricao != "" ? SituacaoCliente.Descricao : string.Empty; }
        }

        public bool? TipoRazao { get; set; }

        public DateTime DataHoraCriacao { get; set; }

        public int IdUsuarioCriacao { get; set; }
    }
}