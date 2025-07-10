using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Domain.BaseEntities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; private set; }
        public string CreatedBy { get; set; } = "Default-User";
        public DateTime Created { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; } = "Anonymous";
        public DateTime? LastModified { get; set; } = DateTime.Now;
    }
}
