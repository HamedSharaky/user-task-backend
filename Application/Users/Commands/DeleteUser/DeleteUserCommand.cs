using MediatR;
using UserTask.Application.Common.Interfaces;
using UserTask.Application.Common.Models;
using UserTask.Application.Users.Commands.DeleteUser.Dtos;

namespace UserTask.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>
    {
        public int Id { get; set; }
    }

    
}
