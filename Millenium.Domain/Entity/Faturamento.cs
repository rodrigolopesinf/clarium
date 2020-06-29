namespace Millenium.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Faturamento")]
    public partial class Faturamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faturamento()
        {
            FaturadoMes = new HashSet<FaturadoMes>();
        }

        [Key]
        public int IdFaturamento { get; set; }

        public int IdCliente { get; set; }

        public int QuantidadeDosesSimples { get; set; }

        public int QuantidadeDosesDuplas { get; set; }

        public int QuantidadeDosesTeste { get; set; }

        public int QuantidadeDosesCortesia { get; set; }

        public decimal Preco { get; set; }

        public decimal Total { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public int? IdUsuarioExclusao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataHoraCriacao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataHoraAlteracao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataHoraExclusao { get; set; }

        public bool? Excluido { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaturadoMes> FaturadoMes { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual Usuario Usuario2 { get; set; }
    }
}
