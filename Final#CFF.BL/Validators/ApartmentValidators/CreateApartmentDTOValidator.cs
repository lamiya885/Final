using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.AparmentDTOs;
using FluentValidation;

namespace Final_CFF.BL.Validators.ApartmentValidators
{
    public class CreateApartmentDTOValidator:AbstractValidator<CreateApartmentDTO>
    {
        public CreateApartmentDTOValidator()
        {
            RuleFor(c => c.No)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.BuildingName)
                .NotEmpty()
                .NotNull();
            RuleFor(c=>c.BuildingId)
                .NotEmpty()
                .NotNull();
                
        }
    }
}
