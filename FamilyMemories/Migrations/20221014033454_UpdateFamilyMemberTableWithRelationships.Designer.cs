﻿// <auto-generated />
using System;
using FamilyMemories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FamilyMemories.Migrations
{
    [DbContext(typeof(FamilyMembersDbContext))]
    [Migration("20221014033454_UpdateFamilyMemberTableWithRelationships")]
    partial class UpdateFamilyMemberTableWithRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FamilyMemories.Models.FamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ChildrenIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FatherId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotherId")
                        .HasColumnType("int");

                    b.Property<string>("SiblingIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FamilyMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
