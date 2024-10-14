﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartBin.Infrastructure.Domain.Context;

#nullable disable

namespace SmartBin.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Bin.Bin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Battery")
                        .HasColumnType("float");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longtitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Bins");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Bin.BinUnit", b =>
                {
                    b.Property<string>("BinUnitId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BinId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EngineError")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastCollected")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("BinUnitId");

                    b.HasIndex("BinId");

                    b.ToTable("BinUnits");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Histories.CollectedHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BinUnitId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CollectedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BinUnitId");

                    b.ToTable("CollectedHistories");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Histories.LoginHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginHistories");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Histories.PointChangedHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NewPoint")
                        .HasColumnType("int");

                    b.Property<int>("OldPoint")
                        .HasColumnType("int");

                    b.Property<DateTime>("PointChangedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PointChangedHistories");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Person.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("HomeTown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IssuanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Bin.BinUnit", b =>
                {
                    b.HasOne("SmartBin.Infrastructure.Domain.Models.Bin.Bin", "Bin")
                        .WithMany("BinUnits")
                        .HasForeignKey("BinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bin");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Histories.CollectedHistory", b =>
                {
                    b.HasOne("SmartBin.Infrastructure.Domain.Models.Bin.BinUnit", "BinUnit")
                        .WithMany("CollectedHistories")
                        .HasForeignKey("BinUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BinUnit");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Histories.LoginHistory", b =>
                {
                    b.HasOne("SmartBin.Infrastructure.Domain.Models.Person.User", "User")
                        .WithMany("LoginHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Histories.PointChangedHistory", b =>
                {
                    b.HasOne("SmartBin.Infrastructure.Domain.Models.Person.User", "User")
                        .WithMany("PointChangedHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Bin.Bin", b =>
                {
                    b.Navigation("BinUnits");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Bin.BinUnit", b =>
                {
                    b.Navigation("CollectedHistories");
                });

            modelBuilder.Entity("SmartBin.Infrastructure.Domain.Models.Person.User", b =>
                {
                    b.Navigation("LoginHistories");

                    b.Navigation("PointChangedHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
