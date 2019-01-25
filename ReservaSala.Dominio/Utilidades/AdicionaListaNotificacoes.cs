using FluentValidator;
using ReservaSala.Infra.Entidades;
using System.Collections.Generic;


namespace ReservaSala.Dominio.Utilidades
{
    public static class AdicionaListaNotificacoes
    {
        public static void AdicionaNotificacoes(this Entidade entidade,params IReadOnlyCollection<Notification>[] notificacoes)
        {
            foreach (var notificacao in notificacoes)
            {
                entidade.AddNotifications(notificacao);
            }
        }
    }
}
