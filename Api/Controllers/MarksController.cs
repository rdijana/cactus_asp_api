using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
       
        private readonly UseCaseExecutor _executor;

        public MarksController( UseCaseExecutor executor)
        {
            
            _executor = executor;
        }
        
        // GET api/<MarksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetMarkQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<MarksController>
        [HttpPost]
        public IActionResult Post([FromBody] MarkDto dto,[FromServices] ICreateMarkCommand command)
        {
           
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<MarksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MarkDto dto,[FromServices] IUpdateMarkCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<MarksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteMarkCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
