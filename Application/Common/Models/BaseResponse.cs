using System;
using System.Collections.Generic;
using System.Text;
using UserTask.Application.Common.Interfaces;

namespace UserTask.Application.Common.Models
{
    public class BaseResponse : IBaseResponse
    {
        public bool Succeeded { get; set; } 
        public string[] Errors { get; set; }
    }
}
