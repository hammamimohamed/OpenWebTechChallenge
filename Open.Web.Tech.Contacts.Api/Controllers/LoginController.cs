using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.Controllers
{
    /// <summary>
    /// LoginController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Mediator 
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Login Controller 
        /// </summary>
        /// <param name="mediator"></param>
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand userLogin)
        {
            var token = await _mediator.Send(userLogin);
            if (string.IsNullOrEmpty(token)) return NotFound("User not found");
            else return Ok(token);
        }
    }
}
