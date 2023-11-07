using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ukol_init_3.Model
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Zpráva")]
        public string Message { get; set; }
        public int ThreadId { get; set; }
        public ForumThread Thread { get; set; }
        public ApplicationUser User { get; set; }
    }
}
