using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.BuildingDTOs;
using FluentValidation;

namespace Final_CFF.BL.Validators.Building
{
    public class UpdateBuildingDTOValidator:AbstractValidator<UpdateBuildingDTO>
    {
        public UpdateBuildingDTOValidator()
        {
            RuleFor(c => c.BuildingName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Building Name is required");
        }
    }
}
