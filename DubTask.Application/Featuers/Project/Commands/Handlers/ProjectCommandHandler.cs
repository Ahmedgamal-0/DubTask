using DubTask.Application.Featuers.Project.Commands.Models;
using DubTask.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.Project.Commands.Handlers
{
    public class ProjectCommandHandler:IRequestHandler<RegisterProjectCommand,string>,
        IRequestHandler<UpdateProjectCommand,string>,IRequestHandler<DeleteProjectCommand,string>
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
        public async Task<string>Handle(RegisterProjectCommand command,CancellationToken token)
        {
            await _projectRepository.AddAsync(command);
            return "Added successfully";
        }
        public async Task<string> Handle(UpdateProjectCommand command, CancellationToken token)
        {
            await _projectRepository.UpdateAsync(command);
            return "Added successfully";
        }
        public async Task<string> Handle(DeleteProjectCommand command, CancellationToken token)
        {
            await _projectRepository.DeleteAsync(command);
            return "Added successfully";
        }
        #endregion
    }
}
