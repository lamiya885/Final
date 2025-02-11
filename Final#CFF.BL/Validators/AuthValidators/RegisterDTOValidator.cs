using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Services.Interfaces;
using FluentValidation;

namespace Final_CFF.BL.Validators.AuthValidators
{
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        private readonly IUserService _userService;
        public RegisterDTOValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(r => r.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("FullName is required!")
                .MinimumLength(3)
                .WithMessage("Full Name must be  more than 3 characters!")
                .MaximumLength(64)
                .WithMessage("Full Name must be less than 64 charecters!");
            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("User Name is required!")
                .MinimumLength(8)
                .WithMessage("User Name must be more than 8 characters!")
                .MaximumLength(32)
                .WithMessage("User Name must be less than 32 characters!");
            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email is required!")
                .MinimumLength(8)
                .WithMessage("Email must be more than 8 characters!")
                .MaximumLength(32)
                .WithMessage("Email must be less than 32 characters!");
            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password is required!")
                .MinimumLength(8)
                .WithMessage("Password must be more than 8 characters!")
                .MaximumLength(32)
                .WithMessage("Password must be less than 32 characters!");

        }
    }
}
