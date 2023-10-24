using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace MVC.Models
{
    public partial class atdbContext : DbContext
    {
        public atdbContext()
        {
        }

        public atdbContext(DbContextOptions<atdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Emprestimo> Emprestimos { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Ferramentum> Ferramenta { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Orcamento> Orcamentos { get; set; } = null!;
        public virtual DbSet<Processo> Processos { get; set; } = null!;
        public virtual DbSet<TipoFerramentum> TipoFerramenta { get; set; } = null!;
        public virtual DbSet<TipoPapel> TipoPapels { get; set; } = null!;
        public virtual DbSet<TipoPermissao> TipoPermissaos { get; set; } = null!;
        public virtual DbSet<TipoProcesso> TipoProcessos { get; set; } = null!;
        public virtual DbSet<TipoSituacao> TipoSituacaos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=atdb-pg.postgres.database.azure.com;Port=5432;Database=atdb;User ID=vitor@atdb-pg;Password=puc123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>(entity =>

            {

                entity.HasKey(e => new { e.Id, e.Cpf })
                     .HasName("cliente_pkey");
                     entity.ToTable("cliente");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Cpf)
                        .HasMaxLength(11)
                        .HasColumnName("cpf");

                entity.Property(e => e.Nome)
                        .HasMaxLength(255)
                        .HasColumnName("nome");

                entity.Property(e => e.Sexo)
                      .HasMaxLength(20)
                      .HasColumnName("sexo");

                entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento")
                       .HasColumnType("timestamp without time zone");

                entity.Property(e => e.Email)
                     .HasMaxLength(255)
                     .HasColumnName("email");

                entity.Property(e => e.Telefone)
                     .HasMaxLength(13)
                     .HasColumnName("telefone");

                entity.Property(e => e.tipoPessoa)
                     .HasMaxLength(255)
                     .HasColumnName("tipo_pessoa");



                entity.Property(e => e.EnderecoId)
                        .HasPrecision(10, 2)
                        .HasColumnName("endereco_id");

                entity.HasOne(d => d.Endereco)
                        .WithMany(p => p.Clientes)
                        .HasPrincipalKey(p => p.Id)
                        .HasForeignKey(d => d.EnderecoId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Cliente_Endereco");




            });
       

            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ClienteCpf, e.FerramentaCodigo })
                    .HasName("emprestimo_pkey");

                entity.ToTable("emprestimo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ClienteCpf)
                    .HasMaxLength(11)
                    .HasColumnName("cliente_cpf");

                entity.Property(e => e.FerramentaCodigo)
                    .HasMaxLength(255)
                    .HasColumnName("ferramenta_codigo");

                entity.Property(e => e.DataDevolucao).HasColumnName("data_devolucao");

                entity.Property(e => e.DataEmprestimo).HasColumnName("data_emprestimo");

                entity.Property(e => e.IndicadorDevolucao)
                    .HasColumnType("char")
                    .HasColumnName("indicador_devolucao");

                entity.Property(e => e.ValorTotal)
                    .HasPrecision(10, 2)
                    .HasColumnName("valor_total");

                entity.HasOne(d => d.ClienteCpfNavigation)
                    .WithMany(p => p.Emprestimos)
                    .HasPrincipalKey(p => p.Cpf)
                    .HasForeignKey(d => d.ClienteCpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emprestimo_Cliente_Cpf");

                entity.HasOne(d => d.FerramentaCodigoNavigation)
                    .WithMany(p => p.Emprestimos)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.FerramentaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emprestimo_Ferramenta_Codigo");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(255)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(255)
                    .HasColumnName("cidade");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .HasColumnName("complemento");

                entity.Property(e => e.Estado)
                    .HasMaxLength(255)
                    .HasColumnName("estado");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(255)
                    .HasColumnName("logradouro");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .HasColumnName("numero");

                entity.Property(e => e.Pais)
                    .HasMaxLength(2)
                    .HasColumnName("pais");
            });

            modelBuilder.Entity<Ferramentum>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Codigo })
                    .HasName("ferramenta_pkey");

                entity.ToTable("ferramenta");

                entity.HasIndex(e => e.Codigo, "UQ_Ferramenta_Codigo")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(255)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao).HasColumnName("descricao");

                entity.Property(e => e.FuncionarioCadastroFuncional)
                    .HasMaxLength(9)
                    .HasColumnName("funcionario_cadastro_funcional");

                entity.Property(e => e.Marca)
                    .HasMaxLength(30)
                    .HasColumnName("marca");

                entity.Property(e => e.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("bigint");

                entity.Property(e => e.SituacaoId).HasColumnName("situacao_id");

                entity.Property(e => e.TipoId).HasColumnName("tipo_id");

                entity.Property(e => e.ValorCompra)
                    .HasPrecision(10, 2)
                    .HasColumnName("valor_compra");

                entity.Property(e => e.ValorDiaria)
                    .HasPrecision(10, 2)
                    .HasColumnName("valor_diaria");

                entity.HasOne(d => d.FuncionarioCadastroFuncionalNavigation)
                    .WithMany(p => p.Ferramenta)
                    .HasPrincipalKey(p => p.Funcional)
                    .HasForeignKey(d => d.FuncionarioCadastroFuncional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Cadastro_Funcional");

                entity.HasOne(d => d.Situacao)
                    .WithMany(p => p.Ferramenta)
                    .HasForeignKey(d => d.SituacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ferramenta_Situacao");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Ferramenta)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ferramenta_Tipo");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Cpf, e.Funcional })
                    .HasName("funcionario_pkey");

                entity.ToTable("funcionario");

                entity.HasIndex(e => e.Email, "UQ_Funcionario_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Funcional, "UQ_Funcionario_Funcional")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Funcional)
                    .HasMaxLength(9)
                    .HasColumnName("funcional");

                entity.Property(e => e.DataAdmissao).HasColumnName("data_admissao")
                          .HasColumnType("timestamp without time zone");
                entity.Property(e => e.DataDemissao).HasColumnName("data_demissao")
                          .HasColumnType("timestamp without time zone");
                entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento")
                         .HasColumnType("timestamp without time zone");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .HasColumnName("nome");

                entity.Property(e => e.PapelId).HasColumnName("papel_id");

                entity.Property(e => e.PermissaoId).HasColumnName("permissao_id");

                entity.Property(e => e.Senha)
                    .HasMaxLength(12)
                    .HasColumnName("senha");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(255)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(13)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.EnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Endereco");

                entity.HasOne(d => d.Papel)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.PapelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Papel");

                entity.HasOne(d => d.Permissao)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.PermissaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Permissao");
            });

            modelBuilder.Entity<Orcamento>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ClienteCpf, e.FerramentaCodigo })
                    .HasName("orcamento_pkey");

                entity.ToTable("orcamento");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ClienteCpf)
                    .HasMaxLength(11)
                    .HasColumnName("cliente_cpf");

                entity.Property(e => e.FerramentaCodigo)
                    .HasMaxLength(255)
                    .HasColumnName("ferramenta_codigo");

                entity.Property(e => e.DataOrcamento).HasColumnName("data_orcamento");

                entity.Property(e => e.DataValidade).HasColumnName("data_validade");

                entity.Property(e => e.ValorTotal)
                    .HasPrecision(10, 2)
                    .HasColumnName("valor_total");

                entity.HasOne(d => d.ClienteCpfNavigation)
                    .WithMany(p => p.Orcamentos)
                    .HasPrincipalKey(p => p.Cpf)
                    .HasForeignKey(d => d.ClienteCpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orcamento_Cliente_Cpf");

                entity.HasOne(d => d.FerramentaCodigoNavigation)
                    .WithMany(p => p.Orcamentos)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.FerramentaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orcamento_Ferramenta_Codigo");
            });

            modelBuilder.Entity<Processo>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.FuncionarioResponsavelFuncional, e.FerramentaCodigo })
                    .HasName("processo_pkey");

                entity.ToTable("processo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.FuncionarioResponsavelFuncional)
                    .HasMaxLength(9)
                    .HasColumnName("funcionario_responsavel_funcional");

                entity.Property(e => e.FerramentaCodigo)
                    .HasMaxLength(255)
                    .HasColumnName("ferramenta_codigo");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Parecer).HasColumnName("parecer");

                entity.Property(e => e.TipoProcessoId).HasColumnName("tipo_processo_id");

                entity.HasOne(d => d.FerramentaCodigoNavigation)
                    .WithMany(p => p.Processos)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.FerramentaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processo_Ferramenta_Codigo");

                entity.HasOne(d => d.FuncionarioResponsavelFuncionalNavigation)
                    .WithMany(p => p.Processos)
                    .HasPrincipalKey(p => p.Funcional)
                    .HasForeignKey(d => d.FuncionarioResponsavelFuncional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processo_Funcionario_Responsavel");

                entity.HasOne(d => d.TipoProcesso)
                    .WithMany(p => p.Processos)
                    .HasForeignKey(d => d.TipoProcessoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processo_Tipo");
            });

            modelBuilder.Entity<TipoFerramentum>(entity =>
            {
                entity.ToTable("tipo_ferramenta");

                entity.HasIndex(e => e.Nome, "UQ_Tipo_Ferramenta_Nome")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoPapel>(entity =>
            {
                entity.ToTable("tipo_papel");

                entity.HasIndex(e => e.Nome, "UQ_Tipo_Papel_Nome")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoPermissao>(entity =>
            {
                entity.ToTable("tipo_permissao");

                entity.HasIndex(e => e.Nome, "UQ_Tipo_Permissao_Nome")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoProcesso>(entity =>
            {
                entity.ToTable("tipo_processo");

                entity.HasIndex(e => e.Nome, "UQ_Tipo_Processo_Nome")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoSituacao>(entity =>
            {
                entity.ToTable("tipo_situacao");

                entity.HasIndex(e => e.Nome, "UQ_Tipo_Situacao_Nome")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void HasColumnType(string v)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
