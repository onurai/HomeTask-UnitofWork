﻿// <auto-generated />
using System;
using HomeTaskTo03._04.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeTaskTo03._04.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230304093625_FluentApiAdded")]
    partial class FluentApiAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HomeTaskTo03._04.Data.Entity.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Description");

                    b.Property<int>("PostsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogName")
                        .IsUnique();

                    b.ToTable("tblBlog", (string)null);
                });

            modelBuilder.Entity("HomeTaskTo03._04.Data.Entity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Content");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 3, 4, 13, 36, 24, 999, DateTimeKind.Local).AddTicks(1247));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Description");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Subtitle");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("tblPost", (string)null);
                });

            modelBuilder.Entity("HomeTaskTo03._04.Data.Entity.Post", b =>
                {
                    b.HasOne("HomeTaskTo03._04.Data.Entity.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("HomeTaskTo03._04.Data.Entity.Blog", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
