

namespace GestionTickets.Domain
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Estado
    {
        [Key]
        public int IDEstado { get; set; }

        public string NombreEstado { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
