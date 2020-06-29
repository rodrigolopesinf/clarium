namespace Millenium.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Cliente = new HashSet<Cliente>();
            Cliente1 = new HashSet<Cliente>();
            Cliente2 = new HashSet<Cliente>();
            Contato = new HashSet<Contato>();
            Contato1 = new HashSet<Contato>();
            Contato2 = new HashSet<Contato>();
            Faturamento = new HashSet<Faturamento>();
            Faturamento1 = new HashSet<Faturamento>();
            Faturamento2 = new HashSet<Faturamento>();
            Solicitacao = new HashSet<Solicitacao>();
            Solicitacao1 = new HashSet<Solicitacao>();
            Solicitacao2 = new HashSet<Solicitacao>();
            TipoCliente = new HashSet<TipoCliente>();
            TipoCliente1 = new HashSet<TipoCliente>();
            TipoCliente2 = new HashSet<TipoCliente>();
            TipoSolicitacao = new HashSet<TipoSolicitacao>();
            TipoSolicitacao1 = new HashSet<TipoSolicitacao>();
            TipoSolicitacao2 = new HashSet<TipoSolicitacao>();
        }

        [Key]
        public int IdUsuario { get; set; }

        public int IdNivel { get; set; }

        public int? IdCliente { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Apelido { get; set; }

        [StringLength(15)]
        public string Celular { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        public DateTime? ValidadeSenha { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataAdmissao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataHoraCriacao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataHoraAlteracao { get; set; }

        public DateTime? DataHoraExclusao { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public int? IdUsuarioExclusao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contato> Contato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contato> Contato1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contato> Contato2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faturamento> Faturamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faturamento> Faturamento1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faturamento> Faturamento2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitacao> Solicitacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitacao> Solicitacao1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitacao> Solicitacao2 { get; set; }

        public virtual Nivel Nivel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoCliente> TipoCliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoCliente> TipoCliente1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoCliente> TipoCliente2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoSolicitacao> TipoSolicitacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoSolicitacao> TipoSolicitacao1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoSolicitacao> TipoSolicitacao2 { get; set; }
    }
}
