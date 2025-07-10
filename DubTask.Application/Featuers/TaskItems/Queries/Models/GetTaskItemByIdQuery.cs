using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.TaskItems.Queries.Models
{
    public class GetTaskItemByIdQuery:IRequest<GetTaskItemResponse>
    {
        public int Id { get; set; }
        public GetTaskItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
