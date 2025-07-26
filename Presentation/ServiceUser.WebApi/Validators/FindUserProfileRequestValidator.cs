using FluentValidation;
using ServiceUser.WebApi.Models.Requests;

namespace ServiceUser.WebApi.Validators
{
    public class FindUserProfileRequestValidator : AbstractValidator<FindUserProfileRequest>
    {
        public FindUserProfileRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName не заполнен.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("LastName не заполнен.");
        }
    }
}
