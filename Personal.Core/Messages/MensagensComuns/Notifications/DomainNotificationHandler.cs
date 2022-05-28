using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Messages.MensagensComuns.Notifications
{
    public class DomainNotificationHandler
    {        
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            //Recebe a Notificação e adiciona na lista
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        //Obtem as Notificações
        public virtual List<DomainNotification> ObterNotificacoes()
        {
            return _notifications;
        }

        //Verificia se possui alguma notificação
        public virtual bool TemNotificacao()
        {
            return ObterNotificacoes().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
