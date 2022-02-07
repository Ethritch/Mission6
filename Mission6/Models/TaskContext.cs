using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext (DbContextOptions<TaskContext> options) : base(options)
        {
            // this can stay blank
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

    }
}
