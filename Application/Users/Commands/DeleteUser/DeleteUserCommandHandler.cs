using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserTask.Application.Common.Exceptions;
using UserTask.Application.Common.Interfaces;
using UserTask.Application.Users.Commands.DeleteUser.Dtos;
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
            var response = new DeleteUserResponse();

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User", request.Id);
                //return new DeleteUserResponse { Succeeded = false};
            }
            _dbContext.Users.Remove(user);
            if (await _dbContext.SaveChangesAsync(cancellationToken) <= 0)
            {
                throw  new DeleteFailureException("User", request.Id, "");
                //return new DeleteUserResponse { Succeeded = false };
            }
            else
            {
                response.Succeeded = true ;
            }
            return response;
        }
    }
}
