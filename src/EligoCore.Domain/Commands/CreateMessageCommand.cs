using EligoCore.Domain.Entities.Enums;
using EligoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EligoCore.Domain.Commands
{
    public sealed class CreateMessageCommand : ICommand
    {
        [Required(ErrorMessage = "Recipient Type is a required parameter.")]
        public RecipientType RecipientType { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Subect is a required parameter.")]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Body is a required parameter.")]
        public string Body { get; set; }

        [Required(ErrorMessage = "SendedAt is a required parameter.")]
        public DateTime SendedAt { get; set; }

        public CreateMessageCommand()
        {
        }

        public CreateMessageCommand(RecipientType recipientType, string subject, string body)
        {
            RecipientType = recipientType;
            Subject = subject;
            Body = body;
            SendedAt = DateTime.Now;
        }
        public CreateMessageCommand(RecipientType recipientType, string subject, string body, DateTime sendedAt)
        {
            RecipientType = recipientType;
            Subject = subject;
            Body = body;
            SendedAt = sendedAt;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
    }
}
