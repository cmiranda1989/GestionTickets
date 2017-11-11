

namespace GestionTickets.Domain
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class CajaDepto
    {
        [Key]
        public int IDCajaDepto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]
        public string NombreCajaDepto { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
