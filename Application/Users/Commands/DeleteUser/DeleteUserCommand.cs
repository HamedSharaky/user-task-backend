using MediatR;
using UserTask.Application.Common.Interfaces;
using UserTask.Application.Common.Models;

namespace UserTask.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteUserResponse : BaseResponse, IBaseResponse
    {
    }
}
