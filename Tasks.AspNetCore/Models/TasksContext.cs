using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.AspNetCore.Models
{
    public class TasksContext:DbContext
    {

        public DbSet<Itam> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLlocaldb;Database=Tasks;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Itam>().Property(b => b.Compleated).HasDefaultValue<bool>(false);
           


        }
    }
}
