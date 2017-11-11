

namespace GestionTickets.Domain
{

    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Region
    {
        [Key]
        public int IDRegion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]
        [Index("Region_Descripcion_Index", IsUnique = true)]
        public string NombreRegion { get; set; }


        [JsonIgnore]
        public virtual ICollection<Ciudad> Ciudads { get; set; }

    }
}
