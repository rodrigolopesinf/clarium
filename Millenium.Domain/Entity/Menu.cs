namespace Millenium.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMenu { get; set; }

        public int? SecMenu { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [StringLength(50)]
        public string Controller { get; set; }

        public int? MenuPaiId { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        [StringLength(50)]
        public string Route { get; set; }

        [StringLength(50)]
        public string Action { get; set; }
    }
}
