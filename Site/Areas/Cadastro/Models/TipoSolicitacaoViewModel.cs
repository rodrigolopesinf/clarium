using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Site.Areas.Cadastro.Models
{
    public class TipoSolicitacaoViewModel
    {
        //Inicializa a Lista de Usuários para exibir no Grid
        public TipoSolicitacaoViewModel()
        {
            ListaTipoSolicitacoes = new List<TipoSolicitacaoViewModel>();
            ListaTipoSolicitacao = new List<SelectListItem>();
        }

        public int Id { get; set; }

        public int IdCliente { get; set; }

        public string IdView
        {
            get
            {
                return Id != 0 ? Id.ToString(CultureInfo.InvariantCulture) : "";
            }
        }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public bool Ativo { get; set; }
        public string AtivoGrid
        {
            get
            {
                return Ativo ? "Sim" : "Não";
            }
        }

        public List<TipoSolicitacaoViewModel> ListaTipoSolicitacoes { get; set; }

        public List<SelectListItem> ListaTipoSolicitacao { get; set; }
        public string DescricaoSolicitacao { get; set; }
    }
}