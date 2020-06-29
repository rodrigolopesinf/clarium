namespace Millenium.Infra.Data.Contexto
{
    using Millenium.Domain.Entity;
    using System;
    using System.Data.Entity;

    public partial class ContextMillenium : DbContext
    {
        public ContextMillenium()
            : base("name=Millenium")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Faturamento> Faturamento { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Nivel> Nivel { get; set; }
        public virtual DbSet<SituacaoCliente> SituacaoCliente { get; set; }
        public virtual DbSet<Solicitacao> Solicitacao { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }
        public virtual DbSet<TipoSolicitacao> TipoSolicitacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<FaturadoMes> FaturadoMes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.CodigoCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.NomeFantasia)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.RazaoSocial)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Cnpj)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.TelefonePrincipal)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.RamalPrincipal)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.TelefoneSecundario)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.RamalSecundario)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.EmailPrincipal)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.FaturadoMes)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Faturamento)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.CelularSecundario)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Site)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cep)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Faturamento>()
                .Property(e => e.Preco)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Faturamento>()
                .Property(e => e.Total)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Faturamento>()
                .HasMany(e => e.FaturadoMes)
                .WithRequired(e => e.Faturamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Route)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<Nivel>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Nivel>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Nivel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuUsuario>()
                .HasKey(mu => new { mu.IdMenu, mu.IdNivel });

            modelBuilder.Entity<SituacaoCliente>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<SituacaoCliente>()
                .HasMany(e => e.Cliente)
                .WithRequired(e => e.SituacaoCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.Cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.Rg)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.NomePai)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.NomeMae)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCliente>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCliente>()
                .HasMany(e => e.Cliente)
                .WithRequired(e => e.TipoCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoSolicitacao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.IdCliente);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apelido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cliente)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuarioAlteracao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cliente1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.IdUsuarioCriacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cliente2)
                .WithOptional(e => e.Usuario2)
                .HasForeignKey(e => e.IdUsuarioExclusao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Contato)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuarioAlteracao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Contato1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.IdUsuarioCriacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Contato2)
                .WithOptional(e => e.Usuario2)
                .HasForeignKey(e => e.IdUsuarioExclusao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Faturamento)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuarioCriacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Faturamento1)
                .WithOptional(e => e.Usuario1)
                .HasForeignKey(e => e.IdUsuarioExclusao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Faturamento2)
                .WithOptional(e => e.Usuario2)
                .HasForeignKey(e => e.IdUsuarioAlteracao);

            modelBuilder.Entity<Usuario>()
               .HasMany(e => e.Solicitacao)
               .WithOptional(e => e.Usuario)
               .HasForeignKey(e => e.IdUsuarioAlteracao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Solicitacao1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.IdUsuarioCriacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Solicitacao2)
                .WithOptional(e => e.Usuario2)
                .HasForeignKey(e => e.IdUsuarioExclusao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.TipoCliente)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuarioAlteracao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.TipoCliente1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.IdUsuarioCriacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.TipoCliente2)
                .WithOptional(e => e.Usuario2)
                .HasForeignKey(e => e.IdUsuarioExclusao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.TipoSolicitacao)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuarioAlteracao);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.TipoSolicitacao1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.IdUsuarioCriacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.TipoSolicitacao2)
                .WithOptional(e => e.Usuario2)
                .HasForeignKey(e => e.IdUsuarioExclusao);

            modelBuilder.Entity<FaturadoMes>()
                .Property(e => e.Mes)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(f => f.DataHoraCriacao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Cliente>()
                .Property(f => f.DataHoraAlteracao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Cliente>()
                .Property(f => f.DataHoraExclusao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Contato>()
                .Property(f => f.DataHoraCriacao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Contato>()
                .Property(f => f.DataHoraAlteracao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Contato>()
                .Property(f => f.DataHoraExclusao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Solicitacao>()
                .Property(f => f.DataHoraCriacao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Solicitacao>()
               .Property(f => f.DataHoraAlteracao)
               .HasColumnType("datetime2");

            modelBuilder.Entity<Solicitacao>()
               .Property(f => f.DataHoraExclusao)
               .HasColumnType("datetime2");

            modelBuilder.Entity<TipoSolicitacao>()
                .Property(f => f.DataHoraCriacao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<TipoSolicitacao>()
               .Property(f => f.DataHoraAlteracao)
               .HasColumnType("datetime2");

            modelBuilder.Entity<TipoSolicitacao>()
               .Property(f => f.DataHoraExclusao)
               .HasColumnType("datetime2");

            modelBuilder.Entity<TipoCliente>()
                .Property(f => f.DataHoraCriacao)
                .HasColumnType("datetime2");

            modelBuilder.Entity<TipoCliente>()
               .Property(f => f.DataHoraAlteracao)
               .HasColumnType("datetime2");

            modelBuilder.Entity<TipoCliente>()
               .Property(f => f.DataHoraExclusao)
               .HasColumnType("datetime2");
        }
    }
}
