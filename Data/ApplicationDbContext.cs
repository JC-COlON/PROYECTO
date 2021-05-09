using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FINAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROYECTO_FINAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PersonaModel> Personas { get; set; }
        public DbSet<EmpleadoModel> Empleados { get; set; }
        
    }
}
