using System;
using System.Collections.Generic;
using System.Text;

namespace UserTask.Domain.Exceptions
{
    public class DomainExceptions : Exception
    {
        public DomainExceptions(Exception ex)
        {
            //handel Exception in Domain Library
        }
    }
}
