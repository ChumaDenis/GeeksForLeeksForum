using System.ComponentModel.DataAnnotations;

namespace GeeksForLessForum.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int IdOfTopic { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public string Response { get; set; }
    }
}
