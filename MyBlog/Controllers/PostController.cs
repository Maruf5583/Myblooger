using Microsoft.AspNetCore.Identity;
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                TempData["Error"] = "Invalid post ID";
                return RedirectToAction(nameof(List));
            }

            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                TempData["Error"] = "Post not found or already deleted!";
            }
            else
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"\"{post.Title}\" deleted successfully!";
            }

            return RedirectToAction(nameof(List));
        }

    }
}
