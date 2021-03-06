using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // Logar na aplicação
        // http://localhost:5000/login
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if(loginDto == null) {
                return BadRequest();
            }
            try
            {
                var result = await service.FindByLogin(loginDto);
                if(result != null) {
                    return Ok(result);
                } 
                else {
                    return NotFound();
                }
                
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}