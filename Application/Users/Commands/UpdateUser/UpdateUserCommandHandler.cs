using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserTask.Application.Common.Exceptions;
using UserTask.Application.Common.Interfaces;
using UserTask.Application.Users.Commands.UpdateUser.Dtos;
using UserTask.Domain.Entities.User;

namespace UserTask.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandle : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandle(IUserTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserResponse();

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User", request.Id);
                //return new UpdateUserResponse { Succeeded = false } ;
            }

            _mapper.Map(request, user);
            _dbContext.Users.Update(user);
            if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
            {
                //return new UpdateUserResponse { Succeeded = false };
                response.Errors = new[] {"error on deleting from db"};
            }
            else
            {
                response.Succeeded = true;
            }
            return response;
        }
    }
}
