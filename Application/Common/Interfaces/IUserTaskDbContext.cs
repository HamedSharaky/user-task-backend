using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UserTask.Domain.Entities.User;

namespace UserTask.Application.Common.Interfaces
{
    public interface IUserTaskDbContext
    {
        DbSet<UserTask.Domain.Entities.User.User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
