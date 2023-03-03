using HomeTaskTo03._04.Data.Entity;
using HomeTaskTo03._04.Dto;
using HomeTaskTo03._04.Repository;
using HomeTaskTo03._04.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Text.Json;

namespace HomeTaskTo03._04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PostController> _logger;

        public PostController(IUnitOfWork unitOfWork, ILogger<PostController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Request accepted at {0}", DateTime.Now);
            var result = await _unitOfWork.postRepository.GetAll()/*.ToListAsync()*/;
            _logger.LogWarning($"Request Successfully  completed at {DateTime.Now}, and result is {JsonSerializer.Serialize(result)}");
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostDto postDto)
        {
            Post post = new ()
            {
                Title = postDto.Title,
                Subtitle = postDto.Subtitle,
                Description = postDto.Description,
                Content = postDto.Content,
                BlogId = postDto.BlogId,
            };
            await _unitOfWork.postRepository.Add(post);
            await _unitOfWork.Commit();
            return Ok(post);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, PostDto postDto)
        {
            try
            {
                var result = await _unitOfWork.postRepository.Find(id);
                _logger.LogInformation($"This post is in the data base {id}");
                result.Subtitle = postDto.Subtitle;
                result.Title = postDto.Title;
                result.Content = postDto.Content;
                result.Description = postDto.Description;
                result.BlogId = postDto.BlogId;
                await _unitOfWork.postRepository.Update(result);
                _logger.LogInformation($"{id} th post was already updated in the data base");
                await _unitOfWork.Commit();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when looking up id in database id not found {id}");
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                _logger.LogInformation($"{id} obtained from base date");
                var result = await _unitOfWork.postRepository.Find(id);
                await _unitOfWork.postRepository.Delete(result);
                await _unitOfWork.Commit();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error happened then post with id of {id} was not found");
                throw;
            }
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetId(int id)
        {
            var result = await _unitOfWork.postRepository.Find(id);
            return Ok(result);
        }

        


       

        
    }
}
