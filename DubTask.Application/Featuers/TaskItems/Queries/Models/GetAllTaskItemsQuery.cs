using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.TaskItems.Queries.Models
{
    public class GetAllTaskItemsQuery:IRequest<Response<IEnumerable<GetTaskItemResponse>>>
    {
        public int ProjectId { get; set; }
        public GetAllTaskItemsQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
