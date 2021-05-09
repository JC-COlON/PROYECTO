using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_FINAL.Data.Models
{

    

    [Table("Empleados")]
    public class EmpleadoModel : PersonaModel
    {
        [EnumDataType(typeof(TipoEmpleado)), Display(Name = "Cargo Empleado")]
        public TipoEmpleado Cargo { get; set; }        
    }
}
