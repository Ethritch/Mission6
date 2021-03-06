using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class Tasks
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
       
        public bool Completed { get; set; }

        [ForeignKey("Category")]
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
