using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.Project.Commands.Models
{
    public class DeleteProjectCommand:IRequest<string>
    {
        public int Id { get; set; }
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }
    }
}
