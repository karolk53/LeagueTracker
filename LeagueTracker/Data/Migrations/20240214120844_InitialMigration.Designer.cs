﻿// <auto-generated />
using System;
using LeagueTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeagueTracker.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240214120844_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.16");

            modelBuilder.Entity("ClubLeagueStatistics", b =>
                {
                    b.Property<int>("ClubsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeagueStatisticsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClubsId", "LeagueStatisticsId");

                    b.HasIndex("LeagueStatisticsId");

                    b.ToTable("ClubLeagueStatistics");
                });

            modelBuilder.Entity("LeagueTracker.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("LeagueTracker.Models.ClubStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LostMatches")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayedMatches")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeasonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TiedMatches")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WonMatches")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("SeasonId");

                    b.ToTable("ClubStatistics");
                });

            modelBuilder.Entity("LeagueTracker.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("LeagueTracker.Models.LeagueStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MostGoalsPlayer")
                        .HasColumnType("TEXT");

                    b.Property<int>("SeasonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("SeasonId");

                    b.ToTable("LeagueStatistics");
                });

            modelBuilder.Entity("LeagueTracker.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GuestName")
                        .HasColumnType("TEXT");

                    b.Property<int>("HomeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HomeName")
                        .HasColumnType("TEXT");

                    b.Property<int>("SeasonId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("HomeId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("LeagueTracker.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartYear")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("ClubLeagueStatistics", b =>
                {
                    b.HasOne("LeagueTracker.Models.Club", null)
                        .WithMany()
                        .HasForeignKey("ClubsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeagueTracker.Models.LeagueStatistics", null)
                        .WithMany()
                        .HasForeignKey("LeagueStatisticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueTracker.Models.ClubStatistics", b =>
                {
                    b.HasOne("LeagueTracker.Models.Club", "Club")
                        .WithMany("ClubStatistics")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeagueTracker.Models.Season", "Season")
                        .WithMany("ClubStatistics")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("LeagueTracker.Models.LeagueStatistics", b =>
                {
                    b.HasOne("LeagueTracker.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeagueTracker.Models.Season", "Season")
                        .WithMany("LeagueStatistics")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("LeagueTracker.Models.Match", b =>
                {
                    b.HasOne("LeagueTracker.Models.Club", "Guest")
                        .WithMany("GuestMatches")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeagueTracker.Models.Club", "Home")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeagueTracker.Models.Season", "Season")
                        .WithMany("Matches")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Home");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("LeagueTracker.Models.Club", b =>
                {
                    b.Navigation("ClubStatistics");

                    b.Navigation("GuestMatches");

                    b.Navigation("HomeMatches");
                });

            modelBuilder.Entity("LeagueTracker.Models.Season", b =>
                {
                    b.Navigation("ClubStatistics");

                    b.Navigation("LeagueStatistics");

                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
