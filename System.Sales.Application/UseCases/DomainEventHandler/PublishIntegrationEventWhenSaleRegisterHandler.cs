
using MassTransit;
using MediatR;
using Sharedkernel.Core;
using Sharedkernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.Event;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Application.UseCases.DomainEventHandler
{
    public class PublishIntegrationEventWhenSaleRegisterHandler : INotificationHandler<ConfirmedDomainEvent<SaleMade>>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenSaleRegisterHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task Handle(ConfirmedDomainEvent<SaleMade> notification, CancellationToken cancellationToken)
        {
            SaleRegister evento = new SaleRegister()
            {
                date = notification.DomainEvent.saleMade.date,
                note = notification.DomainEvent.saleMade.note,
                clienteId = notification.DomainEvent.saleMade.clienteId,
                userId = notification.DomainEvent.saleMade.userId,
                amountTotal = notification.DomainEvent.saleMade.amountTotal,
                amountNominal = notification.DomainEvent.saleMade.amountNominal,
                discount = notification.DomainEvent.saleMade.discount,
                iva = notification.DomainEvent.saleMade.iva
            };
            await _publishEndpoint.Publish<Sharedkernel.IntegrationEvents.SaleRegister>(evento);
        }
    }
}
