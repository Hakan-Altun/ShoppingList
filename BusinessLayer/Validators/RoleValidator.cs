using Entities;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLayer.Validators
{
    public class RoleValidator:AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(a => a.RoleId)
                .NotEmpty()
                .WithMessage("Kullanıcı rolünü belirtiniz");
        }
    }
}
