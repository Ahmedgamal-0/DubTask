using DubTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.Project.Queries.Models
{
    public class GetProjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
