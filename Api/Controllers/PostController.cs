using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public PostController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<PostController>
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearch search,[FromServices] IGetPostsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<PostController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetPostQuery query )
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<PostController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromForm] PostCreateDto dto,[FromServices] ICreatePostCommand command )
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<PostController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] PostCreateDto dto,[FromServices] IUpdatePostCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<PostController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeletePostCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
