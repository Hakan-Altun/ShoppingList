using Entities;
using FluentValidation;

namespace Shop.Models.Validators
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.UserName).Name();
            RuleFor(a => a.UserLastName).LastName();
            RuleFor(a => a.UserEmail)
                .NotEmpty()
                .WithMessage("Email boş geçilmez")
                .MaximumLength(40)
                .WithMessage("Email en fazla 40 karakter olmalıdır")
                .EmailAddress()
                .WithMessage("Uygun bir email adresi giriniz");
            RuleFor(a => a.UserPassword).Password();
            RuleFor(a => a.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Şifrenizi tekrar giriniz")
                .Equal(a => a.UserPassword)
                .WithMessage("Şifreler eşleşmiyor");
               
        }
    }
}
