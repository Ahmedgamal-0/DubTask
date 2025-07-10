using DubTask.Domain.Dtos;
using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.User.Commands.Models
{
    public class LoginUserCommand : IRequest<Response<UserDto>>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
