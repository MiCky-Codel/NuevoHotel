using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.Restaurantes
{
    public class CreateModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;
        private readonly IWebHostEnvironment _environment;

        [BindProperty, Display(Name = "Imagen del Restaurante")]
        public IFormFile RestauranteImg { get; set; }

        public CreateModel(NuevoHotel.Data.NuevoHotelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaurante Restaurante { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Restaurante.Img");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Restaurante.RestautanteImg = RestauranteImg.FileName;
            var imgFile = Path.Combine(_environment.WebRootPath, "img", "Restaurantes", RestauranteImg.FileName);
            using var fileStream = new FileStream(imgFile, FileMode.Create);
            await RestauranteImg.CopyToAsync(fileStream);
           

            _context.Restaurante.Add(Restaurante);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
