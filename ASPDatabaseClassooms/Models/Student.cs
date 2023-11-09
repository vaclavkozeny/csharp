using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public int ShoeSize { get; set; }
        //[Required]
        //[ForeignKey("classroomId")]
        public Classroom Classroom { get; set; } //navigation property
        [Required]
        public int ClassroomId { get; set; }

    }
}
