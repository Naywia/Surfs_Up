﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurfsUp.Data;

#nullable disable

namespace SurfsUp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("SurfsUp.Models.AddonModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("DetailModelID")
                        .HasColumnType("INTEGER");

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

                    b.HasIndex("DetailModelID");

                    b.ToTable("Addon");
                });

            modelBuilder.Entity("SurfsUp.Models.BookingModel", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EquipmentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("Phone")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("SurfsUp.Models.DetailModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("DetailModel");
                });

            modelBuilder.Entity("SurfsUp.Models.EquipmentModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DetailModelID")
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

                    b.HasIndex("DetailModelID");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("SurfsUp.Models.SuitModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("DetailModelID")
                        .HasColumnType("INTEGER");

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

                    b.HasIndex("DetailModelID");

                    b.ToTable("Suits");
                });

            modelBuilder.Entity("SurfsUp.Models.AddonModel", b =>
                {
                    b.HasOne("SurfsUp.Models.DetailModel", null)
                        .WithMany("Addons")
                        .HasForeignKey("DetailModelID");
                });

            modelBuilder.Entity("SurfsUp.Models.BookingModel", b =>
                {
                    b.HasOne("SurfsUp.Models.DetailModel", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentID");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("SurfsUp.Models.EquipmentModel", b =>
                {
                    b.HasOne("SurfsUp.Models.DetailModel", null)
                        .WithMany("Equipment")
                        .HasForeignKey("DetailModelID");
                });

            modelBuilder.Entity("SurfsUp.Models.SuitModel", b =>
                {
                    b.HasOne("SurfsUp.Models.DetailModel", null)
                        .WithMany("Suits")
                        .HasForeignKey("DetailModelID");
                });

            modelBuilder.Entity("SurfsUp.Models.DetailModel", b =>
                {
                    b.Navigation("Addons");

                    b.Navigation("Equipment");

                    b.Navigation("Suits");
                });
#pragma warning restore 612, 618
        }
    }
}
