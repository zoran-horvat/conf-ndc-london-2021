﻿// <auto-generated />
using Demo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.Migrations
{
    [DbContext(typeof(EntireContext))]
    [Migration("20210117230134_SeededProducts")]
    partial class SeededProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Demo.Models.Authentication.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users","Authentication");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "DFE27E47-2BBE-4C7D-B419-25AC7835881F",
                            UserName = "me"
                        },
                        new
                        {
                            Id = 2,
                            Key = "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55",
                            UserName = "neighbor"
                        });
                });

            modelBuilder.Entity("Demo.Models.Content.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products","Content");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "one",
                            OwnerKey = "DFE27E47-2BBE-4C7D-B419-25AC7835881F"
                        },
                        new
                        {
                            Id = 2,
                            Name = "two",
                            OwnerKey = "DFE27E47-2BBE-4C7D-B419-25AC7835881F"
                        },
                        new
                        {
                            Id = 3,
                            Name = "three",
                            OwnerKey = "DFE27E47-2BBE-4C7D-B419-25AC7835881F"
                        },
                        new
                        {
                            Id = 4,
                            Name = "square",
                            OwnerKey = "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55"
                        },
                        new
                        {
                            Id = 5,
                            Name = "pointy",
                            OwnerKey = "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55"
                        },
                        new
                        {
                            Id = 6,
                            Name = "round",
                            OwnerKey = "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
