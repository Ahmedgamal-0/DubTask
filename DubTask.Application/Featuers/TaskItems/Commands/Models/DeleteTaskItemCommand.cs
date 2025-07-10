using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.TaskItems.Commands.Models
{
    public class DeleteTaskItemCommand:IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteTaskItemCommand(int id)
        {
            Id = id;            
        }
    }
}
