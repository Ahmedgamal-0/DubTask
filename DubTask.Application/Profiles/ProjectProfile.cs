using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Profiles
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile()
        {
            CreateMap<Domain.Models.Project, Featuers.Project.Commands.Models.RegisterProjectCommand>()
                .ReverseMap();
            CreateMap<Domain.Models.Project, Featuers.Project.Commands.Models.UpdateProjectCommand>()
                .ReverseMap();
        }
    }
}
