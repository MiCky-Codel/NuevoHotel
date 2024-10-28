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

namespace NuevoHotel.Pages.Habitaciones
{
    public class CreateModel : PageModel
    {
        private readonly NuevoHotel.Data.NuevoHotelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        [BindProperty, Display(Name = "imagen de la Habitacion")]
        public IFormFile HabitacionImg { get; set; }

        public CreateModel(NuevoHotel.Data.NuevoHotelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Habitacion Habitacion { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Habitacion.HabitacionImg");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Habitacion.HabitacionImg = HabitacionImg.FileName;
            var imgFile = Path.Combine(_webHostEnvironment.WebRootPath, "img", "habitacion", HabitacionImg.FileName);
            using var fileStream = new FileStream(imgFile, FileMode.Create);
            await HabitacionImg.CopyToAsync(fileStream);
            _context.Habitacion.Add(Habitacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}