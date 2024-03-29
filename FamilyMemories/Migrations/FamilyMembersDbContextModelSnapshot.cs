﻿// <auto-generated />
using System;
using FamilyMemories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FamilyMemories.Migrations
{
    [DbContext(typeof(FamilyMembersDbContext))]
    partial class FamilyMembersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FamilyMemories.Models.Domain.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DocumentLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("FamilyMemories.Models.Domain.FamilyMember_Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int>("FamilyMemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("FamilyMemberId");

                    b.ToTable("FamilyMember_Documents");
                });

            modelBuilder.Entity("FamilyMemories.Models.Domain.FamilyMember_Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FamilyMemberId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamilyMemberId");

                    b.HasIndex("ImageId");

                    b.ToTable("FamilyMembers_Images");
                });

            modelBuilder.Entity("FamilyMemories.Models.Domain.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("FamilyMemories.Models.FamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ChildrenIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int?>("FatherId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
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

                    b.HasIndex("DocumentId");

                    b.HasIndex("ImageId");

                    b.ToTable("FamilyMembers");
                });

            modelBuilder.Entity("FamilyMemories.Models.Domain.FamilyMember_Document", b =>
                {
                    b.HasOne("FamilyMemories.Models.Domain.Document", "Document")
                        .WithMany("FamilyMember_Documents")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FamilyMemories.Models.FamilyMember", "FamilyMember")
                        .WithMany("FamilyMember_Documents")
                        .HasForeignKey("FamilyMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("FamilyMember");
                });

            modelBuilder.Entity("FamilyMemories.Models.Domain.FamilyMember_Image", b =>
                {
                    b.HasOne("FamilyMemories.Models.FamilyMember", "FamilyMember")
                        .WithMany("FamilyMember_Images")
                        .HasForeignKey("FamilyMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FamilyMemories.Models.Domain.Image", "Image")
                        .WithMany("FamilyMember_Images")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FamilyMember");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("FamilyMemories.Models.FamilyMember", b =>
                {
                    b.HasOne("FamilyMemories.Models.Domain.Document", null)
                        .WithMany("FamilyMembers")
                        .HasForeignKey("DocumentId");

                    b.HasOne("FamilyMemories.Models.Domain.Image", null)
                        .WithMany("FamilyMembers")
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("FamilyMemories.Models.Domain.Document", b =>
                {
                    b.Navigation("FamilyMember_Documents");

                    b.Navigation("FamilyMembers");
                });

            modelBuilder.Entity("FamilyMemories.Models.Domain.Image", b =>
                {
                    b.Navigation("FamilyMember_Images");

                    b.Navigation("FamilyMembers");
                });

            modelBuilder.Entity("FamilyMemories.Models.FamilyMember", b =>
                {
                    b.Navigation("FamilyMember_Documents");

                    b.Navigation("FamilyMember_Images");
                });
#pragma warning restore 612, 618
        }
    }
}
