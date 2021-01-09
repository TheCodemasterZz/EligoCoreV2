using EligoCore.Domain.Entities.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace EligoCore.Service.Models
{
    public sealed class RefCountryDto
    {
        public string Code { get; internal set; }
        public string Name { get; internal set; }
    }

    public static class RefCountryDtoExtensions
    {
        public static RefCountryDto Assemble(this RefCountry refCountry)
        {
            if (refCountry == null) return null;

            var dto = new RefCountryDto
            {
                Code = refCountry.Code,
                Name = refCountry.Name
            };

            return dto;
        }
    }
}
