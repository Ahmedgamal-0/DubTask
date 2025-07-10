using DubTask.Application.Featuers.Project.Queries.Models;
using DubTask.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.Project.Queries.Handlers
{
    public class ProjectQueryHandler:IRequestHandler<GetAllProjectsQuery, IEnumerable<GetProjectResponse>>,
        IRequestHandler<GetProjectByIdQuery, GetProjectResponse>
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<IEnumerable<GetProjectResponse>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.ListAllAsync();
            return projects.Select(p => new GetProjectResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UserId = p.UserId,
                User = p.User,
                Tasks = p.Tasks
            });
        }
        public async Task<GetProjectResponse> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {request.Id} not found.");
            }
            return new GetProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                UserId = project.UserId,
                User = project.User,
                Tasks = project.Tasks
            };
        }
    }
}
