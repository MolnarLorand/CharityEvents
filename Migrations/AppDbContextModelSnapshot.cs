﻿// <auto-generated />
using System;
using CharityEvents.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CharityEvents.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CharityEvents.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BandCategory")
                        .HasColumnType("int");

                    b.Property<string>("BandMembers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CharityCauseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConcertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DonationPrice")
                        .HasColumnType("float");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharityCauseId");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("CharityEvents.Models.CharityCause", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CharityCauses");
                });

            modelBuilder.Entity("CharityEvents.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventPeriod")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CharityEvents.Models.Event_Band", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "BandId");

                    b.HasIndex("BandId");

                    b.ToTable("Events_Bands");
                });

            modelBuilder.Entity("CharityEvents.Models.Band", b =>
                {
                    b.HasOne("CharityEvents.Models.CharityCause", "CharityCause")
                        .WithMany("Bands")
                        .HasForeignKey("CharityCauseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharityCause");
                });

            modelBuilder.Entity("CharityEvents.Models.Event_Band", b =>
                {
                    b.HasOne("CharityEvents.Models.Band", "Band")
                        .WithMany("Events_Bands")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CharityEvents.Models.Event", "Event")
                        .WithMany("Events_Bands")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("CharityEvents.Models.Band", b =>
                {
                    b.Navigation("Events_Bands");
                });

            modelBuilder.Entity("CharityEvents.Models.CharityCause", b =>
                {
                    b.Navigation("Bands");
                });

            modelBuilder.Entity("CharityEvents.Models.Event", b =>
                {
                    b.Navigation("Events_Bands");
                });
#pragma warning restore 612, 618
        }
    }
}
