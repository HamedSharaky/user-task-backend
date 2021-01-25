using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserTask.Application.Common.Exceptions;
using UserTask.Application.Common.Interfaces;
using UserTask.Domain.Entities.User;

namespace UserTask.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailVm>
    {
        private readonly IUserTaskDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IUserTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDetailVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return _mapper.Map<UserDetailVm>(entity);
        }
    }
}
