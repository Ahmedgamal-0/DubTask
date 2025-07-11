using AutoMapper;
using DubTask.Application.Featuers.Project.Commands.Models;
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
    public class ProjectRepository : BaseRepository<Domain.Models.Project>,IProjectRepository
    {
        private readonly IMapper _mapper;
        public ProjectRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task AddAsync(RegisterProjectCommand project)
        {
            var projectEntity = _mapper.Map<Domain.Models.Project>(project);
            await _context.Projects.AddAsync(projectEntity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(DeleteProjectCommand project)
        {
            var projectEntity = await _context.Projects.FindAsync(project.Id);
            if (projectEntity == null)
                throw new KeyNotFoundException("Project not found.");

            _context.Projects.Remove(projectEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsForUserAsync(int userId)
        {
            return _context.Projects.Where(p => p.UserId == userId).AsNoTracking();
        }

        public async Task UpdateAsync(UpdateProjectCommand project)
        {
            var projectEntity = await GetByIdAsync(project.Id);
            if (projectEntity == null)
            {
                throw new KeyNotFoundException("Project not found.");
            }
            projectEntity.Name=project.Name;
            projectEntity.Description = project.Description;
            _context.Projects.Update(projectEntity);
            await _context.SaveChangesAsync();
        }
    }
}
