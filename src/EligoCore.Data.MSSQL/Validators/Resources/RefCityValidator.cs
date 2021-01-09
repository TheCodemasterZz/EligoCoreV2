using EligoCore.Domain.Entities.References;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EligoCore.Data.MSSQL.Validators.Resources
{
    public class RefCityValidator: AbstractValidator<RefCity>
    {
        public RefCityValidator(IStringLocalizer<RefCity> localizer)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(x => localizer["NameIsRequired"]);

            RuleFor(x => x.Code)
                .NotNull()
                .WithMessage(x => localizer["CodeIsRequired"]);

        }
    }
}
