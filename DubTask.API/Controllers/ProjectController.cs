using DubTask.Application.Featuers.Project.Commands.Models;
using DubTask.Application.Featuers.Project.Queries.Models;
using DubTask.Application.Repositories;
using DubTask.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DubTask.API.Controllers
{

    public class ProjectController : BaseController
    {
        #region Vars / Props
        //private readonly IProjectRepository _projectRepository;
        #endregion

        #region Constructor(s)
        public ProjectController(/*IProjectRepository projectRepository*/)
        {
            //_projectRepository = projectRepository;
        }
        #endregion
        #region Methods
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterProjectCommand command)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(command);
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectCommand command)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(command);
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(new DeleteProjectCommand(id));
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllProjects(int userId)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(new GetAllProjectsQuery {UserId=userId });
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(new GetProjectByIdQuery(id));
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        #endregion
    }
}
