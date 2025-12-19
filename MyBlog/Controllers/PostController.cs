using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            List<Post> posts = _context.Posts.ToList();
            TempData["Message"] = TempData["Message"];

            return View(posts);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create(Post post)
        {
            if (post == null)
            {

                return BadRequest("Post data invalid");
            }
            post.Media = "~/Imgs/Posts/laptop.jpg";
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}
