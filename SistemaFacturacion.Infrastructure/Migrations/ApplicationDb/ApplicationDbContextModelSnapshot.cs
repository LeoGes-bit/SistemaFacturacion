﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaFacturacion.Infrastructure.Data.Contexts;

namespace SistemaFacturacion.Infrastructure.Migrations.ApplicationDb
{
    [DbContext(typeof(FacturacionDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("AspNetCoreHero.EntityFrameworkCore.AuditTrail.Models.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AffectedColumns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.Detalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ValorTotal")
                        .HasColumnType("int");

                    b.Property<int?>("ValorUnitario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPersona");

                    b.ToTable("Detalles", "facturacion");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificaion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreRazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoIdentifiacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Empresas", "facturacion");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaGeneracion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("IVA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PuntoEmision")
                        .HasColumnType("int");

                    b.Property<int>("PuntoVenta")
                        .HasColumnType("int");

                    b.Property<int>("Secuencial")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdPersona");

                    b.ToTable("Facturas", "facturacion");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificaion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoConvencional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoCliente")
                        .HasColumnType("int");

                    b.Property<int>("TipoIdentifiacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Personas", "facturacion");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.PuntoVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEmpesa")
                        .HasColumnType("int");

                    b.Property<int?>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PuntoDeVenta")
                        .HasColumnType("int");

                    b.Property<int>("PuntoEmision")
                        .HasColumnType("int");

                    b.Property<int>("Secuencial")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("PuntoVentas", "facturacion");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Maestro.Catalogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("IdRol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Catalogos", "adm");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Maestro.DetalleCatalogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdCatalogo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Secuencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCatalogo");

                    b.ToTable("DetalleCatalogos", "adm");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.Detalle", b =>
                {
                    b.HasOne("SistemaFacturacion.Domain.Entities.Facturacion.Persona", "Personas")
                        .WithMany("Personas")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personas");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.Factura", b =>
                {
                    b.HasOne("SistemaFacturacion.Domain.Entities.Facturacion.Persona", "Personas")
                        .WithMany("Facturas")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personas");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.PuntoVenta", b =>
                {
                    b.HasOne("SistemaFacturacion.Domain.Entities.Facturacion.Empresa", "Empresas")
                        .WithMany("PuntoVentas")
                        .HasForeignKey("IdEmpresa");

                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Maestro.DetalleCatalogo", b =>
                {
                    b.HasOne("SistemaFacturacion.Domain.Entities.Maestro.Catalogo", "Catalogos")
                        .WithMany("DetalleCatalogos")
                        .HasForeignKey("IdCatalogo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalogos");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.Empresa", b =>
                {
                    b.Navigation("PuntoVentas");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Facturacion.Persona", b =>
                {
                    b.Navigation("Facturas");

                    b.Navigation("Personas");
                });

            modelBuilder.Entity("SistemaFacturacion.Domain.Entities.Maestro.Catalogo", b =>
                {
                    b.Navigation("DetalleCatalogos");
                });
#pragma warning restore 612, 618
        }
    }
}
