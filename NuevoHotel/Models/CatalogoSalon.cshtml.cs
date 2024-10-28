using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;

namespace NuevoHotel.Models
{
    public class CatalogoSalonModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public CatalogoSalonModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        public IList<Salon> Salon { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Salon = await _context.Salon.ToListAsync();
        }
    }
}
