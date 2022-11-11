using FamilyMemories.Models;
using FamilyMemories.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FamilyMemories.Data
{
    public class FamilyMembersDbContext : DbContext
    {
        public FamilyMembersDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<FamilyMember_Image> FamilyMembers_Images { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<FamilyMember_Document> FamilyMember_Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyMember_Image>()
                .HasOne(fm => fm.FamilyMember)
                .WithMany(fmi => fmi.FamilyMember_Images)
                .HasForeignKey(fm => fm.FamilyMemberId);

            modelBuilder.Entity<FamilyMember_Image>()
                .HasOne(fm => fm.Image)
                .WithMany(fmi => fmi.FamilyMember_Images)
                .HasForeignKey(fm => fm.ImageId);


            modelBuilder.Entity<FamilyMember_Document>()
                .HasOne(fm => fm.FamilyMember)
                .WithMany(fmi => fmi.FamilyMember_Documents)
                .HasForeignKey(fm => fm.FamilyMemberId);

            modelBuilder.Entity<FamilyMember_Document>()
                .HasOne(fm => fm.Document)
                .WithMany(fmi => fmi.FamilyMember_Documents)
                .HasForeignKey(fm => fm.DocumentId);
        }
    }
}
