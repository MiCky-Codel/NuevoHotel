using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.ReservaRestaurantes
{
    public class EditModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public EditModel(NuevoHotel.Data.NuevoHotelContext context)
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

            var reservarestaurante =  await _context.ReservaRestaurante.FirstOrDefaultAsync(m => m.CodigoReservaRestaurante == id);
            if (reservarestaurante == null)
            {
                return NotFound();
            }
            ReservaRestaurante = reservarestaurante;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReservaRestaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaRestauranteExists(ReservaRestaurante.CodigoReservaRestaurante))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReservaRestauranteExists(int id)
        {
            return _context.ReservaRestaurante.Any(e => e.CodigoReservaRestaurante == id);
        }
    }
}
