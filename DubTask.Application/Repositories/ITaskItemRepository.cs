using DubTask.Application.Base;
using DubTask.Application.Featuers.TaskItems.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Repositories
{
    public interface ITaskItemRepository:IBaseRepository<Domain.Models.TaskItem>
    {
        public Task AddAsync(RegisterTaskItemCommand TaskItem);
        public Task UpdateAsync(UpdateTaskItemCommand TaskItem);
        public Task DeleteAsync(DeleteTaskItemCommand TaskItem);
        public Task<IEnumerable<Domain.Models.TaskItem>> GetAllTaskItemsForProjectAsync(int projectId);
    }
}
