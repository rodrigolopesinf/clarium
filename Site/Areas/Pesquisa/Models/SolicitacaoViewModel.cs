using Millenium.Domain.Entity;
using Site.Areas.Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Site.Areas.Pesquisa.Models
{
    public class SolicitacaoViewModel
    {
        public SolicitacaoViewModel()
        {
            TipoSolicitacao = new TipoSolicitacao();
            Cliente = new Cliente();
            ListaSolicitacoes = new List<SolicitacaoViewModel>();
            ListaClienteSolicitacao = new List<SelectListItem>();
            ListaTipoSolicitacao = new List<SelectListItem>();
            EnderecoViewModel = new EnderecoViewModel();
        }

        public string Nome { get; set; }

        public string NumeroSequencial { get; set; }

        public string Status { get; set; }

        public int Sequencia { get; set; }

        public int Ano { get; set; }

        public DateTime DataNascimento { get; set; }
        public string DataNascimentoView
        {
            get
            {
                if (DataNascimento.Year > 1)
                {
                    return DataNascimento.ToString("dd/MM/yyyy");

                }
                return string.Empty;
            }
            set
            {
                if (value != null)
                {
                    DataNascimento = Convert.ToDateTime(value);
                }
            }
        }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Pai { get; set; }

        public string Local { get; set; }

        public string Resposta { get; set; }

        public string Mae { get; set; }

        public int IdNivelUsuario { get; set; }

        public int IdSolicitacao { get; set; }
        public string IdSolicitacaoView
        {
            get
            {
                return IdSolicitacao != 0 ? IdSolicitacao.ToString(CultureInfo.InvariantCulture) : "";
            }
        }

        public List<SolicitacaoViewModel> ListaSolicitacoes { get; set; }

        public TipoSolicitacao TipoSolicitacao { get; set; }

        public Cliente Cliente { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }

        public List<SelectListItem> ListaClienteSolicitacao { get; set; }
        public int IdClienteSolicitacao { get; set; }
        public string NomeClienteSolicitacao { get; set; }

        public List<SelectListItem> ListaTipoSolicitacao { get; set; }
        public int IdTipoSolicitacao { get; set; }
        public string DescricaoTipoSolicitacao { get; set; }

        public DateTime DataHoraCriacao { get; set; }

        public int IdUsuarioCriacao { get; set; }
    }
}