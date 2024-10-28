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
    public class CatalogoHabitacionModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public CatalogoHabitacionModel(NuevoHotel.Data.NuevoHotelContext context)
        {
            _context = context;
        }

        public IList<Habitacion> Habitacion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Habitacion = await _context.Habitacion.ToListAsync();
        }
    }
}
