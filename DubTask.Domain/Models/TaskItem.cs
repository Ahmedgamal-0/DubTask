using DubTask.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Domain.Models
{
    public class TaskItem:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }

}
