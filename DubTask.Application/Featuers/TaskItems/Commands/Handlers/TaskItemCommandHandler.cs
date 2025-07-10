using DubTask.Application.Featuers.TaskItems.Commands.Models;
using DubTask.Application.Repositories;
using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.TaskItems.Commands.Handlers
{
    public class TaskItemCommandHandler : IRequestHandler<RegisterTaskItemCommand,Response<string>>,
        IRequestHandler<UpdateTaskItemCommand, Response<string>>, IRequestHandler<DeleteTaskItemCommand, Response<string>>
    {
        #region vars
        private readonly ITaskItemRepository _TaskItemRepository;
        #endregion
        #region constructor
        public TaskItemCommandHandler(ITaskItemRepository TaskItemRepository)
        {
            _TaskItemRepository = TaskItemRepository;
        }
        #endregion
        #region methods
        public async Task<Response<string>> Handle(RegisterTaskItemCommand command, CancellationToken token)
        {
            await _TaskItemRepository.AddAsync(command);
            return new Response<string>
            {
                Data = "Added successfully",
                Message = "Task item registered successfully",
                Succeeded = true
            };
        }
        public async Task<Response<string>> Handle(UpdateTaskItemCommand command, CancellationToken token)
        {
            await _TaskItemRepository.UpdateAsync(command);
            return new Response<string>
            {
                Data = "Updated successfully",
                Message = "Task item updated successfully",
                Succeeded = true
            };
        }
        public async Task<Response<string>> Handle(DeleteTaskItemCommand command, CancellationToken token)
        {
            await _TaskItemRepository.DeleteAsync(command);
            return new Response<string> { Data = "Added successfully", Message = "Task item registered successfully", Succeeded = true };
        }
        #endregion
    }
}
