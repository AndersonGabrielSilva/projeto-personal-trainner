using Personal.Core.Messages;
using Personal.Core.Messages.MensagensComuns.DomainEvents;
using Personal.Core.Messages.MensagensComuns.Notifications;

namespace Personal.Core.Comunicacao.Mediator
{
    public interface IMediatorHandler
    {
        /// <summary>
        /// Dispara o Evento
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="evento"></param>
        /// <returns></returns>
        Task PublicarEvento<T>(T evento) where T : Event;

        /// <summary>
        /// Envia o Command / Dispara o Command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comando"></param>
        /// <returns></returns>
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}
