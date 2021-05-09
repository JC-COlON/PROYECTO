using ComunidadDinamica.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_FINAL.Data.Models
{    
 

    [Table("Personas"), Index(nameof(Cedula), IsUnique = true)]
    public class PersonaModel : Auditable
    {
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public Guid Codigo { get; set; }

        [StringLength(100), Required]
        public string Nombre { get; set; }

        [StringLength(100), Required]
        public string Apellidos { get; set; }

        [DisplayName("Feha de Nacimiento"), DataType(DataType.Date)]
        public DateTime? DoB { get; set; }

        [EnumDataType(typeof(SEXO))]
        public SEXO Sexo { get; set; }       

        [StringLength(64)]
        public string Cedula { get; set; }        

        [ForeignKey(nameof(Usuario)), ScaffoldColumn(false)]
        public string UsuarioId { get; set; }

        [ScaffoldColumn(false)]
        public virtual IdentityUser Usuario { get; set; }

        public PersonaModel()
        {
            Codigo = Guid.NewGuid();
            CreadoEl = DateTime.Now;
            IsDeleted = false;
        }

        public string NombreCompleto()
        {
            return $"{Nombre} {Apellidos}";
        }

        public int Edad()
        {
            // Save today's date.
            DateTime today = DateTime.Today;
            DateTime birthdate = Convert.ToDateTime(DoB);
            // Calculate the age.
            int age = (today.Year - birthdate.Year);
            // Go back to the year the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
