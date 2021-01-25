using System;
using System.Collections.Generic;
using System.Text;
using UserTask.Domain.Entities.Common;
using UserTask.Domain.Enumerations.User;

namespace UserTask.Domain.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public Position Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
