using AutoMapper;
using DubTask.Application.Featuers.TaskItems.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Profiles
{
    public class TaskItemProfile:Profile
    {
        public TaskItemProfile()
        {
            CreateMap<RegisterTaskItemCommand, Domain.Models.TaskItem>();
            CreateMap<UpdateTaskItemCommand, Domain.Models.TaskItem>();
        }
    }
}
