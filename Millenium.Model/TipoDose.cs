using System;

namespace Millenium_Model
{
    public class TipoDose : ClassePai
    {
        public int IdTipoDose { get; set; }
        public string Descricao { get; set; }
        public int Contador { get; set; }
        public int IdMaquina { get; set; }
        public int ContadorAntigo { get; set; }
        public int QuantidadeDoseTeste { get; set; }
    }
}
