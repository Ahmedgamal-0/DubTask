using DubTask.Application.Base;
using DubTask.Application.Featuers.Project.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Repositories
{
    public interface IProjectRepository : IBaseRepository<Domain.Models.Project>
    {
        public Task AddAsync(RegisterProjectCommand project);
        public Task UpdateAsync(UpdateProjectCommand project);
        public Task DeleteAsync(DeleteProjectCommand project);
    }
}
