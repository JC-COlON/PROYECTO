using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_FINAL.Data
{
    public class IdentidadUsuario : IdentityUser
    {
        [StringLength(128), Required]
        public string Pais
        {
            get; set;
        }
    }
}
