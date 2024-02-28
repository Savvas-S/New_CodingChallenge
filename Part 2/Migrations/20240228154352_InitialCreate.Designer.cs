﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectDb;

#nullable disable

namespace Test_part2.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20240228154352_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Container", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Shipid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Truckid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Shipid");

                    b.HasIndex("Truckid");

                    b.ToTable("Container");
                });

            modelBuilder.Entity("Ship", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Ship");
                });

            modelBuilder.Entity("Truck", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Truck");
                });

            modelBuilder.Entity("Container", b =>
                {
                    b.HasOne("Ship", null)
                        .WithMany("Containers")
                        .HasForeignKey("Shipid");

                    b.HasOne("Truck", null)
                        .WithMany("Containers")
                        .HasForeignKey("Truckid");
                });

            modelBuilder.Entity("Ship", b =>
                {
                    b.Navigation("Containers");
                });

            modelBuilder.Entity("Truck", b =>
                {
                    b.Navigation("Containers");
                });
#pragma warning restore 612, 618
        }
    }
}
