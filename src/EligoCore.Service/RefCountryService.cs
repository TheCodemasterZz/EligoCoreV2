using EligoCore.Domain;
using EligoCore.Domain.Entities.References;
using EligoCore.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EligoCore.Service
{
    public class RefCountryService : IRefCountryService
    {
        private readonly RefCountryRepositoryResolver _refCountryRepository;
        public RefCountryService(RefCountryRepositoryResolver refCountryRepository)
        {
            _refCountryRepository = refCountryRepository ?? throw new ArgumentNullException(nameof(refCountryRepository));
        }

        public Task CreateRefCountryAsync(RefCountryDto dto, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public async Task DispatchRefCountry(RefCountryDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                var command = dto.Assemble();
                var refCountry = new RefCountry(command);

                // dispatch domain event
                var @event = new BehaviorCreatedEvent(behavior.Id,
                                                      behavior.IP,
                                                      behavior.PageName,
                                                      behavior.UserAgent,
                                                      behavior.PageParameters);
                await _messageService.PublishAsync("behavior_created", @event, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CreateBehaviorException(
                    $"An error occurred when trying to create behavior for IP {dto.IP} and page name {dto.PageName}. See inner exception for details.",
                    ex);
            }
        }
    }
}
