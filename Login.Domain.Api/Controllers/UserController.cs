using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Domain.Commands;
using Login.Domain.Handlers;
using Login.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Login.Domain.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetUser([FromBody] GetUserByUserNamePasswordQuery query,
                                     [FromServices] GetUserByUserNamePasswordHandler handler)
        {
             try
            {
                var result = (CommandResult)handler.handle(query);
                
                if (!result.Success){
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch(Exception ex){
                return StatusCode(500,ex);
            }
        }
        
        [HttpPost]
        public IActionResult CreateUserRequest([FromServices]CreateUserHandler handler,
                                                            [FromBody] CreateUserCommand command)
        {
            try
            {
                var result = (CommandResult)handler.handle(command);
                
                if (!result.Success){
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch(Exception ex){
                return StatusCode(500,ex);
            }
        }
    }
}
