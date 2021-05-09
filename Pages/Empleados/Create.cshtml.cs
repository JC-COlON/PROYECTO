using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CreateModel : PageModel
    {
        private readonly PROYECTO_FINAL.Data.ApplicationDbContext _context;

        public CreateModel(PROYECTO_FINAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public EmpleadoModel EmpleadoModel { get; set; }
        [BindProperty, Required, Display(Name = "Cedula"), StringLength(64), PageRemote(PageHandler = "CedulaVerificada")]
        public string CedulaVerificada { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            EmpleadoModel.Cedula = CedulaVerificada;

            _context.Empleados.Add(EmpleadoModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetCedulaVerificadaAsync(string cedulaverificada)
        {
            var resultado = await _context.Empleados.FirstOrDefaultAsync(em => em.Cedula.Equals(cedulaverificada));

            if (resultado != null)
            {
                return new JsonResult($"Esta Cedula: {cedulaverificada} Ya esta Registrada Con el nombre de: {resultado.NombreCompleto()} ");
            }
            return new JsonResult(true);
        }
    }
}
