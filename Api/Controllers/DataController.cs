using DataAccess;
using Domain;
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
    public class DataController : ControllerBase
    {

        private readonly CactusContext _context;

        public DataController(CactusContext context)
        {
            _context = context;
        }

        // POST api/<DataController>
        [HttpPost]
        public void Post()
        {

        }


    }
}
