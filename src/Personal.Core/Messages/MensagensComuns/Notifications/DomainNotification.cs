using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Messages.MensagensComuns.Notifications
{
    public class DomainNotification: Message, INotification
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Nome da Notificacao</param>
        /// <param name="value">Mensagem da notificação</param>
        public DomainNotification(string key, string value)
        {
            Timestamp = DateTime.Now;
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }

        public DateTime Timestamp { get; private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

    }
}
