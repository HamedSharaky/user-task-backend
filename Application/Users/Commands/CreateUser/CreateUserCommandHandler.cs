﻿using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserTask.Application.Common.Interfaces;
using UserTask.Domain.Entities.User;

namespace UserTask.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateUserCommandHandle(IUserTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<Domain.Entities.User.User>(request);
            await _dbContext.Users.AddAsync(newUser, cancellationToken);
            if (await _dbContext.SaveChangesAsync(cancellationToken) <= 0)
            {
                return new CreateUserResponse { Succeeded = false };
            }
            return new CreateUserResponse { Succeeded = true };
        }
    }
}
