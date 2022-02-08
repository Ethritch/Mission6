using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            // this can stay blank
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }

                );

            mb.Entity<Tasks>().HasData(
                new Tasks { TaskID = -2, TaskName ="Get Help From Jenna", DueDate = new DateTime(2022, 02, 11, 1, 14, 50), Quadrant = 2, CategoryID = 1, Completed = true },
                new Tasks { TaskID = -1, TaskName = "Get Help From Hannah", DueDate = new DateTime(2022, 02, 17, 1, 14, 50), Quadrant = 2, CategoryID = 3,Completed = false }
                );

        }
    }
}
