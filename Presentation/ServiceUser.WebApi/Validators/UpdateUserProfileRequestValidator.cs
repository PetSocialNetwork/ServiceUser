using FluentValidation;
using ServiceUser.WebApi.Models.Requests;

namespace ServiceUser.WebApi.Validators
{
    public class UpdateUserProfileRequestValidator : AbstractValidator<UpdateUserProfileRequest>
    {
        public UpdateUserProfileRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id не заполнен.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName не заполнен.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("LastName не заполнен.");

            RuleFor(x => x.AccountId)
                .NotEmpty()
                .WithMessage("AccountId не заполнен.");
        }
    }
}
