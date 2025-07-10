using DubTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Repositories
{
    public interface ITokenRepository
    {
        string GenerateToken(User user);
    }
}
