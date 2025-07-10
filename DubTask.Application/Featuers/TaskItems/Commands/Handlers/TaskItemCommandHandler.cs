using DubTask.Application.Featuers.TaskItems.Commands.Models;
using DubTask.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.TaskItems.Commands.Handlers
{
    public class TaskItemCommandHandler : IRequestHandler<RegisterTaskItemCommand, string>,
        IRequestHandler<UpdateTaskItemCommand, string>, IRequestHandler<DeleteTaskItemCommand, string>
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
        public async Task<string> Handle(RegisterTaskItemCommand command, CancellationToken token)
        {
            await _TaskItemRepository.AddAsync(command);
            return "Added successfully";
        }
        public async Task<string> Handle(UpdateTaskItemCommand command, CancellationToken token)
        {
            await _TaskItemRepository.UpdateAsync(command);
            return "Added successfully";
        }
        public async Task<string> Handle(DeleteTaskItemCommand command, CancellationToken token)
        {
            await _TaskItemRepository.DeleteAsync(command);
            return "Added successfully";
        }
        #endregion
    }
}
