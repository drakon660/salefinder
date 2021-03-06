﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaleFinder.Domain;

namespace SaleFinder.Migrations
{
    [DbContext(typeof(SaleFinderDbContext))]
    partial class SaleFinderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("SaleFinder.Domain.LeafletModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DownloadUrl");

                    b.Property<string>("FileName");

                    b.Property<string>("GroupName");

                    b.Property<string>("Hash");

                    b.Property<DateTime>("SaleTime");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<int>("Week");

                    b.HasKey("Id");

                    b.ToTable("Leaflets");
                });

            modelBuilder.Entity("SaleFinder.Domain.LeafletPageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LeafletModelId");

                    b.Property<int>("PageNumber");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("LeafletModelId");

                    b.ToTable("LeafletPageModel");
                });

            modelBuilder.Entity("SaleFinder.Domain.LeafletPageModel", b =>
                {
                    b.HasOne("SaleFinder.Domain.LeafletModel", "LeafletModel")
                        .WithMany("Pages")
                        .HasForeignKey("LeafletModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
