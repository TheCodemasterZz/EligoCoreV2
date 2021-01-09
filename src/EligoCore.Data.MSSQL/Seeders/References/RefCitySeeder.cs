using EligoCore.Data.MSSQL.Resources;
using EligoCore.Domain.Entities.References;
using System.Linq;

namespace EligoCore.Data.MSSQL.Seeders.References
{
    public class RefCitySeeder : EligoCoreSeeder
    {
        public static bool CanExecute(MyDbContext context)
        {
            return context.RefCities.Any() && !context.RefCities.Any();
        }

        public static void Seed(MyDbContext context)
        {
            if (!CanExecute(context))
            {
                return;
            }

            foreach (var line in Parse(SeedData.RefCity))
            {
                var cityCode = line[0];
                var cityName = line[1];
                var countryCode = line[2];
                var country = context.RefCountries.First(c => c.Code == countryCode);
                context.RefCities.Add(new RefCity(cityName, cityCode, country));
            }
        }
    }
}
