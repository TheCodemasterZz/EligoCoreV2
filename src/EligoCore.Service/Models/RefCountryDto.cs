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
        public static RefCountryCommand Assemble(this RefCountryDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var command = new RefCountryCommand(dto.Code,
                                                    dto.Name);
            return command;
        }
    }
}
