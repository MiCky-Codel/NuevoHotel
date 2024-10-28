using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuevoHotel.Data;
using NuevoHotel.Models;

namespace NuevoHotel.Pages.Salones
{
    public class CreateModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;
        private readonly IWebHostEnvironment _environment;
        [BindProperty, Display(Name = "imagen del salon")]
        public IFormFile SalonImg { get; set; }
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
        public Salon Salon { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Salon.SalonImg");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Salon.SalonImg = SalonImg.FileName;
            var imgFile = Path.Combine(_environment.WebRootPath, "img", "salon", SalonImg.FileName);
            using var fileStream = new FileStream(imgFile, FileMode.Create);
            await SalonImg.CopyToAsync(fileStream);

            _context.Salon.Add(Salon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}