using System;
using Login.Domain.Api.Serivces;
using Login.Domain.Commands;
using Login.Domain.Entities;
using Login.Domain.Handlers;
using Login.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Login.Domain.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GetUser([FromBody] GetUserByUserNamePasswordQuery query,
                                     [FromServices] GetUserByUserNamePasswordHandler handler)
        {
             try
            {
                var result = (CommandResult)handler.handle(query);
                
                if (!result.Success){
                    return BadRequest(result);
                }

                if (result.Data == null){
                    return NotFound(result);
                }
                
                var token = TokenService.GenerateToken((User)result.Data);

                return Ok(
                    new {
                        token = token,
                        user = result.Data
                    }
                );
            }
            catch(Exception ex){
                return StatusCode(500,ex);
            }
        }

        [HttpGet]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

    }
}
