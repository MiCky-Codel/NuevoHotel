using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.Salones
{
    public class DetailsModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public DetailsModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        public Salon Salon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salon = await _context.Salon.FirstOrDefaultAsync(m => m.CodigoSalon == id);
            if (salon == null)
            {
                return NotFound();
            }
            else
            {
                Salon = salon;
            }
            return Page();
        }
    }
}
