using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FINAL.Data;
using PROYECTO_FINAL.Data.Models;

namespace PROYECTO_FINAL.Pages.Empleados
{
    public class EditModel : PageModel
    {
        private readonly PROYECTO_FINAL.Data.ApplicationDbContext _context;

        public EditModel(PROYECTO_FINAL.Data.ApplicationDbContext context)
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
           ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmpleadoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoModelExists(EmpleadoModel.Id))
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

        private bool EmpleadoModelExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
