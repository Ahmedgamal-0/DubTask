using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DubTask.Domain.Shared;
using MediatR;


namespace DubTask.Application.Featuers.Project.Commands.Models
{
    public class RegisterProjectCommand:IRequest<Response<string>>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
