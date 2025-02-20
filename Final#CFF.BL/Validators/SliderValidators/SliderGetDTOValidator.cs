using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.SliderDTOs;
using FluentValidation;

namespace Final_CFF.BL.Validators.SliderValidators;

public class SliderGetDTOValidator:AbstractValidator<SliderGetDTO>
{
    public SliderGetDTOValidator()
    {
        RuleFor(g => g.Title)
          .NotNull()
          .NotEmpty()
          .WithMessage("Title is required");
        RuleFor(g => g.Subtitle)
            .NotEmpty()
            .NotNull()
            .WithMessage("Subtitle is Required");
    }
}
