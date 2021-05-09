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
    public class IndexModel : PageModel
    {
        private readonly PROYECTO_FINAL.Data.ApplicationDbContext _context;

        public IndexModel(PROYECTO_FINAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EmpleadoModel> EmpleadoModel { get;set; }

        public async Task OnGetAsync()
        {
            EmpleadoModel = await _context.Empleados
                .Include(e => e.Usuario).ToListAsync();
        }
    }
}
