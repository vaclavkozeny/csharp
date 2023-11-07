using System.ComponentModel.DataAnnotations;

namespace Ukol_init_3.Model
{
    public class ForumThread
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Název vlákna")]
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
    }
}
