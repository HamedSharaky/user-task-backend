using MediatR;
using UserTask.Application.Users.Queries.GetUserDetail.Dtos;

namespace UserTask.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailVm>
    {
        public int Id { get; set; }
    }
}
