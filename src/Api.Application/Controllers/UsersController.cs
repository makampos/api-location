using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Services.User;
using Microsoft.AspNetCore.Authorization;
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

        // localhost:5000/api/users/
        [Authorize("Bearer")]
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
        
        // localhost:5000/api/users/b9ebb74d-218e-40e9-aea7-94d93d431988
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id){
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok (await _service.Get(id));
            }
            catch (ArgumentException e){
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }                                        
        }

        // localhost:5000/api/users/
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity user) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try
            {
                var result =  await _service.Post(user);
                if (result != null) {
                    return Created(new Uri
                    (
                        Url.Link("GetWithId", new 
                        {
                            Id = result.Id
                        })
                    ), result);                  
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {               
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // localhost:5000/api/users/
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity user) 
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(user);
                if(result != null) 
                {
                    return Ok (result);                                      
                } 
                else 
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int ) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // localhost:5000/api/users/b9ebb74d-218e-40e9-aea7-94d93d431988
        [Authorize("Bearer")]
        [HttpDelete("{id}")]        
        public async Task<ActionResult> Delete(Guid id) 
        {
            if(!ModelState.IsValid) 
            {
               return BadRequest(ModelState);
            }
             try
                {
                    return Ok(await _service.Delete(id));                                       
                }
                catch (ArgumentException e)
                {                   
                    return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                }
        }
    }
}

