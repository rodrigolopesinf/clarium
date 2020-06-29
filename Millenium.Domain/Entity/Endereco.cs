namespace Millenium.Domain.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Endereco")]
    public partial class Endereco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Endereco()
        {
            Cliente = new HashSet<Cliente>();
        }

        [Key]
        public int IdEndereco { get; set; }

        [StringLength(500)]
        public string Logradouro { get; set; }

        [StringLength(20)]
        public string Numero { get; set; }

        [StringLength(50)]
        public string Complemento { get; set; }

        [StringLength(9)]
        public string Cep { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(100)]
        public string Bairro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
