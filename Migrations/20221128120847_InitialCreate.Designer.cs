﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using c_sherp_project_api.Contexts;

#nullable disable

namespace c_sherp_project_api.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20221128120847_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("c_sherp_project_api.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<uint>("Score")
                        .HasColumnType("int unsigned");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("c_sherp_project_api.Models.LeaderBoard", b =>
                {
                    b.Property<int>("LeaderBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("on")
                        .HasColumnType("datetime(6)");

                    b.HasKey("LeaderBoardId");

                    b.HasIndex("GameId");

                    b.ToTable("LeaderBoard");
                });

            modelBuilder.Entity("c_sherp_project_api.Models.LeaderBoard", b =>
                {
                    b.HasOne("c_sherp_project_api.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });
#pragma warning restore 612, 618
        }
    }
}
