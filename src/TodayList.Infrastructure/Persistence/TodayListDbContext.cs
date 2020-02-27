using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodayList.Application.Common.Interfaces;
using TodayList.Domain.Common;
using TodayList.Domain.Entities;

namespace TodayList.Infrastructure.Persistence
{
    public class TodayListDbContext : DbContext, ITodayListDbContext
    {
        public TodayListDbContext(DbContextOptions<TodayListDbContext> options) : base(options)
        {
        }
        
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Label> Labels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany<Assignment>(p => p.Assignments)
                .WithOne(a => a.Project)
                .HasForeignKey(p => p.ProjectId);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.UtcNow;
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}