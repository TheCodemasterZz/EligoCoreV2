using EligoCore.Domain.Commands;
using EligoCore.Domain.Entities.Enums;
using System;

namespace EligoCore.Domain.Entities
{
    public class Message : EntityWithKey<long>
    {
        public RecipientType RecipientType { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public DateTime SendedAt { get; set; }

        public Message()
        {
        }

        public Message(CreateMessageCommand command)
        {
            RecipientType = command.RecipientType;
            Subject = command.Subject;
            Body = command.Body;
            SendedAt = command.SendedAt;
        }

        public Message(RecipientType recipientType, string subject, string body)
        {
            RecipientType = recipientType;
            Subject = subject;
            Body = body;
            SendedAt = DateTime.Now;
        }

        public Message(RecipientType recipientType, string subject, string body, DateTime sendedAt)
        {
            RecipientType = recipientType;
            Subject = subject;
            Body = body;
            SendedAt = sendedAt;
        }
    }
}
