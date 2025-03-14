using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.HeatingSystemDTOs;
using FluentValidation;

namespace Final_CFF.BL.Validators.HeatingSystemValidator
{
    public class CreateHeatingSystemDTOValidator : AbstractValidator<CreateHeatingDTO>
    {
        public CreateHeatingSystemDTOValidator()
        {
            RuleFor(c => c.RadiatorTemperature)
               .NotEmpty()
               .NotNull()
               .WithMessage("Rediator Temperature is required!");
            RuleFor(c => c.HotWaterSupply)
                .NotEmpty()
                .NotNull()
                .WithMessage("Hot Water Supply  is required!");
        }
    }
}
