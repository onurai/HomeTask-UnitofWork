using HomeTaskTo03._04.Data.Entity;
using HomeTaskTo03._04.Repository;
using HomeTaskTo03._04.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace HomeTaskTo03._04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IRepository<Post, int> _postService;

        public PostController(IRepository<Post, int> bookService)
        {
            _postService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _postService.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(string title, string subtitle, string description, string content, int blogId)
        {
            await _postService.Add(new Post
            {
                Title = title,
                Subtitle = subtitle,
                Description = description,
                Content = content,
                BlogId = blogId,
                CreationDate = DateTime.Now,
            });
            await _postService.Commit();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string title, string subtitle, string description, string content, int blogId)
        {
            await _postService.Update(new Post
            {
                Title = title,
                Subtitle = subtitle,
                Description = description,
                Content = content,
                BlogId = blogId
            });
            await _postService.Commit();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var post = await _postService.Find(id);
            await _postService.Delete(post);
            await _postService.Commit();
            return Ok(post);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetId(int id)
        {
            var result = await _postService.Find(id);
            return Ok(result);
        }

        


       

        
    }
}
