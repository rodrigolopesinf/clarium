using Millenium.Domain.Entity;
using System.Collections.Generic;
using System.Globalization;

namespace Site.Areas.Cadastro.Models
{
    public class ContatoViewModel
    {
        public ContatoViewModel()
        {
            Contato = new Contato();
        }

        public int IdCliente { get; set; }
        public string IdClienteView
        {
            get
            {
                return IdCliente != 0 ? IdCliente.ToString(CultureInfo.InvariantCulture) : "";
            }
        }

        public Contato Contato { get; set; }
    }
}