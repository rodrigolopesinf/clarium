namespace Millenium.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoCliente")]
    public partial class TipoCliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoCliente()
        {
            Cliente = new HashSet<Cliente>();
        }

        [Key]
        public int IdTipoCliente { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual Usuario Usuario2 { get; set; }
    }
}
