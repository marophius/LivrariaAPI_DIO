namespace LivrariaAPI_DIO.Notification
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notifications;

        public Notificador()
        {
            _notifications = new List<Notificacao>();
        }
        public void Handle(Notificacao notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notifications;
        }

        public bool TemNotificacao()
        {
            return _notifications.Any();
        }
    }
}
