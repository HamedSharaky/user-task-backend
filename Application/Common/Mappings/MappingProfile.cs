using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using UserTask.Application.Users.Commands.CreateUser;
using UserTask.Application.Users.Commands.UpdateUser;
using UserTask.Application.Users.Commands.UpdateUser.Dtos;

namespace UserTask.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
            CreateMap<CreateUserCommand, UserTask.Domain.Entities.User.User>(MemberList.None);
            CreateMap<UpdateUserResponse, UserTask.Domain.Entities.User.User>(MemberList.None);

        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => 
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}