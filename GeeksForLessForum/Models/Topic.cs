
using System.ComponentModel.DataAnnotations;

namespace GeeksForLessForum.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null;
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string UserName { get; set; } = "";

    }
}
