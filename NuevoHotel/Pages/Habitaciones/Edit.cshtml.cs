using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.Habitaciones
{
    public class EditModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;
        private readonly IWebHostEnvironment _environment;
        [BindProperty, Display(Name = "imagen de la Habitacion")]
        public IFormFile? HabitacionImg { get; set; }

        public EditModel(NuevoHotel.Data.NuevoHotelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Habitacion Habitacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion.FirstOrDefaultAsync(m => m.CodigoHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }
            Habitacion = habitacion;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Habitacion.HabitacionImg == null)
            {
                ModelState.Remove("Habitacion.HabitacionImg");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (this.HabitacionImg != null)
            {
                Habitacion.HabitacionImg = HabitacionImg.FileName;
                var imgFile = Path.Combine(_environment.WebRootPath, "Img", "Habitacion", HabitacionImg.FileName);
                using var fileStream = new FileStream(imgFile, FileMode.Create);
                await HabitacionImg.CopyToAsync(fileStream);

            }
            _context.Attach(Habitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionExists(Habitacion.CodigoHabitacion))
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

        private bool HabitacionExists(int id)
        {
            return _context.Habitacion.Any(e => e.CodigoHabitacion == id);
        }
    }
}