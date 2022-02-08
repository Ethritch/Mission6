using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class Tasks
    {
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public int Quandrant { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Category CategoryName { get; set; }
        public bool Completed { get; set; }
    }
}
