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

namespace NuevoHotel.Pages.ReservaSalones
{
    public class EditModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;

        public EditModel(NuevoHotel.Data.NuevoHotelContext context)
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

            var reservasalon =  await _context.ReservaSalon.FirstOrDefaultAsync(m => m.CodigoReservaSalon == id);
            if (reservasalon == null)
            {
                return NotFound();
            }
            ReservaSalon = reservasalon;
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

            _context.Attach(ReservaSalon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaSalonExists(ReservaSalon.CodigoReservaSalon))
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

        private bool ReservaSalonExists(int id)
        {
            return _context.ReservaSalon.Any(e => e.CodigoReservaSalon == id);
        }
    }
}
