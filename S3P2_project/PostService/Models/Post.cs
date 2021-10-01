using System.ComponentModel.DataAnnotations;

namespace PostService.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        //public string FilePath { get; set; }
    }
}
