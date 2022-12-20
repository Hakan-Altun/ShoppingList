using Entities;
using FluentValidation;

namespace Shop.Models.Validators
{
    public class ListValidator:AbstractValidator<List>
    {
        public ListValidator()
        {
            RuleFor(a => a.ListName)
                .NotEmpty()
                .WithMessage("Liste adı boş geçilmez")
                .MaximumLength(50)
                .WithMessage("Liste adı en fazla 50 karakterli olabilir");
        }
    }
}
