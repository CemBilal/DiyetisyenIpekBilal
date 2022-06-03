﻿// <auto-generated />
using DiyetisyenIpekBilal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiyetisyenIpekBilal.Migrations
{
    [DbContext(typeof(DytIpekBilalDBContext))]
    [Migration("20220602205645_dort")]
    partial class dort
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.AboutMe", b =>
                {
                    b.Property<int>("AboutMeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutMeID"), 1L, 1);

                    b.Property<string>("AboutMee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titlee")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutMeID");

                    b.ToTable("AboutMe");
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Achievement", b =>
                {
                    b.Property<int>("AchievementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AchievementID"), 1L, 1);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AchievementID");

                    b.ToTable("Achievement");
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Ingredients", b =>
                {
                    b.Property<int>("IngredientsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientsID"), 1L, 1);

                    b.Property<string>("IngredientsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeID")
                        .HasColumnType("int");

                    b.HasKey("IngredientsID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Instructions", b =>
                {
                    b.Property<int>("InstructionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionID"), 1L, 1);

                    b.Property<string>("InstructionSen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeID")
                        .HasColumnType("int");

                    b.HasKey("InstructionID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeID"), 1L, 1);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Rolee", b =>
                {
                    b.Property<int>("RoleeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleeID"), 1L, 1);

                    b.Property<string>("RoleeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleeID");

                    b.ToTable("Rolees");

                    b.HasData(
                        new
                        {
                            RoleeID = 1,
                            RoleeName = "Admin"
                        },
                        new
                        {
                            RoleeID = 2,
                            RoleeName = "Anonim"
                        },
                        new
                        {
                            RoleeID = 3,
                            RoleeName = "Danışan"
                        });
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Userr", b =>
                {
                    b.Property<int>("UserrID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserrID"), 1L, 1);

                    b.Property<string>("Emaill")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RoleeID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserrID");

                    b.HasIndex("RoleeID");

                    b.ToTable("Userrs");

                    b.HasData(
                        new
                        {
                            UserrID = 1,
                            Emaill = "admin123@hotmail.com",
                            ImagePath = "~/AdminTemplate/images/avatar/1.jpg",
                            Name = "İpek",
                            Password = "Test123!",
                            PhoneNumber = "5459552815",
                            RoleeID = 1,
                            Surname = "Bilal"
                        });
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Ingredients", b =>
                {
                    b.HasOne("DiyetisyenIpekBilal.Models.Recipe", "recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("recipe");
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Instructions", b =>
                {
                    b.HasOne("DiyetisyenIpekBilal.Models.Recipe", "recipe")
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("recipe");
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Userr", b =>
                {
                    b.HasOne("DiyetisyenIpekBilal.Models.Rolee", "Rolee")
                        .WithMany()
                        .HasForeignKey("RoleeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rolee");
                });

            modelBuilder.Entity("DiyetisyenIpekBilal.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}
