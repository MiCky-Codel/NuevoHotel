using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.ReservaSalones
{
    public class DeleteModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public DeleteModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReservaSalon ReservaSalon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasalon = await _context.ReservaSalon.FirstOrDefaultAsync(m => m.CodigoReservaSalon == id);

            if (reservasalon == null)
            {
                return NotFound();
            }
            else
            {
                ReservaSalon = reservasalon;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasalon = await _context.ReservaSalon.FindAsync(id);
            if (reservasalon != null)
            {
                ReservaSalon = reservasalon;
                _context.ReservaSalon.Remove(ReservaSalon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
