using EligoCore.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EligoCore.Domain
{
    public sealed class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator(IStringLocalizer<Message> localizer)
        {
            RuleFor(x => x.RecipientType)
                .NotNull()
                .WithMessage(x => localizer["RecipientTypeIsRequired"]);

            RuleFor(x => x.Subject)
                .NotNull()
                .WithMessage(x => localizer["SubjectIsRequired"]);

            RuleFor(x => x.Body)
                .NotNull()
                .WithMessage(x => localizer["BodyIsRequired"]);
        }
    }
}
