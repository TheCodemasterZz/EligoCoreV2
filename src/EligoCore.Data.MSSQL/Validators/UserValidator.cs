using EligoCore.Data.MSSQL.Resources;
using EligoCore.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EligoCore.Data.MSSQL.Validators
{
    public sealed class UserValidator : AbstractValidator<User>
    {
        public UserValidator(IStringLocalizer<User> localizer)
        {
            RuleFor(x => x.UserType)
                .NotNull()
                .WithMessage(x => localizer["UserTypeIsRequired"]);

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage(x => localizer["FirstNameIsRequired"]);

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage(x => localizer["LastNameIsRequired"]);

            RuleFor(x => x.RefCityIdPlaceOfBirth)
                .NotNull()
                .WithMessage(x => localizer["RefCityIsRequired"]);

            RuleFor(x => x.RefCountryIdPlaceOfBirth)
                .NotNull()
                .WithMessage(x => localizer["RefCountryIsRequired"]);

            RuleFor(x => x.EmailAddress)
                .NotNull()
                .WithMessage(x => localizer["EmailAddressIsRequired"]);

            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .WithMessage(x => localizer["EmailAddressMustHasAnEmailAddressFormat"]);
        }
    }
}
