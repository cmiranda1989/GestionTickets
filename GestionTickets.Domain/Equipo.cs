

namespace GestionTickets.Domain
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Equipo
    {
        [Key]
        public int IDEquipo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]
        [Index("Ciudad_Descripcion_Index", IsUnique = true)]
        public string NombreEquipo { get; set; }


        public int IDCategoria { get; set; }
        [Display(Name = "Categoria")]
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
