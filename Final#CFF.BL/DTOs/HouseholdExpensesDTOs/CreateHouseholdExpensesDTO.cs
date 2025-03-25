using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.DTOs.HouseholdExpensesDTOs
{
    public class CreateHouseholdExpensesDTO
    {
        public decimal Price { get; set; }
        public string Title { get; set; }
        public bool IsPaid { get; set; }
    }
}
