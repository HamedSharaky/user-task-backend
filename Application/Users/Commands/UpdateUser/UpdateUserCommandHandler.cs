using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserTask.Application.Common.Interfaces;
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
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
            {
                return new UpdateUserResponse { Succeeded = false } ;
            }

            _mapper.Map(request, user);
            _dbContext.Users.Update(user);
            if (await _dbContext.SaveChangesAsync(cancellationToken) <= 0)
            {
                return new UpdateUserResponse { Succeeded = false };
            }
            return new UpdateUserResponse { Succeeded = true };
        }
    }
}
