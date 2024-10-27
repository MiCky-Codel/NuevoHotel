using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.ReservaHabitaciones
{
    public class CreateModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public CreateModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ReservaHabitacion ReservaHabitacion { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ReservaHabitacion.Add(ReservaHabitacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
