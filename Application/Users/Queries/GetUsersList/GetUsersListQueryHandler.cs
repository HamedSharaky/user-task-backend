using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserTask.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace UserTask.Application.User.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IUserTaskDbContext _context;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUserTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new UserListVm
            {
                User = users
            };

            return vm;
        }
    }
}
