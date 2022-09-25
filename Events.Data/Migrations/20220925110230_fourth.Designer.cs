﻿// <auto-generated />
using System;
using Events.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Events.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220925110230_fourth")]
    partial class fourth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Events.Data.Entities.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("Postcode")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Events.Data.Entities.EventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Events.Data.Entities.OrganizerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("Events.Data.Entities.PlanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("Events.Data.Entities.SpeakerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Events.Data.Entities.SpeechEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpeakerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Speeches");
                });

            modelBuilder.Entity("Events.Data.Entities.AddressEntity", b =>
                {
                    b.HasOne("Events.Data.Entities.EventEntity", "Event")
                        .WithOne("Address")
                        .HasForeignKey("Events.Data.Entities.AddressEntity", "EventId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Events.Data.Entities.EventEntity", b =>
                {
                    b.HasOne("Events.Data.Entities.OrganizerEntity", "Organizer")
                        .WithMany("Events")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("Events.Data.Entities.PlanEntity", b =>
                {
                    b.HasOne("Events.Data.Entities.EventEntity", "Event")
                        .WithOne("Plan")
                        .HasForeignKey("Events.Data.Entities.PlanEntity", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Events.Data.Entities.SpeechEntity", b =>
                {
                    b.HasOne("Events.Data.Entities.PlanEntity", "Plan")
                        .WithMany("Speeches")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Events.Data.Entities.SpeakerEntity", "Speaker")
                        .WithMany("Speeches")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("Events.Data.Entities.EventEntity", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Events.Data.Entities.OrganizerEntity", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Events.Data.Entities.PlanEntity", b =>
                {
                    b.Navigation("Speeches");
                });

            modelBuilder.Entity("Events.Data.Entities.SpeakerEntity", b =>
                {
                    b.Navigation("Speeches");
                });
#pragma warning restore 612, 618
        }
    }
}
