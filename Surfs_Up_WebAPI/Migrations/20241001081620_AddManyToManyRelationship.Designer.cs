﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Surfs_Up_WebAPI.Data;

#nullable disable

namespace Surfs_Up_WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241001081620_AddManyToManyRelationship")]
    partial class AddManyToManyRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("AddonModelBookingModel", b =>
                {
                    b.Property<int>("AddonsID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookingsID")
                        .HasColumnType("TEXT");

                    b.HasKey("AddonsID", "BookingsID");

                    b.HasIndex("BookingsID");

                    b.ToTable("BookingAddon", (string)null);
                });

            modelBuilder.Entity("BookingModelEquipmentModel", b =>
                {
                    b.Property<string>("BookingsID")
                        .HasColumnType("TEXT");

                    b.Property<int>("EquipmentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookingsID", "EquipmentID");

                    b.HasIndex("EquipmentID");

                    b.ToTable("BookingEquipment", (string)null);
                });

            modelBuilder.Entity("BookingModelSuitModel", b =>
                {
                    b.Property<string>("BookingsID")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuitsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookingsID", "SuitsID");

                    b.HasIndex("SuitsID");

                    b.ToTable("BookingSuit", (string)null);
                });

            modelBuilder.Entity("Surfs_Up_WebAPI.Models.AddonModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Addon");
                });

            modelBuilder.Entity("Surfs_Up_WebAPI.Models.BookingModel", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Phone")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Surfs_Up_WebAPI.Models.EquipmentModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Length")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<double>("Thickness")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Volume")
                        .HasColumnType("REAL");

                    b.Property<double>("Width")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Surfs_Up_WebAPI.Models.SuitModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Sizes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Suits");
                });

            modelBuilder.Entity("AddonModelBookingModel", b =>
                {
                    b.HasOne("Surfs_Up_WebAPI.Models.AddonModel", null)
                        .WithMany()
                        .HasForeignKey("AddonsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Surfs_Up_WebAPI.Models.BookingModel", null)
                        .WithMany()
                        .HasForeignKey("BookingsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingModelEquipmentModel", b =>
                {
                    b.HasOne("Surfs_Up_WebAPI.Models.BookingModel", null)
                        .WithMany()
                        .HasForeignKey("BookingsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Surfs_Up_WebAPI.Models.EquipmentModel", null)
                        .WithMany()
                        .HasForeignKey("EquipmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingModelSuitModel", b =>
                {
                    b.HasOne("Surfs_Up_WebAPI.Models.BookingModel", null)
                        .WithMany()
                        .HasForeignKey("BookingsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Surfs_Up_WebAPI.Models.SuitModel", null)
                        .WithMany()
                        .HasForeignKey("SuitsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
