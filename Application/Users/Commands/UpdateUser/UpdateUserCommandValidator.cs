using FluentValidation;
using System;
using UserTask.Domain.Enumerations.User;

namespace UserTask.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(60);
            RuleFor(x => x.Address).MaximumLength(11);
            RuleFor(x => x.Position).Must(currency => Enum.IsDefined(typeof(Position), currency));
        }
    }
}
