namespace Millenium.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Solicitacao")]
    public partial class Solicitacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitacao()
        {
            Endereco = new Endereco();
            TipoSolicitacao = new TipoSolicitacao();
            Cliente = new Cliente();
        }

        [Key]
        public int IdSolicitacao { get; set; }

        public int? IdCliente { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public int? IdUsuarioExclusao { get; set; }

        public DateTime DataHoraCriacao { get; set; }

        public DateTime? DataHoraAlteracao { get; set; }

        public DateTime? DataHoraExclusao { get; set; }

        public bool? Excluido { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroSequencial { get; set; }

        public int Sequencia { get; set; }

        public int Ano { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(15)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(10)]
        public string Rg { get; set; }

        [Required]
        [StringLength(50)]
        public string NomePai { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeMae { get; set; }

        [Required]
        [StringLength(50)]
        public string Local { get; set; }

        [Required]
        [StringLength(5000)]
        public string Resposta { get; set; }

        public int IdTipoSolicitacao { get; set; }

        public int? IdEndereco { get; set; }

        public virtual Endereco Endereco { get; set; }

        [NotMapped]
        public virtual TipoSolicitacao TipoSolicitacao { get; set; }

        [NotMapped]
        public virtual Cliente Cliente { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual Usuario Usuario2 { get; set; }
    }
}
