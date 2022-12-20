using Entities;
using FluentValidation;

namespace Shop.Models.Validators
{
    public class ProductDetailValidator:AbstractValidator<ProductDetail>
    {
        public ProductDetailValidator()
        {
            RuleFor(a => a.ProductName)
            .NotEmpty()
            .WithMessage("Ürün ismi boş geçilmez")
            .MaximumLength(40)
            .WithMessage("Ürün ismi en fazla 40 karakterli olabilir");
            RuleFor(a => a.CategoryName)
                .MaximumLength(40)
                .WithMessage("Kategori ismi en fazla 40 karakterli olabilir");
            RuleFor(a => a.Quantity)
                .MaximumLength(30)
                .WithMessage("Miktar bilgisi en fazla 30 karakterli olabilir");
            RuleFor(a => a.Brand)
                .MaximumLength(25)
                .WithMessage("Marka ismi en fazla 25 karakterli olabilir");
        }
    }
}
