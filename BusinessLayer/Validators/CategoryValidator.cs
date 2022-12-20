using Entities;
using FluentValidation;

namespace Shop.Models.Validators
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(a => a.CategoryName)
                .NotEmpty()
                .WithMessage("Kategori ismi boş geçilmez")
                .MaximumLength(40)
                .WithMessage("Kategori ismi en fazla 40 karakterli olabilir");
        }
    }
}
