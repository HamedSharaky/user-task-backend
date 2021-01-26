using MediatR;

namespace UserTask.Application.User.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListDto>
    {
    }
}
