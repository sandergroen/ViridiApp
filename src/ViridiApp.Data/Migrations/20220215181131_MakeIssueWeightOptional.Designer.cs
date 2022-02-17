﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ViridiApp.Data;

#nullable disable

namespace ViridiApp.Data.Migrations
{
    [DbContext(typeof(ViridiContext))]
    [Migration("20220215181131_MakeIssueWeightOptional")]
    partial class MakeIssueWeightOptional
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ViridiApp.Domain.Projects.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Epic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Epics");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("EpicId")
                        .HasColumnType("integer");

                    b.Property<int?>("MilestoneId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int?>("SectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EpicId");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SectionId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Iteration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Iterations");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Milestone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Issue", b =>
                {
                    b.HasOne("ViridiApp.Domain.Projects.Epic", "Epic")
                        .WithMany("Issues")
                        .HasForeignKey("EpicId");

                    b.HasOne("ViridiApp.Domain.Projects.Milestone", "Milestone")
                        .WithMany("Issues")
                        .HasForeignKey("MilestoneId");

                    b.HasOne("ViridiApp.Domain.Projects.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViridiApp.Domain.Projects.Section", null)
                        .WithMany("Issues")
                        .HasForeignKey("SectionId");

                    b.Navigation("Epic");

                    b.Navigation("Milestone");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Section", b =>
                {
                    b.HasOne("ViridiApp.Domain.Projects.Board", "Board")
                        .WithMany("Sections")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Board", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Epic", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Milestone", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Project", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("ViridiApp.Domain.Projects.Section", b =>
                {
                    b.Navigation("Issues");
                });
#pragma warning restore 612, 618
        }
    }
}