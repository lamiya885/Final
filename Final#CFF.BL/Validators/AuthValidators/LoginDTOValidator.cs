using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Services.Interfaces;
using FluentValidation;

namespace Final_CFF.BL.Validators.AuthValidators;

public class LoginDTOValidator : AbstractValidator<LoginDTO>
{
    private readonly IUserService _service;
    public LoginDTOValidator(IUserService service)
    {
        _service = service;

        RuleFor(x => x.UserNameOrUserEmail)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Password is required!")
            .MinimumLength(8)
            .WithMessage("Password must be more than 8 characters!")
            .MaximumLength(32)
            .WithMessage("Password must be less than 32 characters!");
    }
}
