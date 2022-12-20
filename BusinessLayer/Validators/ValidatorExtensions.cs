using FluentValidation;

namespace Shop.Models.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T,string> Password<T>(this IRuleBuilder<T,string> ruleBuilder)
        {
            var options = ruleBuilder
                         .NotEmpty()
                         .WithMessage("Şifre boş geçilmez")
                         .MinimumLength(8)
                         .WithMessage("Şifre en az 8 karakterli olmalı")
                         .MaximumLength(50)
                         .WithMessage("Şifre en fazla 50 karakterli olabilir")
                         .Matches("[A-Z]")
                         .WithMessage("Şifre en az bir tane büyük harf içermelidir")
                         .Matches("[a-z]")
                         .WithMessage("Şifre en az bir tane küçük harf içermelidir")
                         .Matches(@"\d").WithMessage("Şifre en az bir tane rakam içermelidir");
            return options;
        }
        public static IRuleBuilder<T,string> Name<T>(this IRuleBuilder<T,string> rulebuilder)
        {
            var options = rulebuilder
                         .NotEmpty()
                         .WithMessage("İsim boş geçilmez")
                         .MaximumLength(25)
                         .WithMessage("İsim en fazla 25 karakterli olmalıdır");

            return options;
        }
        public static IRuleBuilder<T, string> LastName<T>(this IRuleBuilder<T, string> rulebuilder)
        {
            var options = rulebuilder
                         .NotEmpty()
                         .WithMessage("Soyadı boş geçilmez")
                         .MaximumLength(25)
                         .WithMessage("Soyadı en fazla 25 karakterli olmalıdır");

            return options;
        }
    }
}
