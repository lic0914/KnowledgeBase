using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Infrastracture
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DocType>();
            modelBuilder.Entity<Tag>().HasOne(e => e.DocType).WithMany().HasForeignKey(e => e.DocTypeId);
            var doc = modelBuilder.Entity<Document>();

            modelBuilder.Entity<DocumentTag>().HasKey(t => new { t.DocumentId, t.TagId });
            modelBuilder.Entity<DocumentTag>().HasOne(e => e.Tag).WithMany(e => e.DocumentTags).HasForeignKey(e => e.TagId);
            modelBuilder.Entity<DocumentTag>().HasOne(e => e.Document).WithMany(e => e.DocumentTags).HasForeignKey(e => e.DocumentId);


        }
        public DbSet<DocType> DocType { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentTag> DocumentTag { get; set; }

    }
}
