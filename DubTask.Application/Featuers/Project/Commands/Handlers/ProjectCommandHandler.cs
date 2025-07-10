using DubTask.Application.Featuers.Project.Commands.Models;
using DubTask.Application.Repositories;
using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.Project.Commands.Handlers
{
    public class ProjectCommandHandler:IRequestHandler<RegisterProjectCommand,Response<string>>,
        IRequestHandler<UpdateProjectCommand,Response<string>>,IRequestHandler<DeleteProjectCommand,Response<string>>
    {
        #region vars
        private readonly IProjectRepository _projectRepository;
        #endregion
        #region constructor
        public ProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        #endregion
        #region methods
        public async Task<Response<string>>Handle(RegisterProjectCommand command,CancellationToken token)
        {
            await _projectRepository.AddAsync(command);
            return new Response<string>
            {
                Data = "Added successfully",
                Message = "Project registered successfully",
                Succeeded = true
            };
        }
        public async Task<Response<string>> Handle(UpdateProjectCommand command, CancellationToken token)
        {
            await _projectRepository.UpdateAsync(command);
            return new Response<string> { Data = "Added successfully", Message = "Project registered successfully", Succeeded = true };
        }
        public async Task<Response<string>> Handle(DeleteProjectCommand command, CancellationToken token)
        {
            await _projectRepository.DeleteAsync(command);
            return new Response<string> { Data = "Added successfully", Message = "Project registered successfully", Succeeded = true };
        }
        #endregion
    }
}
