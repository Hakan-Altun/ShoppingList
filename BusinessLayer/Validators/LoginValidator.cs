using DTOLayer.DTOs.LoginDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
	public class LoginValidator:AbstractValidator<LoginDTO>
	{
		public LoginValidator()
		{
			RuleFor(a => a.UserEmail)
				.NotEmpty()
				.WithMessage("Email adresinizi giriniz");
			RuleFor(a => a.UserPassword)
                .NotEmpty()
				.WithMessage("Şifrenizi giriniz");
		}
	}
}
