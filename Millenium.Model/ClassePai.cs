using System;

namespace Millenium_Model
{
    public class ClassePai
    {
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
        public DateTime? DataHoraExclusao { get; set; }
        public int IdUsuarioCriacao { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public int? IdUsuarioExclusao { get; set; }
    }
}
