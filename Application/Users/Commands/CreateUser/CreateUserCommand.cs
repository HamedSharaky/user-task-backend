using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserTask.Application.Common.Interfaces;
using UserTask.Application.Common.Mappings;
using UserTask.Application.Common.Models;
using UserTask.Application.Users.Commands.CreateUser.Dtos;
using UserTask.Domain.Enumerations.User;

namespace UserTask.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse> 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public Position Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

      

        //public class Handler : IRequestHandler<CreateUserCommand>
        //{
        //    private readonly INorthwindDbContext _context;
        //    private readonly IMediator _mediator;

        //    public Handler(INorthwindDbContext context, IMediator mediator)
        //    {
        //        _context = context;
        //        _mediator = mediator;
        //    }

        //    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        //    {
        //        var entity = new Customer
        //        {
        //            CustomerId = request.Id,
        //            Address = request.Address,
        //            City = request.City,
        //            CompanyName = request.CompanyName,
        //            ContactName = request.ContactName,
        //            ContactTitle = request.ContactTitle,
        //            Country = request.Country,
        //            Fax = request.Fax,
        //            Phone = request.Phone,
        //            PostalCode = request.PostalCode
        //        };

        //        _context.Customers.Add(entity);

        //        await _context.SaveChangesAsync(cancellationToken);

        //        await _mediator.Publish(new CreateUserCommandHandler { CustomerId = entity.CustomerId }, cancellationToken);

        //        return Unit.Value;
        //    }
        //}

    }

    
}
