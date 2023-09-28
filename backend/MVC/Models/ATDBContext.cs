using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC.Models
{
    public partial class ATDBContext : DbContext
    {
        public ATDBContext()
        {
        }

        public ATDBContext(DbContextOptions<ATDBContext> options)
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
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ATDB;User ID=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Cpf })
                    .HasName("cluente_pkey");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.Cpf, "UNIQUE_CLIENTE_CPF")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UNIQUE_CLIENTE_EMAIL")
                    .IsUnique();

                entity.HasIndex(e => e.EnderecoId, "UNIQUE_CLIENTE_ENDERECO")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('cluente_id_seq'::regclass)");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");

                entity.Property(e => e.IndicadorDivida).HasColumnName("indicador_divida");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .HasColumnName("nome");

                entity.Property(e => e.Sexo)
                    .HasColumnType("char")
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(13)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.Endereco)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.EnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTE_ENDERECO");
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

                entity.Property(e => e.DataEmprestimo).HasColumnName("data_emprestimo");

                entity.Property(e => e.DataRetorno).HasColumnName("data_retorno");

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
                    .HasConstraintName("FK_EMPRESTIMO_CLIENTE");

                entity.HasOne(d => d.FerramentaCodigoNavigation)
                    .WithMany(p => p.Emprestimos)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.FerramentaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPRESTIMO_FERRAMENTA");
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
                    .HasMaxLength(30)
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

                entity.HasIndex(e => e.Codigo, "UNIQUE_FERRAMENTA_CODIGO")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(255)
                    .HasColumnName("codigo");

                entity.Property(e => e.CadastradoPor)
                    .HasMaxLength(11)
                    .HasColumnName("cadastrado_por");

                entity.Property(e => e.Descricao).HasColumnName("descricao");

                entity.Property(e => e.Marca)
                    .HasMaxLength(30)
                    .HasColumnName("marca");

                entity.Property(e => e.SituacaoId).HasColumnName("situacao_id");

                entity.Property(e => e.TipoId).HasColumnName("tipo_id");

                entity.Property(e => e.ValorCompra)
                    .HasPrecision(10, 2)
                    .HasColumnName("valor_compra");

                entity.Property(e => e.ValorDiaria)
                    .HasPrecision(10, 2)
                    .HasColumnName("valor_diaria");

                entity.HasOne(d => d.Situacao)
                    .WithMany(p => p.Ferramenta)
                    .HasForeignKey(d => d.SituacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FERRAMENTA_SITUACAO");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Ferramenta)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FERRAMENTA_TIPO");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Funcional, e.Cpf })
                    .HasName("funcionario_pkey");

                entity.ToTable("funcionario");

                entity.HasIndex(e => e.EnderecoId, "UNIQUE_ENDERECO_FUNCIONARIO")
                    .IsUnique();

                entity.HasIndex(e => e.Funcional, "UNIQUE_FUNCIONARIO_FUNCIONAL")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Funcional)
                    .HasMaxLength(9)
                    .HasColumnName("funcional");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataAdmissao).HasColumnName("data_admissao");

                entity.Property(e => e.DataDemissao).HasColumnName("data_demissao");

                entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");

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
                    .HasColumnType("char")
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(13)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.Endereco)
                    .WithOne(p => p.Funcionario)
                    .HasForeignKey<Funcionario>(d => d.EnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FUNCIONARIO_ENDERECO");

                entity.HasOne(d => d.Papel)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.PapelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FUNCIONARIO_PAPEL");

                entity.HasOne(d => d.Permissao)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.PermissaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FUNCIONARIO_PERMISSAO");
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
                    .HasConstraintName("FK_ORCAMENTO_CLIENTE");

                entity.HasOne(d => d.FerramentaCodigoNavigation)
                    .WithMany(p => p.Orcamentos)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.FerramentaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORCAMENTO_FERRAMENTA");
            });

            modelBuilder.Entity<Processo>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Funcionario, e.CodigoFerramenta })
                    .HasName("processo_pkey");

                entity.ToTable("processo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Funcionario)
                    .HasMaxLength(11)
                    .HasColumnName("funcionario");

                entity.Property(e => e.CodigoFerramenta)
                    .HasMaxLength(255)
                    .HasColumnName("codigo_ferramenta");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Parecer).HasColumnName("parecer");

                entity.Property(e => e.TipoProcesso).HasColumnName("tipo_processo");

                entity.HasOne(d => d.CodigoFerramentaNavigation)
                    .WithMany(p => p.Processos)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.CodigoFerramenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROCESSO_FERRAMENTA");

                entity.HasOne(d => d.FuncionarioNavigation)
                    .WithMany(p => p.Processos)
                    .HasPrincipalKey(p => p.Funcional)
                    .HasForeignKey(d => d.Funcionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROCESSO_FUNCIONARIO");

                entity.HasOne(d => d.TipoProcessoNavigation)
                    .WithMany(p => p.Processos)
                    .HasForeignKey(d => d.TipoProcesso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROCESSO_TIPO");
            });

            modelBuilder.Entity<TipoFerramentum>(entity =>
            {
                entity.ToTable("tipo_ferramenta");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoPapel>(entity =>
            {
                entity.ToTable("tipo_papel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoPermissao>(entity =>
            {
                entity.ToTable("tipo_permissao");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoProcesso>(entity =>
            {
                entity.ToTable("tipo_processo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoSituacao>(entity =>
            {
                entity.ToTable("tipo_situacao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
