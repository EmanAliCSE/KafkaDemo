using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Messaging
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DomainEventDispatcher> _logger;

        public DomainEventDispatcher(
            IMediator mediator,
            ILogger<DomainEventDispatcher> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task DispatchEventsAsync(Entity<Guid> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var domainEvents = entity.DomainEvents.ToList();
            entity.ClearDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                try
                {
                    _logger.LogInformation($"Dispatching domain event: {domainEvent.GetType().Name}");
                    await _mediator.Publish(domainEvent);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error dispatching domain event {domainEvent.GetType().Name}");
                    // Continue with next event even if one fails
                }
            }
        }
    }
}
