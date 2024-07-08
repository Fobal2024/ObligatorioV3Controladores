﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obligatorio.Datos;

#nullable disable

namespace Obligatorio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240707173009_CorrecEditsocio4")]
    partial class CorrecEditsocio4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EjercicioRutina", b =>
                {
                    b.Property<int>("EjerciciosId")
                        .HasColumnType("int");

                    b.Property<int>("RutinaId")
                        .HasColumnType("int");

                    b.HasKey("EjerciciosId", "RutinaId");

                    b.HasIndex("RutinaId");

                    b.ToTable("EjercicioRutina");
                });

            modelBuilder.Entity("Obligatorio.Models.Ejercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MaquinaNecesariaIdMaquina")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaNecesariaIdMaquina");

                    b.ToTable("Ejercicio");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Remo"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Sentadilla"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Jalon de Pecho"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Abdominales"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Bicicleta"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Caminar en Cinta"
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "Peso Muerto"
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsableId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResponsableId");

                    b.ToTable("Local");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ciudad = "Colonia",
                            Direccion = "Artigas1190",
                            Nombre = "Local 1",
                            ResponsableId = 1,
                            Telefono = "45220047"
                        },
                        new
                        {
                            Id = 2,
                            Ciudad = "Carmelo",
                            Direccion = "Rivera 1866",
                            Nombre = "Local 2",
                            ResponsableId = 2,
                            Telefono = "3827562"
                        },
                        new
                        {
                            Id = 3,
                            Ciudad = "Nueva Palmira",
                            Direccion = "Lavalleja 1654",
                            Nombre = "Local 3",
                            ResponsableId = 3,
                            Telefono = "1847162"
                        },
                        new
                        {
                            Id = 4,
                            Ciudad = "Juan Lacaze",
                            Direccion = "Gral. Flores 1452",
                            Nombre = "Local 4",
                            ResponsableId = 4,
                            Telefono = "2837426"
                        },
                        new
                        {
                            Id = 5,
                            Ciudad = "Nueva Helvecia",
                            Direccion = "Montevideo 1164",
                            Nombre = "Local 5",
                            ResponsableId = 5,
                            Telefono = "823746"
                        },
                        new
                        {
                            Id = 6,
                            Ciudad = "Rosario",
                            Direccion = "Argentina 1526",
                            Nombre = "Local 6",
                            ResponsableId = 6,
                            Telefono = "23874623"
                        },
                        new
                        {
                            Id = 7,
                            Ciudad = "Colonia Valdense",
                            Direccion = "Ruta 1 y Manton",
                            Nombre = "Local 7",
                            ResponsableId = 7,
                            Telefono = "283746"
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.Maquina", b =>
                {
                    b.Property<int>("IdMaquina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaquina"));

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<int>("PrecioCompra")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeMaquinaId")
                        .HasColumnType("int");

                    b.Property<int>("VidaUtil")
                        .HasColumnType("int");

                    b.HasKey("IdMaquina");

                    b.HasIndex("LocalId");

                    b.HasIndex("TipoDeMaquinaId");

                    b.ToTable("Maquina");

                    b.HasData(
                        new
                        {
                            IdMaquina = 1,
                            Disponible = true,
                            FechaCompra = new DateTime(2022, 12, 22, 12, 15, 0, 0, DateTimeKind.Unspecified),
                            LocalId = 1,
                            PrecioCompra = 15000,
                            TipoDeMaquinaId = 1,
                            VidaUtil = 6
                        },
                        new
                        {
                            IdMaquina = 2,
                            Disponible = true,
                            FechaCompra = new DateTime(2023, 6, 5, 9, 49, 0, 0, DateTimeKind.Unspecified),
                            LocalId = 4,
                            PrecioCompra = 17400,
                            TipoDeMaquinaId = 2,
                            VidaUtil = 6
                        },
                        new
                        {
                            IdMaquina = 3,
                            Disponible = true,
                            FechaCompra = new DateTime(2024, 3, 21, 14, 51, 0, 0, DateTimeKind.Unspecified),
                            LocalId = 5,
                            PrecioCompra = 23050,
                            TipoDeMaquinaId = 3,
                            VidaUtil = 5
                        },
                        new
                        {
                            IdMaquina = 4,
                            Disponible = true,
                            FechaCompra = new DateTime(2022, 9, 5, 13, 55, 0, 0, DateTimeKind.Unspecified),
                            LocalId = 5,
                            PrecioCompra = 26000,
                            TipoDeMaquinaId = 5,
                            VidaUtil = 7
                        },
                        new
                        {
                            IdMaquina = 5,
                            Disponible = false,
                            FechaCompra = new DateTime(2023, 12, 15, 8, 56, 0, 0, DateTimeKind.Unspecified),
                            LocalId = 6,
                            PrecioCompra = 30000,
                            TipoDeMaquinaId = 7,
                            VidaUtil = 4
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.Responsable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "María Díaz",
                            Telefono = "3457436"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Ana Fernandez",
                            Telefono = "43545428"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Facundo Lopez",
                            Telefono = "67254127"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Flavia Rodriguez",
                            Telefono = "32871451726"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Karen Gonzalez",
                            Telefono = "23572673"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Nicolas Pereira",
                            Telefono = "2387625"
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "Marcelo Dominguez",
                            Telefono = "127457615"
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.Rutina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CalificacionPromedio")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoRutina")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoRutina");

                    b.ToTable("Rutinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CalificacionPromedio = 8,
                            Descripcion = "Pecho",
                            IdTipoRutina = 1
                        },
                        new
                        {
                            Id = 2,
                            CalificacionPromedio = 9,
                            Descripcion = "Espalda",
                            IdTipoRutina = 1
                        },
                        new
                        {
                            Id = 3,
                            CalificacionPromedio = 8,
                            Descripcion = "Hombros",
                            IdTipoRutina = 2
                        },
                        new
                        {
                            Id = 4,
                            CalificacionPromedio = 7,
                            Descripcion = "Biceps",
                            IdTipoRutina = 2
                        },
                        new
                        {
                            Id = 5,
                            CalificacionPromedio = 9,
                            Descripcion = "Piernas",
                            IdTipoRutina = 3
                        },
                        new
                        {
                            Id = 6,
                            CalificacionPromedio = 8,
                            Descripcion = "Dorsales",
                            IdTipoRutina = 3
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.RutinaEjercicio", b =>
                {
                    b.Property<int>("IdRutina")
                        .HasColumnType("int");

                    b.Property<int>("IdEjercicio")
                        .HasColumnType("int");

                    b.Property<int>("Repeticiones")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.HasKey("IdRutina", "IdEjercicio");

                    b.HasIndex("IdEjercicio");

                    b.ToTable("RutinaEjercicio");

                    b.HasData(
                        new
                        {
                            IdRutina = 1,
                            IdEjercicio = 3,
                            Repeticiones = 8,
                            Series = 4
                        },
                        new
                        {
                            IdRutina = 4,
                            IdEjercicio = 7,
                            Repeticiones = 10,
                            Series = 3
                        },
                        new
                        {
                            IdRutina = 2,
                            IdEjercicio = 1,
                            Repeticiones = 10,
                            Series = 3
                        },
                        new
                        {
                            IdRutina = 5,
                            IdEjercicio = 5,
                            Repeticiones = 12,
                            Series = 4
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.Socio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoRutina")
                        .HasColumnType("int")
                        .HasColumnName("IdTipoRutina");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.ToTable("Socios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jsdfwheuu@gmail.com",
                            IdTipoRutina = 0,
                            LocalId = 1,
                            Nombre = "Alberto Dalmas",
                            Telefono = "23752",
                            Tipo = "Estandar"
                        },
                        new
                        {
                            Id = 2,
                            Email = "hegfiweufgw@hotmail.com",
                            IdTipoRutina = 0,
                            LocalId = 5,
                            Nombre = "Martina Perez",
                            Telefono = "23874253",
                            Tipo = "Premium"
                        },
                        new
                        {
                            Id = 3,
                            Email = "sbakjsfkjasf@hotmail.com",
                            IdTipoRutina = 0,
                            LocalId = 2,
                            Nombre = "Carlos Dominicci",
                            Telefono = "23764253",
                            Tipo = "Estandar"
                        },
                        new
                        {
                            Id = 4,
                            Email = "dhhdk@gmail.com",
                            IdTipoRutina = 0,
                            LocalId = 6,
                            Nombre = "Pablo Ayala",
                            Telefono = "375263",
                            Tipo = "Estandar"
                        },
                        new
                        {
                            Id = 5,
                            Email = "fuhaiuhak@gmail.com",
                            IdTipoRutina = 0,
                            LocalId = 7,
                            Nombre = "Daniela Chevalier",
                            Telefono = "3172652",
                            Tipo = "Premium"
                        },
                        new
                        {
                            Id = 6,
                            Email = "hjgduwfyge@gmail.com",
                            IdTipoRutina = 0,
                            LocalId = 1,
                            Nombre = "Manuela Sosa",
                            Telefono = "8472364",
                            Tipo = "Premium"
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.SocioRutina", b =>
                {
                    b.Property<int>("IdSocio")
                        .HasColumnType("int");

                    b.Property<int>("IdRutina")
                        .HasColumnType("int");

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.HasKey("IdSocio", "IdRutina");

                    b.HasIndex("IdRutina");

                    b.ToTable("SocioRutinas");

                    b.HasData(
                        new
                        {
                            IdSocio = 1,
                            IdRutina = 2,
                            Calificacion = 8
                        },
                        new
                        {
                            IdSocio = 3,
                            IdRutina = 3,
                            Calificacion = 9
                        },
                        new
                        {
                            IdSocio = 1,
                            IdRutina = 3,
                            Calificacion = 8
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.TipoDeMaquina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDeMaquina");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Bicicleta fija"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Cinta Corredor"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Escaladora"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Máquina de Remo"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Prensa de Piernas"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Banco de Pecho"
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "Maquina Femorales"
                        });
                });

            modelBuilder.Entity("Obligatorio.Models.TipoRutina", b =>
                {
                    b.Property<int>("IdTipoRutina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoRutina"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoRutina");

                    b.ToTable("TipoRutinas");

                    b.HasData(
                        new
                        {
                            IdTipoRutina = 1,
                            Nombre = "Salud"
                        },
                        new
                        {
                            IdTipoRutina = 2,
                            Nombre = "Competición Amateur"
                        },
                        new
                        {
                            IdTipoRutina = 3,
                            Nombre = "Competición Profesional"
                        });
                });

            modelBuilder.Entity("EjercicioRutina", b =>
                {
                    b.HasOne("Obligatorio.Models.Ejercicio", null)
                        .WithMany()
                        .HasForeignKey("EjerciciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio.Models.Rutina", null)
                        .WithMany()
                        .HasForeignKey("RutinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Obligatorio.Models.Ejercicio", b =>
                {
                    b.HasOne("Obligatorio.Models.Maquina", "MaquinaNecesaria")
                        .WithMany()
                        .HasForeignKey("MaquinaNecesariaIdMaquina");

                    b.Navigation("MaquinaNecesaria");
                });

            modelBuilder.Entity("Obligatorio.Models.Local", b =>
                {
                    b.HasOne("Obligatorio.Models.Responsable", "Responsable")
                        .WithMany()
                        .HasForeignKey("ResponsableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsable");
                });

            modelBuilder.Entity("Obligatorio.Models.Maquina", b =>
                {
                    b.HasOne("Obligatorio.Models.Local", "Local")
                        .WithMany("Maquinas")
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio.Models.TipoDeMaquina", "TipoDeMaquina")
                        .WithMany("Maquinas")
                        .HasForeignKey("TipoDeMaquinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");

                    b.Navigation("TipoDeMaquina");
                });

            modelBuilder.Entity("Obligatorio.Models.Rutina", b =>
                {
                    b.HasOne("Obligatorio.Models.TipoRutina", "TipoRutina")
                        .WithMany("Rutinas")
                        .HasForeignKey("IdTipoRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoRutina");
                });

            modelBuilder.Entity("Obligatorio.Models.RutinaEjercicio", b =>
                {
                    b.HasOne("Obligatorio.Models.Ejercicio", "Ejercicio")
                        .WithMany("RutinaEjercicios")
                        .HasForeignKey("IdEjercicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio.Models.Rutina", "Rutina")
                        .WithMany("RutinaEjercicios")
                        .HasForeignKey("IdRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ejercicio");

                    b.Navigation("Rutina");
                });

            modelBuilder.Entity("Obligatorio.Models.Socio", b =>
                {
                    b.HasOne("Obligatorio.Models.Local", "LocalAsociado")
                        .WithMany("Socios")
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalAsociado");
                });

            modelBuilder.Entity("Obligatorio.Models.SocioRutina", b =>
                {
                    b.HasOne("Obligatorio.Models.Rutina", "Rutina")
                        .WithMany("SocioRutinas")
                        .HasForeignKey("IdRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio.Models.Socio", "Socio")
                        .WithMany("SocioRutinas")
                        .HasForeignKey("IdSocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rutina");

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("Obligatorio.Models.Ejercicio", b =>
                {
                    b.Navigation("RutinaEjercicios");
                });

            modelBuilder.Entity("Obligatorio.Models.Local", b =>
                {
                    b.Navigation("Maquinas");

                    b.Navigation("Socios");
                });

            modelBuilder.Entity("Obligatorio.Models.Rutina", b =>
                {
                    b.Navigation("RutinaEjercicios");

                    b.Navigation("SocioRutinas");
                });

            modelBuilder.Entity("Obligatorio.Models.Socio", b =>
                {
                    b.Navigation("SocioRutinas");
                });

            modelBuilder.Entity("Obligatorio.Models.TipoDeMaquina", b =>
                {
                    b.Navigation("Maquinas");
                });

            modelBuilder.Entity("Obligatorio.Models.TipoRutina", b =>
                {
                    b.Navigation("Rutinas");
                });
#pragma warning restore 612, 618
        }
    }
}
