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
    public class DetailsModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public DetailsModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

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
    }
}
