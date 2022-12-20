using DTOLayer.DTOs.ProductDTOs;
using Entities;
using FluentValidation;

namespace Shop.Models.Validators
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.ProductName)
                .NotEmpty()
                .WithMessage("Ürün ismi boş geçilmez")
                .MaximumLength(40)
                .WithMessage("Ürün ismi en fazla 40 karakterli olabilir");
            RuleFor(a => a.CategoryName)
                .NotEmpty()
                .WithMessage("Kategori ismi boş geçilmez")
                .MaximumLength(40)
                .WithMessage("Kategori ismi en fazla 40 karakterli olabilir");
        }
    }
}
