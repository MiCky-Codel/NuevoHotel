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

namespace NuevoHotel.Pages.Restautantes
{
    public class EditModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;
        private readonly IWebHostEnvironment _environment;
        [BindProperty, Display(Name = "imagen del restaurante")]
        public IFormFile? RestauranteImg {  get; set; }

        public EditModel(NuevoHotel.Data.NuevoHotelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Restaurante Restaurante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante =  await _context.Restaurante.FirstOrDefaultAsync(m => m.CodigoRestaurante == id);
            if (restaurante == null)
            {
                return NotFound();
            }
            Restaurante = restaurante;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Restaurante.RestautanteImg == null)
            {
                ModelState.Remove("Restautate.RestaurateImg");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (this.RestauranteImg != null)
            {
                Restaurante.RestautanteImg = RestauranteImg.FileName;
                var imgFile = Path.Combine(_environment.WebRootPath, "img", "productos", RestauranteImg.FileName);
                using var fileStream = new FileStream(imgFile, FileMode.Create);
                await RestauranteImg.CopyToAsync(fileStream);
            }

            _context.Attach(Restaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(Restaurante.CodigoRestaurante))
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

        private bool RestauranteExists(int id)
        {
            return _context.Restaurante.Any(e => e.CodigoRestaurante == id);
        }
    }
}
