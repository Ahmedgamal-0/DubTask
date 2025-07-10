using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.Project.Queries.Models
{
    public class GetAllProjectsQuery:IRequest<Response<IEnumerable<GetProjectResponse>>>
    {
        public int UserId { get; set; }
        public GetAllProjectsQuery(int userId=1)
        {
            UserId = userId;
        }
    }
}
