using FluentValidation;
using FluentValidation.Results;
using LivrariaAPI_DIO.Models;
using LivrariaAPI_DIO.Notification;

namespace LivrariaAPI_DIO.Services
{
    public class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult result)
        {
            foreach(var error in result.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid)
            {
                return true;
            }

            Notificar(validator);
            return false;
        }
    }
}
