using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.Habitaciones
{
    public class DeleteModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public DeleteModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Habitacion Habitacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion.FirstOrDefaultAsync(m => m.CodigoHabitacion == id);

            if (habitacion == null)
            {
                return NotFound();
            }
            else
            {
                Habitacion = habitacion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion != null)
            {
                Habitacion = habitacion;
                _context.Habitacion.Remove(Habitacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
