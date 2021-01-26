using System;
using AutoMapper;
using UserTask.Application.Common.Mappings;
using UserTask.Domain.Enumerations.User;

namespace UserTask.Application.Users.Queries.GetUserDetail.Dtos
{
    public class UserDetailVm : IMapFrom<UserTask.Domain.Entities.User.User> 
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public Position Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserTask.Domain.Entities.User.User, UserDetailVm>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id));
        }

        /*
         * 
         * A good example of how AutoMapper can help.
         * 
        public static Expression<Func<Customer, CustomerDetailVm>> Projection
        {
            get
            {
                return customer => new CustomerDetailVm
                {
                    Id = customer.CustomerId,
                    Address = customer.Address,
                    City = customer.City,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Country = customer.Country,
                    Fax = customer.Fax,
                    Phone = customer.Phone,
                    PostalCode = customer.PostalCode,
                    Region = customer.Region
                };
            }
        }

        public static CustomerDetailVm Create(Customer customer)
        {
            return Projection.Compile().Invoke(customer);
        }
        */
    }
}
