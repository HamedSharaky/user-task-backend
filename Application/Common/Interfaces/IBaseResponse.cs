using System.Collections.Generic;
using System.Linq;

namespace UserTask.Application.Common.Interfaces
{
    public interface IBaseResponse
    {

        bool Succeeded { get; set; }

        string[] Errors { get; set; }

    }
}
