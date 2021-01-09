using EligoCore.Domain.Entities;
using System;
using System.Linq;

namespace EligoCore.Data.MSSQL.Seeders
{
    public class UserSeeder
    {
        public static bool CanExecute(MyDbContext context)
        {
            return !context.Users.Any();
        }

        public static void Seed(MyDbContext context)
        {
            if (!CanExecute(context))
                return;

            var user = new User()
            {
                EmailAddress = "thecodemasterzz@gmail.com",
                FirstName = "Baris",
                LastName = "Kalaycioglu",
                DateOfBirth = DateTime.Now,
                RefCityIdPlaceOfBirth = context.RefCities.First(c => c.Name == "Ankara").Id,
                RefCountryIdPlaceOfBirth = context.RefCountries.First(c => c.Name == "Turkey").Id,
                UserType = Domain.Entities.Enums.UserType.Administrator
            };

            context.Users.Add(user);
        }
    }
}
