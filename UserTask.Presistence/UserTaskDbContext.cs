using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserTask.Application.Common.Interfaces;
using UserTask.Domain.Entities.Common;
using UserTask.Domain.Entities.User;

namespace UserTask.Presistence
{
    public class UserTaskDbContext : DbContext, IUserTaskDbContext
    {
        public UserTaskDbContext(DbContextOptions<UserTaskDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get ; set ; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserTaskDbContext).Assembly);
        }
    }
}
