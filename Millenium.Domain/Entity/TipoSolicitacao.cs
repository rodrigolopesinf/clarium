namespace Millenium.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoSolicitacao")]
    public partial class TipoSolicitacao
    {
        [Key]
        public int IdTipoSolicitacao { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public int? IdUsuarioExclusao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataHoraCriacao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataHoraAlteracao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataHoraExclusao { get; set; }

        public bool? Ativo { get; set; }

        public bool? Excluido { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual Usuario Usuario2 { get; set; }
    }
}
