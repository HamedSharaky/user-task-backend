using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserTask.Application.Common.Interfaces;
using UserTask.Domain.Entities.User;

namespace UserTask.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandle : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IUserTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandle(IUserTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
            {
                return new DeleteUserResponse { Succeeded = false};
            }
             _dbContext.Users.Remove(user);
            if (await _dbContext.SaveChangesAsync(cancellationToken) <= 0)
            {
                return new DeleteUserResponse { Succeeded = false };
            }
            return new DeleteUserResponse { Succeeded = true };
        }
    }
}
