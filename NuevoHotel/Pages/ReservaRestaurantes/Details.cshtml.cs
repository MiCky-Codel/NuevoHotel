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
    public class DetailsModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public DetailsModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

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
    }
}
