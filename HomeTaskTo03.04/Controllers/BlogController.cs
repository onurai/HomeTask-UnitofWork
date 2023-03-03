using HomeTaskTo03._04.Data.Entity;
using HomeTaskTo03._04.Dto;
using HomeTaskTo03._04.UnitOfWork;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using HomeTaskTo03._04.Data.Context;

namespace HomeTaskTo03._04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BlogController> _logger;

        public BlogController(IUnitOfWork unitOfWork, ILogger<BlogController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Request accepted at {0}", DateTime.Now);
            var result = await _unitOfWork.blogRepository.GetAll()/*.ToListAsync()*/;
            _logger.LogWarning($"Request Successfully  completed at {DateTime.Now}, and result is {JsonSerializer.Serialize(result)}");
            return Ok(result);
        }

        [HttpPost]
        //public async Task<IActionResult> Create([FromBody] BlogDto blog)
        //{
        //    if (ModelState.IsValid != true)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Blog blog = new(
        //    {
        //        BlogName = blog.BlogName,
        //        Description = blog.Description,
        //        PostsCount = blog.PostsCount
        //    });
        //    await _unitOfWork.blogRepository.Add(blog);
        //    await _unitOfWork.Commit();

        //    return Ok(blog);
        //}

        [HttpPut]
        public async Task<IActionResult> Update(int id, string blogName, string description, int postsCount)
        {
            var blog = await _unitOfWork.blogRepository.Find(id);

            blog.BlogName = blogName;
            blog.Description = description; 
            blog.PostsCount = postsCount;

            await _unitOfWork.blogRepository.Update(blog);
            await _unitOfWork.Commit();
            return Ok(blog);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var result = await _unitOfWork.blogRepository.Find(id);
                _logger.LogInformation($"Blog got from db with Id of {id}");
                await _unitOfWork.blogRepository.Delete(result);
                _logger.LogDebug($"Blog deleted from db with Id of {id}");
                await _unitOfWork.Commit();
                _logger.LogInformation($"Request is completed successfully, Blog with ID of {id} and name of {result.BlogName}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured when deleting the blog i-th id of {id}");
                throw ex;
            }
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetId(int id)
        {
            var result = await _unitOfWork.blogRepository.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
