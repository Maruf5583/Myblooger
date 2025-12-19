using MyBlog.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 150 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [StringLength(1500, MinimumLength = 5, ErrorMessage = "Content must be between 5 and 1500 characters.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Slug is required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "slug must be between 5 and 30 characters.")]
        public string Slug { get; set; }

     
        public string Media { get; set; } 



        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

        public DateTime PublishedAt { get; set; }


        public  Status Status { get; set; }


        public int CategoryId { get; set; }

        public int UserId { get; set; }


        public Post()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            PublishedAt = DateTime.Now;
            Media = "~/Imgs/Posts/laptop.jpg";

            UserId = 1;
            CategoryId = 1;
        }
    }
}

