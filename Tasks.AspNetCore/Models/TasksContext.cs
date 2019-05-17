using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.AspNetCore.Models
{
    public class TasksContext:DbContext
    {

        public TasksContext(DbContextOptions<TasksContext> options):base(options)
        {

        }

        public DbSet<Itam> Tasks { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Itam>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).HasDefaultValueSql("(newid())");
                e.Property(p => p.Title).IsRequired();
                e.Property(p => p.Title).IsRequired().HasDefaultValue(false);
            });
           


        }
    }
}
