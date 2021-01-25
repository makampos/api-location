using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    // http://localhost:5000/users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService  _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok (await _service.getAll());
            }
            catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
            
        }
    }
}

