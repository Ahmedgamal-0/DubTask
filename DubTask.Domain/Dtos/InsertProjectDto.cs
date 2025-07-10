using DubTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Domain.Dtos
{
    public class InsertProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
