using Millenium.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Site.Areas.Faturamento.Models
{
    public class FaturamentoViewModel
    {
        public FaturamentoViewModel()
        {
            Cliente = new Cliente();
            ListaClientes = new List<Cliente>();
            ListaMeses = new List<SelectListItem>();
            ListaFaturamentos = new List<FaturamentoViewModel>();
        }

        public int IdFaturamento { get; set; }
        public double Total { get; set; }

        public Cliente Cliente { get; set; }

        public string NomeCliente { get; set; }
        public string Documento { get; set; }
        public string CodigoCliente { get; set; }
        public string Endereco { get; set; }

        public List<SelectListItem> ListaMeses { get; set; }
        public int IdMes { get; set; }
        public string DescricaoMes { get; set; }

        public bool? TipoFaturamento { get; set; }

        public bool Consolidado { get; set; }

        public List<FaturamentoViewModel> ListaFaturamentos { get; set; }

        public List<Cliente> ListaClientes { get; set; }

        public DateTime DataInicio { get; set; }
        public string DataInicioString
        {
            get
            {
                return DataInicio.Year != 1 ? DataInicio.ToString(CultureInfo.InvariantCulture).Substring(0, 10) : "";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    DataInicio = Convert.ToDateTime(value);
                }
            }
        }

        public double ValorTotal { get; set; }
        public string ValorTotalString
        {
            get
            {
                return Math.Abs(ValorTotal) > 0 ? string.Format("{0:N}", ValorTotal) : "";
            }
        }

        public int QuantidadeDosesSimples { get; set; }
        public int QuantidadeDosesDuplas { get; set; }
        public int QuantidadeDosesTeste { get; set; }
    }
}