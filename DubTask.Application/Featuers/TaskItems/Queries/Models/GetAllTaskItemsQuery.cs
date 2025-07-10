using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.TaskItems.Queries.Models
{
    public class GetAllTaskItemsQuery:IRequest<IEnumerable<GetTaskItemResponse>>
    {
    }
}
