using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.Project.Queries.Models
{
    public class GetProjectByIdQuery:IRequest<Response<GetProjectResponse>>
    {
        public int Id { get; set; }
        public GetProjectByIdQuery(int id)
        {
            Id = id ;
        }
    }
}
