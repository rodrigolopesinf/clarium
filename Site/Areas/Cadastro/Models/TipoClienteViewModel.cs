using System.Collections.Generic;
using System.Globalization;

namespace Site.Areas.Cadastro.Models
{
    public class TipoClienteViewModel
    {
        public TipoClienteViewModel()
        {
            ListaTipoClientes = new List<TipoClienteViewModel>();
        }

        public int IdTipoCliente { get; set; }

        public string IdTipoClienteView
        {
            get
            {
                return IdTipoCliente != 0 ? IdTipoCliente.ToString(CultureInfo.InvariantCulture) : "";
            }
        }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        public string AtivoGrid
        {
            get
            {
                return Ativo ? "Sim" : "Não";
            }
        }

        public List<TipoClienteViewModel> ListaTipoClientes { get; set; }
    }
}