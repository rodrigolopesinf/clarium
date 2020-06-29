namespace Millenium.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MenuUsuario")]
    public class MenuUsuario
    {
        public Menu Menu { get; set; }
        public int IdMenu { get; set; }

        public Nivel Nivel { get; set; }
        public int IdNivel { get; set; }
    }
}
