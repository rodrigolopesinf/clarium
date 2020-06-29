using System;
using System.Collections.Generic;

namespace Millenium_Model
{
    public class Faturamento : ClassePai
    {
        public Faturamento()
        {
            Cliente = new Cliente();
            Visita = new Visita();
            ListaMaquinas = new List<Maquina>();
            ListaInsumos = new List<Insumo>();
        }

        public int IdFaturamento { get; set; }
        public double ValorTotal { get; set; }
        public double ValorTotalInsumos { get; set; }
        public double ValorTotalDoses { get; set; }
        public double ValorPendencia { get; set; }

        public string NomeCliente { get; set; }
        public string Documento { get; set; }
        public string CodigoCliente { get; set; }
        public string Endereco { get; set; }

        public Cliente Cliente { get; set; }
        public Visita Visita { get; set; }

        public List<Maquina> ListaMaquinas { get; set; }

        public List<Insumo> ListaInsumos { get; set; }

        public int QuantidadeDosesSimples { get; set; }
        public int QuantidadeDosesDuplas { get; set; }
        public int QuantidadeDosesTeste { get; set; }
        public int QuantidadeDosesAgua { get; set; }
        public int QuantidadeDosesPorta { get; set; }
        public int QuantidadeDosesCortesia { get; set; }

        public bool Consolidado { get; set; }

        public double PrecoDose { get; set; }

        public DateTime Competencia { get; set; }
    }
}
