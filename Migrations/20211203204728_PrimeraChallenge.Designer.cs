﻿// <auto-generated />
using System;
using Challenge.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Challenge.Migrations
{
    [DbContext(typeof(ChallengeContext))]
    [Migration("20211203204728_PrimeraChallenge")]
    partial class PrimeraChallenge
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Disney")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Challenge.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Challenge.Entities.PeliculaSerie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calificaion")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("PeliculasSeries");
                });

            modelBuilder.Entity("Challenge.Entities.Personaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Historia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Personajes");
                });

            modelBuilder.Entity("PeliculaSeriePersonaje", b =>
                {
                    b.Property<int>("PeliculaSerieAsociadaId")
                        .HasColumnType("int");

                    b.Property<int>("PersonajesAsociadosId")
                        .HasColumnType("int");

                    b.HasKey("PeliculaSerieAsociadaId", "PersonajesAsociadosId");

                    b.HasIndex("PersonajesAsociadosId");

                    b.ToTable("PeliculaSeriePersonaje");
                });

            modelBuilder.Entity("Challenge.Entities.PeliculaSerie", b =>
                {
                    b.HasOne("Challenge.Entities.Genero", null)
                        .WithMany("PeliculaSerieAsociada")
                        .HasForeignKey("GeneroId");
                });

            modelBuilder.Entity("PeliculaSeriePersonaje", b =>
                {
                    b.HasOne("Challenge.Entities.PeliculaSerie", null)
                        .WithMany()
                        .HasForeignKey("PeliculaSerieAsociadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Challenge.Entities.Personaje", null)
                        .WithMany()
                        .HasForeignKey("PersonajesAsociadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Challenge.Entities.Genero", b =>
                {
                    b.Navigation("PeliculaSerieAsociada");
                });
#pragma warning restore 612, 618
        }
    }
}
