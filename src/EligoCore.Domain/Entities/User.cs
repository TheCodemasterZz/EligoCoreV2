using EligoCore.Domain.Entities.Enums;
using EligoCore.Domain.Entities.References;
using System;

namespace EligoCore.Domain.Entities
{
    public class User : EntityFullAuditable<Guid>
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int RefCityIdPlaceOfBirth { get; set; }
        public virtual RefCity RefCityPlaceOfBirth { get; set; }
        public int RefCountryIdPlaceOfBirth { get; set; }
        public virtual RefCity RefCountryPlaceOfBirth { get; set; }
        public UserType UserType { get; set; }

        public User()
        {
        }

        public User(string emailAddress, string firstName, string lastName)
        {
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
