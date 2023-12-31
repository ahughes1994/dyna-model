﻿// <auto-generated />
using System;
using DynaModel.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DynaModel.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DynaModel.Models.BoolProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Value")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("BoolProperty", (string)null);
                });

            modelBuilder.Entity("DynaModel.Models.FloatProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("FloatProperty", (string)null);
                });

            modelBuilder.Entity("DynaModel.Models.IntProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("IntProperty", (string)null);
                });

            modelBuilder.Entity("DynaModel.Models.Parent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Parents", (string)null);
                });

            modelBuilder.Entity("DynaModel.Models.StringProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("StringProperty", (string)null);
                });

            modelBuilder.Entity("DynaModel.Models.BoolProperty", b =>
                {
                    b.HasOne("DynaModel.Models.Parent", null)
                        .WithMany("BoolProperties")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DynaModel.Models.FloatProperty", b =>
                {
                    b.HasOne("DynaModel.Models.Parent", null)
                        .WithMany("FloatProperties")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DynaModel.Models.IntProperty", b =>
                {
                    b.HasOne("DynaModel.Models.Parent", null)
                        .WithMany("IntProperties")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DynaModel.Models.StringProperty", b =>
                {
                    b.HasOne("DynaModel.Models.Parent", null)
                        .WithMany("StringProperties")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DynaModel.Models.Parent", b =>
                {
                    b.Navigation("BoolProperties");

                    b.Navigation("FloatProperties");

                    b.Navigation("IntProperties");

                    b.Navigation("StringProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
