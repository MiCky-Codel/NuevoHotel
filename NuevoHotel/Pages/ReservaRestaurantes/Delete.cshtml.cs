using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.ReservaRestaurantes
{
    public class DeleteModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public DeleteModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReservaRestaurante ReservaRestaurante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservarestaurante = await _context.ReservaRestaurante.FirstOrDefaultAsync(m => m.CodigoReservaRestaurante == id);

            if (reservarestaurante == null)
            {
                return NotFound();
            }
            else
            {
                ReservaRestaurante = reservarestaurante;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservarestaurante = await _context.ReservaRestaurante.FindAsync(id);
            if (reservarestaurante != null)
            {
                ReservaRestaurante = reservarestaurante;
                _context.ReservaRestaurante.Remove(ReservaRestaurante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
