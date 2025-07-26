using FluentValidation;
using ServiceUser.WebApi.Models.Requests;

namespace ServiceUser.WebApi.Validators
{
    public class AddUserProfileRequestValidator : AbstractValidator<AddUserProfileRequest>
    {
        public AddUserProfileRequestValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty()
                .WithMessage("AccountId не заполнен.");
        }
    }
}
