using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ComunidadDinamica.Data.Models
{
    public abstract class Auditable
    {
        [ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreadoEl { get; set; }

        [ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModificadoEl { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? EliminadoEl { get; set; }

        [ScaffoldColumn(false)]
        public string CreadoPor { get; set; }

        [ScaffoldColumn(false)]
        public string ModificadoPor { get; set; }

        [ScaffoldColumn(false)]
        public string EliminadoPor { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }

        [Timestamp, ScaffoldColumn(false), JsonIgnore]
        public byte[] Timestamp { get; set; }
    }
}
