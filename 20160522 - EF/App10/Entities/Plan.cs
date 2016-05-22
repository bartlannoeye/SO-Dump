using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace App10.Entities
{
    public class Plan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanId { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<PlanItem> PlanItems { get; set; }
    }

    public class PlanItem
    {
        public int PlanItemId { get; set; }
        public string Description { get; set; }
        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }

    }


    class PlanContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanItem> PlanItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("test.sql");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>().
                Property(b => b.PlanId).IsRequired();

            modelBuilder.Entity<PlanItem>().
                Property(b => b.PlanItemId).IsRequired();
        }
    }
}
