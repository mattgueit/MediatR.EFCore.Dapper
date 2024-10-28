﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TrainTickets.Infrastructure.Storage.Database.EntityFramework;

#nullable disable

namespace TrainTickets.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241028034252_AddExpiryDateToTicket")]
    partial class AddExpiryDateToTicket
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TrainTickets.Core.Domain.Journeys.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TrainId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("TrainTickets.Core.Domain.Passengers.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("TrainTickets.Core.Domain.Tickets.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("JourneyId")
                        .HasColumnType("integer");

                    b.Property<int>("PassengerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TrainTickets.Core.Domain.Trains.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Built")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Trains");
                });
#pragma warning restore 612, 618
        }
    }
}