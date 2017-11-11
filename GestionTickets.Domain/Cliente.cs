namespace GestionTickets.Domain
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }

        public int IDCadena { get; set; }
        [Display(Name = "Cadena")]
        [JsonIgnore]
        public virtual Cadena Cadena { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        //[MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]
        public string NumeroLocal { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        //[MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]
        public string Direccion { get; set; }


        public int IDCiudad { get; set; }
        [Display(Name = "Ciudad")]
        [JsonIgnore]
        public virtual Ciudad Ciudad { get; set; }

        






        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
