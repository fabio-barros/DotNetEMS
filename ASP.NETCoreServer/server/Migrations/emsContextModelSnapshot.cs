﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using server.Models;

namespace server.Migrations
{
    [DbContext(typeof(EmsContext))]
    partial class emsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Portuguese_Brazil.1252")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("server.Models.Cargos", b =>
                {
                    b.Property<int>("FuncionarioNumero")
                        .HasColumnType("integer")
                        .HasColumnName("funcionario_numero");

                    b.Property<string>("Titulo")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("titulo");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("date")
                        .HasColumnName("inicio");

                    b.Property<DateTime?>("Termino")
                        .HasColumnType("date")
                        .HasColumnName("termino");

                    b.HasKey("FuncionarioNumero", "Titulo", "Inicio")
                        .HasName("cargos_pkey");

                    b.ToTable("cargos");
                });

            modelBuilder.Entity("server.Models.DepartamentoFuncionario", b =>
                {
                    b.Property<int>("FuncionarioNumero")
                        .HasColumnType("integer")
                        .HasColumnName("funcionario_numero");

                    b.Property<string>("DepartamentoNumero")
                        .HasMaxLength(4)
                        .HasColumnType("character(4)")
                        .HasColumnName("departamento_numero")
                        .IsFixedLength(true);

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("date")
                        .HasColumnName("inicio");

                    b.Property<DateTime>("Termino")
                        .HasColumnType("date")
                        .HasColumnName("termino");

                    b.HasKey("FuncionarioNumero", "DepartamentoNumero")
                        .HasName("departamento_funcionario_pkey");

                    b.HasIndex(new[] { "DepartamentoNumero" }, "departamento_funcionario_departamento_numero_idx");

                    b.ToTable("departamento_funcionario");
                });

            modelBuilder.Entity("server.Models.DepartamentoGerencia", b =>
                {
                    b.Property<string>("DepartamentoNumero")
                        .HasMaxLength(4)
                        .HasColumnType("character(4)")
                        .HasColumnName("departamento_numero")
                        .IsFixedLength(true);

                    b.Property<int>("FuncionarioNumero")
                        .HasColumnType("integer")
                        .HasColumnName("funcionario_numero");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("date")
                        .HasColumnName("inicio");

                    b.Property<DateTime>("Termino")
                        .HasColumnType("date")
                        .HasColumnName("termino");

                    b.HasKey("DepartamentoNumero", "FuncionarioNumero")
                        .HasName("depar_geren_pkey");

                    b.HasIndex("FuncionarioNumero");

                    b.HasIndex(new[] { "DepartamentoNumero" }, "funcionario_numero_departamento_numero_idx");

                    b.ToTable("departamento_gerencia");
                });

            modelBuilder.Entity("server.Models.Departamentos", b =>
                {
                    b.Property<string>("DepartamentoNumero")
                        .HasMaxLength(4)
                        .HasColumnType("character(4)")
                        .HasColumnName("departamento_numero")
                        .IsFixedLength(true);

                    b.Property<string>("DepartamentoNome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("departamento_nome");

                    b.HasKey("DepartamentoNumero")
                        .HasName("departamentos_pkey");

                    b.HasIndex(new[] { "DepartamentoNumero" }, "departamentos_departamento_nome_key")
                        .IsUnique();

                    b.ToTable("departamentos");
                });

            modelBuilder.Entity("server.Models.Funcionarios", b =>
                {
                    b.Property<int>("FuncionarioNumero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("funcionario_numero")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("date")
                        .HasColumnName("data_contratacao");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("genero");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("nome");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("sobrenome");

                    b.HasKey("FuncionarioNumero")
                        .HasName("funcionarios_pkey");

                    b.HasIndex(new[] { "Cpf" }, "cpf_idx");

                    b.ToTable("funcionarios");
                });

            modelBuilder.Entity("server.Models.Salarios", b =>
                {
                    b.Property<int>("FuncionarioNumero")
                        .HasColumnType("integer")
                        .HasColumnName("funcionario_numero");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("date")
                        .HasColumnName("inicio");

                    b.Property<decimal>("Salario")
                        .HasColumnType("numeric")
                        .HasColumnName("salario");

                    b.Property<DateTime>("Termino")
                        .HasColumnType("date")
                        .HasColumnName("termino");

                    b.HasKey("FuncionarioNumero", "Inicio")
                        .HasName("salarios_pkey");

                    b.ToTable("salarios");
                });

            modelBuilder.Entity("server.Models.Cargos", b =>
                {
                    b.HasOne("server.Models.Funcionarios", "FunNumNavigation")
                        .WithMany("Cargos")
                        .HasForeignKey("FuncionarioNumero")
                        .HasConstraintName("cargos_funcionario_numero_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FunNumNavigation");
                });

            modelBuilder.Entity("server.Models.DepartamentoFuncionario", b =>
                {
                    b.HasOne("server.Models.Departamentos", "DeparNumNavigation")
                        .WithMany("DeparFuncs")
                        .HasForeignKey("DepartamentoNumero")
                        .HasConstraintName("departamento_funcionario_departamento_numero_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Funcionarios", "FunNumNavigation")
                        .WithMany("DeparFuncs")
                        .HasForeignKey("FuncionarioNumero")
                        .HasConstraintName("departamento_funcionario_funcionario_numero_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeparNumNavigation");

                    b.Navigation("FunNumNavigation");
                });

            modelBuilder.Entity("server.Models.DepartamentoGerencia", b =>
                {
                    b.HasOne("server.Models.Departamentos", "DeparNumNavigation")
                        .WithMany("DeparGerens")
                        .HasForeignKey("DepartamentoNumero")
                        .HasConstraintName("departamento_gerencia_departamento_numero_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Funcionarios", "FunNumNavigation")
                        .WithMany("DeparGerens")
                        .HasForeignKey("FuncionarioNumero")
                        .HasConstraintName("depar_geren_fun_num_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeparNumNavigation");

                    b.Navigation("FunNumNavigation");
                });

            modelBuilder.Entity("server.Models.Salarios", b =>
                {
                    b.HasOne("server.Models.Funcionarios", "FunNumNavigation")
                        .WithMany("Salarios")
                        .HasForeignKey("FuncionarioNumero")
                        .HasConstraintName("salarios_funcionario_numero_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FunNumNavigation");
                });

            modelBuilder.Entity("server.Models.Departamentos", b =>
                {
                    b.Navigation("DeparFuncs");

                    b.Navigation("DeparGerens");
                });

            modelBuilder.Entity("server.Models.Funcionarios", b =>
                {
                    b.Navigation("Cargos");

                    b.Navigation("DeparFuncs");

                    b.Navigation("DeparGerens");

                    b.Navigation("Salarios");
                });
#pragma warning restore 612, 618
        }
    }
}
