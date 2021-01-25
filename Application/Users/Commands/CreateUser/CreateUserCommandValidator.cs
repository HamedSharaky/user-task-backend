using FluentValidation;
using System;
using UserTask.Domain.Enumerations.User;

namespace UserTask.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(60);
            RuleFor(x => x.Address).MaximumLength(11);
            RuleFor(x => x.Position).Must(po => Enum.IsDefined(typeof(Position), po));
        }
    }
}
