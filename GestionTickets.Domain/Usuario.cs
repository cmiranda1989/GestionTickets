using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTickets.Domain
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }

        

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]

        public string Nombre1 { get; set; }

        public string Nombre2 { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string CorreoElectronico { get; set; }

        public string Password { get; set; }


        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
