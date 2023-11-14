﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataInfo))]
    [Migration("20231114210731_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Clases.ActualizacionFuncionario", b =>
                {
                    b.Property<int>("CI")
                        .HasColumnType("int");

                    b.Property<bool>("completado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fecha_actualizacion")
                        .HasColumnType("datetime2");

                    b.HasKey("CI");

                    b.ToTable("actualizacion_funcionario", (string)null);
                });

            modelBuilder.Entity("API.Clases.Agenda", b =>
                {
                    b.Property<int>("nro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("nro"));

                    b.Property<int>("CI")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaAgenda")
                        .HasColumnType("datetime2");

                    b.HasKey("nro");

                    b.HasIndex("CI");

                    b.ToTable("agenda", (string)null);
                });

            modelBuilder.Entity("API.Clases.CarnetSalud", b =>
                {
                    b.Property<int>("CI")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comprobante")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("fechaVencimiento")
                        .HasColumnType("datetime2");

                    b.HasKey("CI", "fechaEmision");

                    b.ToTable("carnet_salud", (string)null);
                });

            modelBuilder.Entity("API.Clases.Funcionarios", b =>
                {
                    b.Property<int>("CI")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CI"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("logId")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.HasKey("CI");

                    b.HasIndex("logId");

                    b.ToTable("funcionarios", (string)null);
                });

            modelBuilder.Entity("API.Clases.Logins", b =>
                {
                    b.Property<int>("logId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("logId"));

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("logId");

                    b.ToTable("logins", (string)null);
                });

            modelBuilder.Entity("API.Clases.PeriodosActualizacion", b =>
                {
                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("año")
                        .HasColumnType("int");

                    b.Property<int>("semestre")
                        .HasColumnType("int");

                    b.HasKey("fechaInicio", "fechaFin");

                    b.ToTable("periodos_actualizacion", (string)null);
                });

            modelBuilder.Entity("API.Clases.ActualizacionFuncionario", b =>
                {
                    b.HasOne("API.Clases.Funcionarios", "FuncCI")
                        .WithMany()
                        .HasForeignKey("CI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuncCI");
                });

            modelBuilder.Entity("API.Clases.Agenda", b =>
                {
                    b.HasOne("API.Clases.Funcionarios", "FuncId")
                        .WithMany()
                        .HasForeignKey("CI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuncId");
                });

            modelBuilder.Entity("API.Clases.CarnetSalud", b =>
                {
                    b.HasOne("API.Clases.Funcionarios", "FuncCI")
                        .WithMany()
                        .HasForeignKey("CI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuncCI");
                });

            modelBuilder.Entity("API.Clases.Funcionarios", b =>
                {
                    b.HasOne("API.Clases.Logins", "Log")
                        .WithMany()
                        .HasForeignKey("logId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Log");
                });
#pragma warning restore 612, 618
        }
    }
}