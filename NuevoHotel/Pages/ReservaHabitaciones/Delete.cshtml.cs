using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.ReservaHabitaciones
{
    public class DeleteModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public DeleteModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReservaHabitacion ReservaHabitacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservahabitacion = await _context.ReservaHabitacion.FirstOrDefaultAsync(m => m.CodigoReserva == id);

            if (reservahabitacion == null)
            {
                return NotFound();
            }
            else
            {
                ReservaHabitacion = reservahabitacion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservahabitacion = await _context.ReservaHabitacion.FindAsync(id);
            if (reservahabitacion != null)
            {
                ReservaHabitacion = reservahabitacion;
                _context.ReservaHabitacion.Remove(ReservaHabitacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
