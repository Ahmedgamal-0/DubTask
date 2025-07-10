using DubTask.Application.Base;
using DubTask.Application.Repositories;
using DubTask.Persistence.DbContexts;
using DubTask.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Persistence.Repositories.Repos
{
    public class TaskItemRepository:BaseRepository<Domain.Models.TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
