using AutoMapper;
using UserTask.Application.Common.Mappings;
using UserTask.Domain.Entities.User;

namespace UserTask.Application.User.Queries.GetUserList
{
    public class UserLookupDto : IMapFrom<UserTask.Domain.Entities.User.User>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserTask.Domain.Entities.User.User, UserLookupDto>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Name));
        }
    }
}
