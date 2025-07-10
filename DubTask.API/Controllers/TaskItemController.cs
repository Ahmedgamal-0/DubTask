
using DubTask.Application.Featuers.TaskItems.Commands.Models;
using DubTask.Application.Featuers.TaskItems.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace DubTask.API.Controllers
{
    public class TaskItemController : BaseController
    {
        #region Vars / Props
        //private readonly ITaskItemRepository _TaskItemRepository;
        #endregion

        #region Constructor(s)
        public TaskItemController(/*ITaskItemRepository TaskItemRepository*/)
        {
            //_TaskItemRepository = TaskItemRepository;
        }
        #endregion
        #region Methods
        [HttpPost]
        public async Task<IActionResult> Register(RegisterTaskItemCommand command)
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
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTaskItemCommand command)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(new DeleteTaskItemCommand(id));
                return Ok(mediatorResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTaskItems([FromQuery] GetAllTaskItemsQuery command)
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mediatorResponse = await Mediator.Send(new GetTaskItemByIdQuery(id));
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
