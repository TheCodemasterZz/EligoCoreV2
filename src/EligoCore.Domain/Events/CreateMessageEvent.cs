using EligoCore.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EligoCore.Domain.Events
{
    public class CreateMessageEvent
    {
        public long Id { get; private set; }
        public RecipientType RecipientType { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public DateTime SendedAt { get; set; }

        public CreateMessageEvent()
        {
        }

        public CreateMessageEvent(long id, RecipientType recipientType, string subject, string body)
        {
            Id = id;
            RecipientType = recipientType;
            Subject = subject;
            Body = body;
            SendedAt = DateTime.Now;
        }

        public CreateMessageEvent(long id, RecipientType recipientType, string subject, string body, DateTime dateTime)
        {
            Id = id;
            RecipientType = recipientType;
            Subject = subject;
            Body = body;
            SendedAt = dateTime;
        }
    }
}
