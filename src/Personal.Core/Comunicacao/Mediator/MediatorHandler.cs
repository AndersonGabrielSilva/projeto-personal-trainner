using MediatR;
using Personal.Core.Messages;
using Personal.Core.Messages.MensagensComuns.DomainEvents;
using Personal.Core.Messages.MensagensComuns.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Comunicacao.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        /*
         * Para os commandos utilisamos o "Send".
         * Para Notificaçoes utilizamos o "Publish".
         * 
         * Commandos/Send => altera o estado do dado
         * Notificaçoes/Publish => somente envia uma mensagem
         */
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)=>        
            _mediator = mediator;        

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
            => await _mediator.Send(comando);
        
        public async Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent
            =>await _mediator.Publish(notificacao);
        
        public async Task PublicarEvento<T>(T evento) where T : Event
            => await _mediator.Publish(evento);
        
        public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
            => await _mediator.Publish(notificacao);
        
    }
}
