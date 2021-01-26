﻿using FluentValidation;
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
            RuleFor(x => x.Address).MaximumLength(200).MinimumLength(5);
            RuleFor(x => x.Position).Must(po => Enum.IsDefined(typeof(Position), po));
        }
    }
}
