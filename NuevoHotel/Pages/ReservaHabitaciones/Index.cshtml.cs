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
    public class IndexModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public IndexModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        public IList<ReservaHabitacion> ReservaHabitacion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ReservaHabitacion = await _context.ReservaHabitacion.ToListAsync();
        }
    }
}
