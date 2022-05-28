using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Messages.MensagensComuns.DomainEvents
{
    /// <summary>
    /// È uma boa pratica sempre criar uma classe de Domain Event no Core 
    /// para ser possivel compartilhar o Evento entre as outras camadas e projetos
    /// </summary>
    public class DomainEvent : Message,INotification 
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
        }
    }
}
