using DubTask.Application.Featuers.TaskItems.Queries.Models;
using DubTask.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.TaskItems.Queries.Handlers
{
    public class TaskItemQueryHandler : IRequestHandler<GetAllTaskItemsQuery, IEnumerable<GetTaskItemResponse>>,
        IRequestHandler<GetTaskItemByIdQuery, GetTaskItemResponse>
    {
        private readonly ITaskItemRepository _TaskItemRepository;
        public TaskItemQueryHandler(ITaskItemRepository TaskItemRepository)
        {
            _TaskItemRepository = TaskItemRepository;
        }
        public async Task<IEnumerable<GetTaskItemResponse>> Handle(GetAllTaskItemsQuery request, CancellationToken cancellationToken)
        {
            var TaskItems = await _TaskItemRepository.ListAllAsync();
            return TaskItems.Select(p => new GetTaskItemResponse
            {
                Id = p.Id,
                Description = p.Description,
                DueDate = p.DueDate,
                IsCompleted=p.IsCompleted,
                Title=p.Title,

            });
        }
        public async Task<GetTaskItemResponse> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
        {
            var TaskItem = await _TaskItemRepository.GetByIdAsync(request.Id);
            if (TaskItem == null)
            {
                throw new KeyNotFoundException($"TaskItem with ID {request.Id} not found.");
            }
            return new GetTaskItemResponse
            {
                Id = TaskItem.Id,
                Description = TaskItem.Description,
                DueDate = TaskItem.DueDate,
                IsCompleted = TaskItem.IsCompleted,
                Title = TaskItem.Title,
            };
        }
    }
}
