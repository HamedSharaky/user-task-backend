using System;
using System.Collections.Generic;
using System.Text;

namespace UserTask.Domain.Entities.Common
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public int CreatedBy { get; set; } 
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
