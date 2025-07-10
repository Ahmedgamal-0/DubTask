using DubTask.Application.Featuers.Project.Queries.Models;
using DubTask.Application.Repositories;
using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.Project.Queries.Handlers
{
    public class ProjectQueryHandler:IRequestHandler<GetAllProjectsQuery, Response<IEnumerable<GetProjectResponse>>>,
        IRequestHandler<GetProjectByIdQuery, Response<GetProjectResponse>>
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Response<IEnumerable<GetProjectResponse>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllProjectsForUserAsync(request.UserId);
            var projectsToReturn= projects.Select(p => new GetProjectResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UserId = p.UserId,
            });
            return new Response<IEnumerable<GetProjectResponse>>(projectsToReturn);
        }
        public async Task<Response<GetProjectResponse>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {request.Id} not found.");
            }
            var projectResponse= new GetProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                UserId = project.UserId,
            };
            return new Response<GetProjectResponse>(projectResponse);
        }
    }
}
