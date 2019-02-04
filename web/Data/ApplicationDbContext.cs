using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Models;

namespace web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ItemList> ItemList { get; set; }
        public DbSet<LearningResource> LearningResource { get; set; }
        public DbSet<ResourceCatalog> ResourceCatalog { get; set; }
        public DbSet<ResourceRoot> ResourceRoot { get; set; }
        public DbSet<RssFeed> RssFeed { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LearningResourceItemList>()
                .HasKey(r => new { r.LearningResourceId, r.ItemListId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
