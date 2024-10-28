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

namespace NuevoHotel.Pages.Salones
{
    public class EditModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;
        private readonly IWebHostEnvironment _environment;
        [BindProperty, Display(Name = "imagen del salon")]
        public IFormFile? SalonImg { get; set; }
        public EditModel(NuevoHotel.Data.NuevoHotelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        [BindProperty]
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
            Salon = salon;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Salon.SalonImg == null)
            {
                ModelState.Remove("Salon.SalonImg");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (this.SalonImg != null)
            {
                Salon.SalonImg = SalonImg.FileName;
                var imgFile = Path.Combine(_environment.WebRootPath, "Img", "Salon", SalonImg.FileName);
                using var fileStream = new FileStream(imgFile, FileMode.Create);
                await SalonImg.CopyToAsync(fileStream);

            }

            _context.Attach(Salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(Salon.CodigoSalon))
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

        private bool SalonExists(int id)
        {
            return _context.Salon.Any(e => e.CodigoSalon == id);
        }
    }
}