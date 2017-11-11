namespace GestionTickets.Domain
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ciudad
    {
        [Key]
        public int IDCiudad { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido.")]
        [MaxLength(50,ErrorMessage ="El campo {0} solo puede contener {1} caracteres.")]
        [Index("Ciudad_Descripcion_Index",IsUnique =true)]
        public string NombreCiudad { get; set; }


        public int IDRegion { get; set; }
        [Display(Name = "Region")]
        [JsonIgnore]
        public virtual Region Region { get; set; }


        [JsonIgnore]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}

