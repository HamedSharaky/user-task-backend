using FluentValidation;

namespace UserTask.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
    {
        public GetUserDetailQueryValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
