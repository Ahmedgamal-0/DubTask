using DubTask.Application.Featuers.TaskItems.Queries.Models;
using DubTask.Application.Repositories;
using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.TaskItems.Queries.Handlers
{
    public class TaskItemQueryHandler : IRequestHandler<GetAllTaskItemsQuery,Response<IEnumerable<GetTaskItemResponse>>>,
        IRequestHandler<GetTaskItemByIdQuery, Response<GetTaskItemResponse>>
    {
        private readonly ITaskItemRepository _TaskItemRepository;
        public TaskItemQueryHandler(ITaskItemRepository TaskItemRepository)
        {
            _TaskItemRepository = TaskItemRepository;
        }
        public async Task<Response<IEnumerable<GetTaskItemResponse>>> Handle(GetAllTaskItemsQuery request, CancellationToken cancellationToken)
        {
            var TaskItems = await _TaskItemRepository.GetAllTaskItemsForProjectAsync(request.ProjectId);
            var task= TaskItems.Select(p => new GetTaskItemResponse
            {
                Id = p.Id,
                Description = p.Description,
                DueDate = p.DueDate,
                IsCompleted=p.IsCompleted,
                Title=p.Title,

            });
            return new Response<IEnumerable<GetTaskItemResponse>>(task);
        }
        public async Task<Response<GetTaskItemResponse>> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
        {
            var TaskItem = await _TaskItemRepository.GetByIdAsync(request.Id);
            if (TaskItem == null)
            {
                throw new KeyNotFoundException($"TaskItem with ID {request.Id} not found.");
            }
            var task= new GetTaskItemResponse
            {
                Id = TaskItem.Id,
                Description = TaskItem.Description,
                DueDate = TaskItem.DueDate,
                IsCompleted = TaskItem.IsCompleted,
                Title = TaskItem.Title,
            };
            return new Response<GetTaskItemResponse>(task);
        }
    }
}
