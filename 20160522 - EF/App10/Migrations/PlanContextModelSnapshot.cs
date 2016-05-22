using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using App10.Entities;

namespace App10.Migrations
{
    [DbContext(typeof(PlanContext))]
    partial class PlanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896");

            modelBuilder.Entity("App10.Entities.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("PlanId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("App10.Entities.PlanItem", b =>
                {
                    b.Property<int>("PlanItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<int>("PlanId");

                    b.Property<string>("Type");

                    b.HasKey("PlanItemId");

                    b.HasIndex("PlanId");

                    b.ToTable("PlanItems");
                });

            modelBuilder.Entity("App10.Entities.PlanItem", b =>
                {
                    b.HasOne("App10.Entities.Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
