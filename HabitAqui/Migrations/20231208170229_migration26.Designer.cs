﻿// <auto-generated />
using System;
using HabitAqui.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HabitAqui.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231208170229_migration26")]
    partial class migration26
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

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdministradorId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("HabitAqui.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                });

            modelBuilder.Entity("HabitAqui.Models.Arrendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EntregarArrendamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipamentoId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("HabitacaoId")
                        .HasColumnType("int");

                    b.Property<int>("LocadorId")
                        .HasColumnType("int");

                    b.Property<int?>("ReceberArrendamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EntregarArrendamentoId");

                    b.HasIndex("EquipamentoId");

                    b.HasIndex("HabitacaoId");

                    b.HasIndex("LocadorId");

                    b.HasIndex("ReceberArrendamentoId");

                    b.ToTable("Arrendamentos");
                });

            modelBuilder.Entity("HabitAqui.Models.AvaliacaoHabitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HabitacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HabitacaoId");

                    b.ToTable("AvaliacoesHabitacao");
                });

            modelBuilder.Entity("HabitAqui.Models.AvaliacaoLocador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LocadorId");

                    b.ToTable("AvaliacoesLocador");
                });

            modelBuilder.Entity("HabitAqui.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<int?>("AdministradorId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.HasIndex("AdministradorId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("HabitAqui.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("HabitAqui.Models.Dano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fomat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Danos");
                });

            modelBuilder.Entity("HabitAqui.Models.EntregarArrendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Danos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioEntregaId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioEntregaId");

                    b.ToTable("EntregarArrendamento");
                });

            modelBuilder.Entity("HabitAqui.Models.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EntregarArrendamentoId")
                        .HasColumnType("int");

                    b.Property<int>("EquipamentoEstado")
                        .HasColumnType("int");

                    b.Property<bool?>("Existencia")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceberArrendamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntregarArrendamentoId");

                    b.HasIndex("ReceberArrendamentoId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("HabitAqui.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("GestorId")
                        .HasColumnType("int");

                    b.Property<int>("LocadorId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("GestorId");

                    b.HasIndex("LocadorId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("HabitAqui.Models.Gestor", b =>
                {
                    b.Property<int>("GestorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GestorId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LocadorId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GestorId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("LocadorId");

                    b.ToTable("Gestores");
                });

            modelBuilder.Entity("HabitAqui.Models.Habitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("Custo")
                        .HasColumnType("int");

                    b.Property<int?>("LocadorId")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("MediaAvaliacao")
                        .HasColumnType("float");

                    b.Property<int>("PeriodoMaximoArrendamento")
                        .HasColumnType("int");

                    b.Property<int>("PeriodoMinimoArrendamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("LocadorId");

                    b.ToTable("Habitacoes");
                });

            modelBuilder.Entity("HabitAqui.Models.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArrendamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArrendamentoId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("HabitAqui.Models.Locador", b =>
                {
                    b.Property<int>("LocadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocadorId"), 1L, 1);

                    b.Property<int?>("AdministradorId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("EstadoDeSubscricao")
                        .HasColumnType("bit");

                    b.Property<double?>("MediaAvaliacao")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocadorId");

                    b.HasIndex("AdministradorId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Locadores");
                });

            modelBuilder.Entity("HabitAqui.Models.ReceberArrendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Danos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FuncionarioRecebeuId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioRecebeuId");

                    b.ToTable("ReceberArrendamento");
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

            modelBuilder.Entity("HabitAqui.Models.Administrador", b =>
                {
                    b.HasOne("HabitAqui.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("HabitAqui.Models.Arrendamento", b =>
                {
                    b.HasOne("HabitAqui.Models.Cliente", "Cliente")
                        .WithMany("Arrendamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitAqui.Models.EntregarArrendamento", "EntregarArrendamento")
                        .WithMany()
                        .HasForeignKey("EntregarArrendamentoId");

                    b.HasOne("HabitAqui.Models.Equipamento", null)
                        .WithMany("Arrendamentos")
                        .HasForeignKey("EquipamentoId");

                    b.HasOne("HabitAqui.Models.Habitacao", "Habitacao")
                        .WithMany("Arrendamentos")
                        .HasForeignKey("HabitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitAqui.Models.Locador", "Locador")
                        .WithMany("Arrendamentos")
                        .HasForeignKey("LocadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitAqui.Models.ReceberArrendamento", "ReceberArrendamento")
                        .WithMany()
                        .HasForeignKey("ReceberArrendamentoId");

                    b.Navigation("Cliente");

                    b.Navigation("EntregarArrendamento");

                    b.Navigation("Habitacao");

                    b.Navigation("Locador");

                    b.Navigation("ReceberArrendamento");
                });

            modelBuilder.Entity("HabitAqui.Models.AvaliacaoHabitacao", b =>
                {
                    b.HasOne("HabitAqui.Models.Cliente", "Cliente")
                        .WithMany("AvaliacoesHabitacao")
                        .HasForeignKey("ClienteId");

                    b.HasOne("HabitAqui.Models.Habitacao", "Habitacao")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("HabitacaoId");

                    b.Navigation("Cliente");

                    b.Navigation("Habitacao");
                });

            modelBuilder.Entity("HabitAqui.Models.AvaliacaoLocador", b =>
                {
                    b.HasOne("HabitAqui.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("HabitAqui.Models.Locador", "Locador")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("LocadorId");

                    b.Navigation("Cliente");

                    b.Navigation("Locador");
                });

            modelBuilder.Entity("HabitAqui.Models.Categoria", b =>
                {
                    b.HasOne("HabitAqui.Models.Administrador", null)
                        .WithMany("Categorias")
                        .HasForeignKey("AdministradorId");
                });

            modelBuilder.Entity("HabitAqui.Models.Cliente", b =>
                {
                    b.HasOne("HabitAqui.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("HabitAqui.Models.EntregarArrendamento", b =>
                {
                    b.HasOne("HabitAqui.Models.Funcionario", "FuncionarioEntrega")
                        .WithMany()
                        .HasForeignKey("FuncionarioEntregaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuncionarioEntrega");
                });

            modelBuilder.Entity("HabitAqui.Models.Equipamento", b =>
                {
                    b.HasOne("HabitAqui.Models.EntregarArrendamento", null)
                        .WithMany("Equipamentos")
                        .HasForeignKey("EntregarArrendamentoId");

                    b.HasOne("HabitAqui.Models.ReceberArrendamento", null)
                        .WithMany("Equipamentos")
                        .HasForeignKey("ReceberArrendamentoId");
                });

            modelBuilder.Entity("HabitAqui.Models.Funcionario", b =>
                {
                    b.HasOne("HabitAqui.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("HabitAqui.Models.Gestor", "Gestor")
                        .WithMany("Funcionarios")
                        .HasForeignKey("GestorId");

                    b.HasOne("HabitAqui.Models.Locador", "Locador")
                        .WithMany("Funcionarios")
                        .HasForeignKey("LocadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Gestor");

                    b.Navigation("Locador");
                });

            modelBuilder.Entity("HabitAqui.Models.Gestor", b =>
                {
                    b.HasOne("HabitAqui.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("HabitAqui.Models.Locador", "Locador")
                        .WithMany("Gestores")
                        .HasForeignKey("LocadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Locador");
                });

            modelBuilder.Entity("HabitAqui.Models.Habitacao", b =>
                {
                    b.HasOne("HabitAqui.Models.Categoria", "Categoria")
                        .WithMany("Habitacao")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("HabitAqui.Models.Locador", "Locador")
                        .WithMany("Habitacoes")
                        .HasForeignKey("LocadorId");

                    b.Navigation("Categoria");

                    b.Navigation("Locador");
                });

            modelBuilder.Entity("HabitAqui.Models.Imagem", b =>
                {
                    b.HasOne("HabitAqui.Models.Arrendamento", "Arrendamento")
                        .WithMany("Imagens")
                        .HasForeignKey("ArrendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arrendamento");
                });

            modelBuilder.Entity("HabitAqui.Models.Locador", b =>
                {
                    b.HasOne("HabitAqui.Models.Administrador", null)
                        .WithMany("Locadores")
                        .HasForeignKey("AdministradorId");

                    b.HasOne("HabitAqui.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("HabitAqui.Models.ReceberArrendamento", b =>
                {
                    b.HasOne("HabitAqui.Models.Funcionario", "FuncionarioRecebeu")
                        .WithMany()
                        .HasForeignKey("FuncionarioRecebeuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuncionarioRecebeu");
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
                    b.HasOne("HabitAqui.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HabitAqui.Models.ApplicationUser", null)
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

                    b.HasOne("HabitAqui.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HabitAqui.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HabitAqui.Models.Administrador", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Locadores");
                });

            modelBuilder.Entity("HabitAqui.Models.Arrendamento", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("HabitAqui.Models.Categoria", b =>
                {
                    b.Navigation("Habitacao");
                });

            modelBuilder.Entity("HabitAqui.Models.Cliente", b =>
                {
                    b.Navigation("Arrendamentos");

                    b.Navigation("AvaliacoesHabitacao");
                });

            modelBuilder.Entity("HabitAqui.Models.EntregarArrendamento", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("HabitAqui.Models.Equipamento", b =>
                {
                    b.Navigation("Arrendamentos");
                });

            modelBuilder.Entity("HabitAqui.Models.Gestor", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("HabitAqui.Models.Habitacao", b =>
                {
                    b.Navigation("Arrendamentos");

                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("HabitAqui.Models.Locador", b =>
                {
                    b.Navigation("Arrendamentos");

                    b.Navigation("Avaliacoes");

                    b.Navigation("Funcionarios");

                    b.Navigation("Gestores");

                    b.Navigation("Habitacoes");
                });

            modelBuilder.Entity("HabitAqui.Models.ReceberArrendamento", b =>
                {
                    b.Navigation("Equipamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
