﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanningPoker.Api.Data;

#nullable disable

namespace PlanningPoker.Api.Migrations
{
    [DbContext(typeof(PlanningPokerDbContext))]
    partial class PlanningPokerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3");

            modelBuilder.Entity("PlanningPoker.Api.Data.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test Story description from backend",
                            Title = "Test story from backend"
                        });
                });

            modelBuilder.Entity("PlanningPoker.Api.Data.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.ToTable("Votes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StoryId = 1,
                            Value = 420
                        },
                        new
                        {
                            Id = 2,
                            StoryId = 1,
                            Value = 555
                        });
                });

            modelBuilder.Entity("PlanningPoker.Api.Data.Vote", b =>
                {
                    b.HasOne("PlanningPoker.Api.Data.Story", "Story")
                        .WithMany("Votes")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("PlanningPoker.Api.Data.Story", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
