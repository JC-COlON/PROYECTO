using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FINAL.Data;
using PROYECTO_FINAL.Data.Models;

namespace PROYECTO_FINAL.Pages.Empleados
{
    public class DeleteModel : PageModel
    {
        private readonly PROYECTO_FINAL.Data.ApplicationDbContext _context;

        public DeleteModel(PROYECTO_FINAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpleadoModel EmpleadoModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpleadoModel = await _context.Empleados
                .Include(e => e.Usuario).FirstOrDefaultAsync(m => m.Id == id);

            if (EmpleadoModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpleadoModel = await _context.Empleados.FindAsync(id);

            if (EmpleadoModel != null)
            {
                _context.Empleados.Remove(EmpleadoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
