using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.Restautantes
{
    public class DeleteModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public DeleteModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurante Restaurante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurante.FirstOrDefaultAsync(m => m.CodigoRestaurante == id);

            if (restaurante == null)
            {
                return NotFound();
            }
            else
            {
                Restaurante = restaurante;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurante.FindAsync(id);
            if (restaurante != null)
            {
                Restaurante = restaurante;
                _context.Restaurante.Remove(Restaurante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
