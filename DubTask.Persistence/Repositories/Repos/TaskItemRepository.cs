using AutoMapper;
using DubTask.Application.Base;
using DubTask.Application.Featuers.TaskItems.Commands.Models;
using DubTask.Application.Repositories;
using DubTask.Domain.Models;
using DubTask.Persistence.DbContexts;
using DubTask.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Persistence.Repositories.Repos
{
    public class TaskItemRepository:BaseRepository<Domain.Models.TaskItem>, ITaskItemRepository
    {
        private readonly IMapper _mapper;
        public TaskItemRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task AddAsync(RegisterTaskItemCommand TaskItem)
        {
            var TaskItemEntity = _mapper.Map<Domain.Models.TaskItem>(TaskItem);
            await _context.TaskItems.AddAsync(TaskItemEntity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(DeleteTaskItemCommand TaskItem)
        {
            var TaskItemEntity = await _context.TaskItems.FindAsync(TaskItem.Id);
            if (TaskItemEntity == null)
                throw new KeyNotFoundException("TaskItem not found.");

            _context.TaskItems.Remove(TaskItemEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemsForProjectAsync(int projectId)
        {
            return _context.TaskItems
                .Where(t => t.ProjectId == projectId)
                .AsNoTracking();
        }

        public async Task UpdateAsync(UpdateTaskItemCommand TaskItem)
        {
            var TaskItemEntity = _mapper.Map<Domain.Models.TaskItem>(TaskItem);
            _context.TaskItems.Update(TaskItemEntity);
            await _context.SaveChangesAsync();
        }
    }
}
