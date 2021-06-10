using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace server.Models
{
    public partial class EmsContext : DbContext
    {
        public EmsContext()
        {
        }

        public EmsContext(DbContextOptions<EmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<DepartamentoFuncionario> DeparFuncs { get; set; }
        public virtual DbSet<DepartamentoGerencia> DeparGerens { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Salarios> Salarios { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Portuguese_Brazil.1252");

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => new { e.FuncionarioNumero, e.Titulo, e.Inicio })
                    .HasName("cargos_pkey");

                entity.ToTable("cargos");

                entity.Property(e => e.FuncionarioNumero).HasColumnName("funcionario_numero");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("titulo");

                entity.Property(e => e.Inicio)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("inicio");

                entity.Property(e => e.Termino)
                    .HasColumnType("date")
                    .HasColumnName("termino");

                entity.HasOne(d => d.FunNumNavigation)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.FuncionarioNumero)
                    .HasConstraintName("cargos_funcionario_numero_fkey");
            });

            modelBuilder.Entity<DepartamentoFuncionario>(entity =>
            {
                entity.HasKey(e => new { e.FuncionarioNumero, e.DepartamentoNumero })
                    .HasName("departamento_funcionario_pkey");

                entity.ToTable("departamento_funcionario");

                entity.HasIndex(e => e.DepartamentoNumero, "departamento_funcionario_departamento_numero_idx");

                entity.Property(e => e.FuncionarioNumero).HasColumnName("funcionario_numero");

                entity.Property(e => e.DepartamentoNumero)
                    .HasMaxLength(4)
                    .HasColumnName("departamento_numero")
                    .IsFixedLength(true);

                entity.Property(e => e.Inicio)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("inicio");

                entity.Property(e => e.Termino)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("termino");

                entity.HasOne(d => d.Departamentos)
                    .WithMany(p => p.DeparFuncs)
                    .HasForeignKey(d => d.DepartamentoNumero)
                    .HasConstraintName("departamento_funcionario_departamento_numero_fkey");

                entity.HasOne(d => d.FunNumNavigation)
                    .WithMany(p => p.DeparFuncs)
                    .HasForeignKey(d => d.FuncionarioNumero)
                    .HasConstraintName("departamento_funcionario_funcionario_numero_fkey");
            });

            modelBuilder.Entity<DepartamentoGerencia>(entity =>
            {
                entity.HasKey(e => new { e.DepartamentoNumero, e.FuncionarioNumero })
                    .HasName("depar_geren_pkey");

                entity.ToTable("departamento_gerencia");

                entity.HasIndex(e => e.DepartamentoNumero, "funcionario_numero_departamento_numero_idx");

                entity.Property(e => e.DepartamentoNumero)
                    .HasMaxLength(4)
                    .HasColumnName("departamento_numero")
                    .IsFixedLength(true);

                entity.Property(e => e.FuncionarioNumero).HasColumnName("funcionario_numero");

                entity.Property(e => e.Inicio)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("inicio");

                entity.Property(e => e.Termino)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("termino");

                entity.HasOne(d => d.DeparNumNavigation)
                    .WithMany(p => p.DeparGerens)
                    .HasForeignKey(d => d.DepartamentoNumero)
                    .HasConstraintName("departamento_gerencia_departamento_numero_fkey");

                entity.HasOne(d => d.FunNumNavigation)
                    .WithMany(p => p.DeparGerens)
                    .HasForeignKey(d => d.FuncionarioNumero)
                    .HasConstraintName("depar_geren_fun_num_fkey");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.DepartamentoNumero)
                    .HasName("departamentos_pkey");

                entity.ToTable("departamentos");

                entity.HasIndex(e => e.DepartamentoNumero, "departamentos_departamento_nome_key")
                    .IsUnique();

                entity.Property(e => e.DepartamentoNumero)
                    .HasMaxLength(4)
                    .HasColumnName("departamento_numero")
                    .IsFixedLength(true);

                entity.Property(e => e.DepartamentoNome)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("departamento_nome");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.FuncionarioNumero)
                    .HasName("funcionarios_pkey");

                entity.ToTable("funcionarios");

                entity.HasIndex(e => e.Cpf, "cpf_idx").IsUnique();

                entity.Property(e => e.Id)
                   .IsRequired()
                   .HasColumnName("id")
                   .UseIdentityAlwaysColumn();

                entity.Property(e => e.FuncionarioNumero)
                    .IsRequired()
                    .HasColumnName("funcionario_numero")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11).
                    HasColumnName("cpf");

                entity.Property(e => e.DataContratacao)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("data_contratacao");

                entity.Property(e => e.DataNascimento)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("data_nascimento");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("genero");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("nome");

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("sobrenome");
            });

            modelBuilder.Entity<Salarios>(entity =>
            {
                entity.HasKey(e => new { e.FuncionarioNumero, e.Inicio })
                    .HasName("salarios_pkey");

                entity.ToTable("salarios");

                entity.Property(e => e.FuncionarioNumero).HasColumnName("funcionario_numero");

                entity.Property(e => e.Inicio)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("inicio");

                entity.Property(e => e.Salario)
                .IsRequired()
                .HasColumnName("salario");

                entity.Property(e => e.Termino)
                    .HasColumnType("date")
                    .HasColumnName("termino");

                entity.HasOne(d => d.FunNumNavigation)
                    .WithMany(p => p.Salarios)
                    .HasForeignKey(d => d.FuncionarioNumero)
                    .HasConstraintName("salarios_funcionario_numero_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
