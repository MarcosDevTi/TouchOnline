﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TouchOnline.Data;

namespace TouchOnline.Data.Migrations
{
    [DbContext(typeof(ToContext))]
    partial class ToContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TouchOnline.Domain.Keyboard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("CodeKeys")
                        .HasColumnType("text");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<string>("KeycodesBeginners")
                        .HasColumnType("text");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Keyboards");
                });

            modelBuilder.Entity("TouchOnline.Domain.LessonText", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LessonTexts");
                });

            modelBuilder.Entity("TouchOnline.Domain.MessageSupport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("MessageSupports");
                });

            modelBuilder.Entity("TouchOnline.Domain.MyText", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CodeLesson")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("MyTexts");
                });

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

                    b.Property<string>("LanguageKeyboard")
                        .HasColumnType("text");

                    b.Property<string>("LanguageLessons")
                        .HasColumnType("text");

                    b.Property<string>("LanguageSystem")
                        .HasColumnType("text");

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

                    b.Property<string>("Ip")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("VisitedPages")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GetRecordeds");
                });

            modelBuilder.Entity("TouchOnline.Domain.LessonText", b =>
                {
                    b.HasOne("TouchOnline.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TouchOnline.Domain.Result", b =>
                {
                    b.HasOne("TouchOnline.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
