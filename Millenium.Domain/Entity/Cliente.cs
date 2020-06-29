namespace Millenium.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {            
            Endereco = new Endereco();
            Contato = new Contato();
        }

        [Key]
        public int IdCliente { get; set; }

        [StringLength(25)]
        public string CodigoCliente { get; set; }

        public int IdTipoCliente { get; set; }

        public int? IdEndereco { get; set; }

        public int? IdContato { get; set; }

        [StringLength(255)]
        public string NomeFantasia { get; set; }

        [StringLength(255)]
        public string RazaoSocial { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(15)]
        public string Cpf { get; set; }

        [StringLength(18)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(15)]
        public string TelefonePrincipal { get; set; }

        [StringLength(5)]
        public string RamalPrincipal { get; set; }

        [StringLength(15)]
        public string TelefoneSecundario { get; set; }

        [StringLength(5)]
        public string RamalSecundario { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailPrincipal { get; set; }

        public bool FaturaEmail { get; set; }

        public int IdSituacaoCliente { get; set; }

        [StringLength(1000)]
        public string Observacao { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public int? IdUsuarioExclusao { get; set; }

        public DateTime DataHoraCriacao { get; set; }

        public DateTime? DataHoraAlteracao { get; set; }

        public DateTime? DataHoraExclusao { get; set; }

        public bool Ativo { get; set; }

        public bool? Excluido { get; set; }

        public int? DiaVencimento { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual Contato Contato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual SituacaoCliente SituacaoCliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual TipoCliente TipoCliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual Usuario Usuario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual Usuario Usuario2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaturadoMes> FaturadoMes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faturamento> Faturamento { get; set; }
    }
}
