using System;

namespace Millenium_Model
{
    public class Visita : ClassePai
    {
        public Visita ()
        {
            Maquina = new Maquina();
            Patrimonio = new Patrimonio();
            TipoVisita = new TipoVisita();
        }

        public int IdVisita { get; set; }
        public int IdRota { get; set; }
        public int? IdEndereco { get; set; }
        public int IdDia { get; set; }
        public int IdArea { get; set; }
        public int Sequencia { get; set; }
        public int? IdOperador { get; set; }
        public int IdCliente { get; set; }
        public int IdMaquina { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public DateTime? DataHoraLimite { get; set; }
        public Patrimonio Patrimonio { get; set; }
        public Maquina Maquina { get; set; }
        public TipoVisita TipoVisita { get; set; }
        public bool Finalizada { get; set; }
        public string NomeOperador { get; set; }
        public string Competencia { get; set; }
    }
}
