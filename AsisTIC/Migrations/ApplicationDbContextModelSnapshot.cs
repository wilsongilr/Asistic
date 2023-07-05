﻿// <auto-generated />
using System;
using AsisTIC.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsisTIC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AsisTIC.Models.ITHTicket", b =>
                {
                    b.Property<int>("IdTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTicket"));

                    b.Property<bool>("Adjunto")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime2");

                    b.Property<int>("ITHTipoSolicitudidsolicitud")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdSolicitud")
                        .HasColumnType("int");

                    b.Property<string>("Solicitud")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrSolicita")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTicket");

                    b.HasIndex("ITHTipoSolicitudidsolicitud");

                    b.ToTable("ITHticket", t =>
                        {
                            t.HasTrigger("trgEnviarCorreoTicketUsuario");
                        });
                });

            modelBuilder.Entity("AsisTIC.Models.ITHTipoSolicitud", b =>
                {
                    b.Property<int>("idsolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idsolicitud"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("solicitud")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idsolicitud");

                    b.ToTable("ITHtipoSolicitud");
                });

            modelBuilder.Entity("AsisTIC.Models.ITHTicket", b =>
                {
                    b.HasOne("AsisTIC.Models.ITHTipoSolicitud", "ITHTipoSolicitud")
                        .WithMany()
                        .HasForeignKey("ITHTipoSolicitudidsolicitud")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ITHTipoSolicitud");
                });
#pragma warning restore 612, 618
        }
    }
}