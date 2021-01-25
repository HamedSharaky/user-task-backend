using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserTask.Application.Common.Interfaces;
using UserTask.Application.Common.Models;
using UserTask.Domain.Enumerations.User;

namespace UserTask.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
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

    public class UpdateUserResponse : BaseResponse, IBaseResponse
    {
    }
}
