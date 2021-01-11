using EligoCore.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EligoCore.Service
{
    public interface IRefCountryService
    {
        Task CreateRefCountryAsync(RefCountryDto dto, CancellationToken cancellationToken = default);

    }
}
