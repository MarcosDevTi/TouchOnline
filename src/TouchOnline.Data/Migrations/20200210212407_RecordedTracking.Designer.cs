﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TouchOnline.Data;

namespace TouchOnline.Data.Migrations
{
    [DbContext(typeof(ToContext))]
    [Migration("20200210212407_RecordedTracking")]
    partial class RecordedTracking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TouchOnline.Domain.Result", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Errors")
                        .HasColumnType("integer");

                    b.Property<int>("IdLesson")
                        .HasColumnType("integer");

                    b.Property<int>("Ppm")
                        .HasColumnType("integer");

                    b.Property<int>("Stars")
                        .HasColumnType("integer");

                    b.Property<int>("Time")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("TouchOnline.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime>("InscriptionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TouchOnline.Domain.UserTracking.RecordedTracking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("VisitedPages")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GetRecordeds");
                });

            modelBuilder.Entity("TouchOnline.Domain.Result", b =>
                {
                    b.HasOne("TouchOnline.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TouchOnline.Domain.UserTracking.RecordedTracking", b =>
                {
                    b.OwnsOne("TouchOnline.Domain.Tracking.UserLocal", "UserLocal", b1 =>
                        {
                            b1.Property<Guid>("RecordedTrackingId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("character varying(120)")
                                .HasMaxLength(120);

                            b1.Property<string>("ContinentCode")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("ContinentName")
                                .HasColumnType("character varying(120)")
                                .HasMaxLength(120);

                            b1.Property<string>("CountryCode")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("CountryName")
                                .HasColumnType("character varying(120)")
                                .HasMaxLength(120);

                            b1.Property<double>("Latitude")
                                .HasColumnType("double precision");

                            b1.Property<double>("Longitude")
                                .HasColumnType("double precision");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("character varying(50)")
                                .HasMaxLength(50);

                            b1.HasKey("RecordedTrackingId");

                            b1.ToTable("GetRecordeds");

                            b1.WithOwner()
                                .HasForeignKey("RecordedTrackingId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}