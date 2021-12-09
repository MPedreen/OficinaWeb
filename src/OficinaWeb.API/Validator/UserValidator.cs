using FluentValidation;
using OficinaWeb.Models;

namespace OficinaWeb.API.Validator
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email).NotNull().WithMessage("E-mail vazio");
            RuleFor(user => user.Email).EmailAddress().WithMessage("E-mail inválido");
            RuleFor(user => user.Senha).NotNull().WithMessage("Digite a senha");
        }
    }
}