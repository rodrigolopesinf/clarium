using Millenium.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace Site.Areas.Cadastro.Models
{
    public class UsuarioViewModel
    {
        //Inicializa a Lista de Usuários para exibir no Grid
        public UsuarioViewModel()
        {
            ListaUsuarios = new List<UsuarioViewModel>();
            ListaNivel = new List<SelectListItem>();
            ListaCliente = new List<SelectListItem>();
            Nivel = new Nivel();
            Cliente = new Cliente();
        }

        public Nivel Nivel { get; set; }
        public Cliente Cliente { get; set; }

        public int IdUsuario { get; set; }

        public string IdUsuarioView
        {
            get
            {
                return IdUsuario != 0 ? IdUsuario.ToString(CultureInfo.InvariantCulture) : "";
            }
        }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "* As senhas não conferem.")]
        public string ConfirmarSenha { get; set; }

        public bool Ativo { get; set; }
        public string AtivoGrid
        {
            get
            {
                return Ativo ? "Sim" : "Não";
            }
        }

        public DateTime? ValidadeSenha { get; set; }
        public string ValidadeSenhaView
        {
            get
            {
                if (ValidadeSenha != null)
                {
                    return ValidadeSenha.Value.Year != 1901 ? ValidadeSenha.Value.ToString("dd/MM/yyyy") : "";

                }
                return string.Empty;
            }
            set
            {
                if (value != null)
                {
                    ValidadeSenha = Convert.ToDateTime(value);
                }
            }
        }

        public List<UsuarioViewModel> ListaUsuarios { get; set; }
        
        public bool SenhaExpira { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataAdmissao { get; set; }
        public string DataAdmissaoString
        {
            get { return DataAdmissao != null ? DataAdmissao.ToString().Substring(0, 10) : ""; }
            set
            {
                if (value != null)
                {
                    DataAdmissao = Convert.ToDateTime(value);
                }
            }
        }

        public string Celular { get; set; }

        public List<SelectListItem> ListaNivel { get; set; }
        public int IdNivel { get; set; }
        public string DescricaoNivel { get; set; }

        public List<SelectListItem> ListaCliente { get; set; }
        public int IdCliente { get; set; }
        public string DescricaoCliente { get; set; }
    }
}