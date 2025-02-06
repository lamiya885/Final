using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.SliderDTOs;
using Final_CFF.BL.Services.Interfaces;
using FluentValidation;

namespace Final_CFF.BL.Validators.SliderValidators;

public class CreateSliderDTOValidator:AbstractValidator<CreateSliderDTO>
{
    private readonly ISliderService _service;
    public CreateSliderDTOValidator(ISliderService service)
    {
        _service = service;

        RuleFor(c => c.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title is required");
        RuleFor(c => c.Subtitle)
            .NotEmpty()
            .NotNull()
            .WithMessage("Subtitle is Required");


    }
}
