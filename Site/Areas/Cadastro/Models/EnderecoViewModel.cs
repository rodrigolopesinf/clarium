using Millenium.Domain.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Site.Areas.Cadastro.Models
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            Endereco = new Endereco();
            ListaEnderecos = new List<EnderecoViewModel>();
            ListaBairro = new List<SelectListItem>();
        }

        public Endereco Endereco { get; set; }

        public List<EnderecoViewModel> ListaEnderecos { get; set; }
        
        public List<SelectListItem> ListaBairro { get; set; }
        public int IdBairro { get; set; }
        public string DescricaoBairro { get; set; }

        public bool Valida { get; set; }

        public bool Desabilita { get; set; }
    }
}