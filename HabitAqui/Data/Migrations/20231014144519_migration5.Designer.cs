﻿// <auto-generated />
using System;
using HabitAqui.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HabitAqui.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231014144519_migration5")]
    partial class migration5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HabitAqui.Models.Administrador", b =>
                {
                    b.Property<int>("AdministradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdministradorId"), 1L, 1);

                    b.Property<string>("UtilizadorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AdministradorId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("HabitAqui.Models.Arrendamento", b =>
                {
                    b.Property<int>("ArrendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArrendamentoId"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("HabitacaoId")
                        .HasColumnType("int");

                    b.Property<int>("Periodo_max")
                        .HasColumnType("int");

                    b.Property<int>("Periodo_min")
                        .HasColumnType("int");

                    b.HasKey("ArrendamentoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HabitacaoId");

                    b.ToTable("Arrendamento");
                });

            modelBuilder.Entity("HabitAqui.Models.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliacaoId"), 1L, 1);

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HabitacaoId")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HabitacaoId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("HabitAqui.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("HabitAqui.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("UtilizadorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClienteId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("HabitAqui.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"), 1L, 1);

                    b.Property<int?>("GestorId")
                        .HasColumnType("int");

                    b.Property<int>("LocadorId")
                        .HasColumnType("int");

                    b.Property<string>("UtilizadorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("GestorId");

                    b.HasIndex("LocadorId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("HabitAqui.Models.Gestor", b =>
                {
                    b.Property<int>("GestorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GestorId"), 1L, 1);

                    b.Property<int>("LocadorId")
                        .HasColumnType("int");

                    b.Property<string>("UtilizadorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GestorId");

                    b.HasIndex("LocadorId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Gestor");
                });

            modelBuilder.Entity("HabitAqui.Models.Habitacao", b =>
                {
                    b.Property<int>("HabitacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HabitacaoId"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("Custo")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int?>("GestorId")
                        .HasColumnType("int");

                    b.Property<int>("LocadorId")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HabitacaoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("GestorId");

                    b.HasIndex("LocadorId");

                    b.ToTable("Habitacao");
                });

            modelBuilder.Entity("HabitAqui.Models.Locador", b =>
                {
                    b.Property<int>("LocadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocadorId"), 1L, 1);

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocadorId");

                    b.ToTable("Locador");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HabitAqui.Models.Utilizador", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Utilizador");
                });

            modelBuilder.Entity("HabitAqui.Models.Administrador", b =>
                {
                    b.HasOne("HabitAqui.Models.Utilizador", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("HabitAqui.Models.Arrendamento", b =>
                {
                    b.HasOne("HabitAqui.Models.Cliente", "Cliente")
                        .WithMany("Arrendamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitAqui.Models.Habitacao", "Habitacao")
                        .WithMany()
                        .HasForeignKey("HabitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Habitacao");
                });

            modelBuilder.Entity("HabitAqui.Models.Avaliacao", b =>
                {
                    b.HasOne("HabitAqui.Models.Cliente", "Cliente")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitAqui.Models.Habitacao", "Habitacao")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("HabitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Habitacao");
                });

            modelBuilder.Entity("HabitAqui.Models.Cliente", b =>
                {
                    b.HasOne("HabitAqui.Models.Utilizador", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("HabitAqui.Models.Funcionario", b =>
                {
                    b.HasOne("HabitAqui.Models.Gestor", null)
                        .WithMany("Funcionarios")
                        .HasForeignKey("GestorId");

                    b.HasOne("HabitAqui.Models.Locador", "Locador")
                        .WithMany()
                        .HasForeignKey("LocadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitAqui.Models.Utilizador", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locador");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("HabitAqui.Models.Gestor", b =>
                {
                    b.HasOne("HabitAqui.Models.Locador", "Locador")
                        .WithMany()
                        .HasForeignKey("LocadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitAqui.Models.Utilizador", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locador");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("HabitAqui.Models.Habitacao", b =>
                {
                    b.HasOne("HabitAqui.Models.Categoria", "Categoria")
                        .WithMany("Habitacao")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitAqui.Models.Funcionario", null)
                        .WithMany("Habitacoes")
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("HabitAqui.Models.Gestor", null)
                        .WithMany("Habitacoes")
                        .HasForeignKey("GestorId");

                    b.HasOne("HabitAqui.Models.Locador", "Locador")
                        .WithMany("Habitacoes")
                        .HasForeignKey("LocadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Locador");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HabitAqui.Models.Categoria", b =>
                {
                    b.Navigation("Habitacao");
                });

            modelBuilder.Entity("HabitAqui.Models.Cliente", b =>
                {
                    b.Navigation("Arrendamentos");

                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("HabitAqui.Models.Funcionario", b =>
                {
                    b.Navigation("Habitacoes");
                });

            modelBuilder.Entity("HabitAqui.Models.Gestor", b =>
                {
                    b.Navigation("Funcionarios");

                    b.Navigation("Habitacoes");
                });

            modelBuilder.Entity("HabitAqui.Models.Habitacao", b =>
                {
                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("HabitAqui.Models.Locador", b =>
                {
                    b.Navigation("Habitacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
