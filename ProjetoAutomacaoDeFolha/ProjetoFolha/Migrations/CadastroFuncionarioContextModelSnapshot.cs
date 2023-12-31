﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFolha.Data;

#nullable disable

namespace ProjetoFolha.Migrations
{
    [DbContext(typeof(CadastroFuncionarioContext))]
    partial class CadastroFuncionarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoFolha.Models.CadastroFuncionarioModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("cargo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dataAdmissao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("sexoSelecionado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CadastroFuncionarioModel");
                });
#pragma warning restore 612, 618
        }
    }
}
