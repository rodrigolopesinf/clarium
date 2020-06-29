namespace Millenium.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FaturadoMes
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCliente { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Mes { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFaturamento { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Faturamento Faturamento { get; set; }
    }
}
