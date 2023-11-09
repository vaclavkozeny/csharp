using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database2.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Název")]
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
