using DubTask.Application.Featuers.User.Commands.Models;
using Microsoft.AspNetCore.Mvc;

namespace DubTask.API.Controllers
{
    public class UserController:BaseController
    {
        #region Vars / Props
        #endregion

        #region Constructor(s)
        public UserController()
        {
        }
        #endregion
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = await Mediator.Send(command);
                return Ok(new { userId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }

        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var token = await Mediator.Send(command);
                return Ok(token);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }
    }
}
