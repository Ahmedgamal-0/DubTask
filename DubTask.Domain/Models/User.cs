using DubTask.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Domain.Models
{
    public class User:BaseEntity
    {
        public string Username { get; set; } = default!;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
