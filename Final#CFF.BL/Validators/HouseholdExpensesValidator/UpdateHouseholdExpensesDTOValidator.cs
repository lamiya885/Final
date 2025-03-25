using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.HouseholdExpensesDTOs;
using FluentValidation;

namespace Final_CFF.BL.Validators.HouseholdExpensesValidator
{
    public class UpdateHouseholdExpensesDTOValidator:AbstractValidator<UpdateHoueholdExpenesDTO>
    {
        public UpdateHouseholdExpensesDTOValidator()
        {
            RuleFor(c => c.Price)
           .NotEmpty()
           .NotNull()
           .WithMessage(" Price is required!");
            RuleFor(c => c.Title)
             .NotEmpty()
             .NotNull()
             .WithMessage("Title is required!")
               .MaximumLength(64)
             .WithMessage("Title must be less than 64 caracter");

        }
    }
}
