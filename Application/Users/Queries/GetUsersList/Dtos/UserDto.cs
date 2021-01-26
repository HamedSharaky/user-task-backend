using System;
using AutoMapper;
using UserTask.Application.Common.Mappings;
using UserTask.Domain.Entities.User;
using UserTask.Domain.Enumerations.User;

namespace UserTask.Application.User.Queries.GetUserList
{
    public class UserDto : IMapFrom<UserTask.Domain.Entities.User.User>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public Position Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserTask.Domain.Entities.User.User, UserDto>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Name));
        }
    }
}
