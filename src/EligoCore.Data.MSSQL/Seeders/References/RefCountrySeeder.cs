
using EligoCore.Data.MSSQL.Resources;
using EligoCore.Domain.Entities.References;
using System.Linq;

namespace EligoCore.Data.MSSQL.Seeders.References
{
    public class RefCountrySeeder : EligoCoreSeeder
    {
        public static bool CanExecute(MyDbContext context)
        {
            return !context.RefCountries.Any();
        }

        public static void Seed(MyDbContext context)
        {
            if (!CanExecute(context))
                return;

            foreach (var line in Parse(SeedData.RefCountry))
            {
                var countryCode = line[0];
                var countryName = line[1];
                context.RefCountries.Add(new RefCountry(countryName, countryCode));
            }
        }
    }
}
