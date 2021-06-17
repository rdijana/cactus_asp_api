using Api.Core.Jwt;
using Application.DataTransfer;
using Application.Logger;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
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
    public class LoginController : ControllerBase
    {

        private readonly JwtManager _manager;
        

        public LoginController(JwtManager manager)
        {
            _manager = manager;
           
        }


        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] UserLoginRequest request,
            [FromServices] UserLoginValidator validator)
        {
            
            validator.ValidateAndThrow(request);

            var passwordHash = HashHelper.ConvertPasswordFormat(request.Password, 0xFF);
            
            var token = _manager.MakeToken(request.Email, passwordHash);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }

    }
}
