

namespace GestionTickets.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        [Key]
        public int IDTicket { get; set; }
        

        public string NumeroTicket { get; set; }

        public int IDCliente { get; set; }
        [Display(Name = "Cliente")]
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }


        [Display(Name ="Fecha de Creacion")]
        [DataType(DataType.MultilineText)]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Fecha de Cierre")]
        [DataType(DataType.MultilineText)]
        public DateTime FechaCierre { get; set; }

        

        [DataType(DataType.MultilineText)]
        public string Problema { get; set; }

        [DataType(DataType.MultilineText)]
        public string DetalleServicio { get; set; }

        public string Tipo { get; set; }

        public string Modelo { get; set; }

        public string Serie { get; set; }

        public string ActivoFijo { get; set; }

        public int IDEquipo { get; set; }
        [Display(Name = "Equipo")]
        [JsonIgnore]
        public virtual Equipo Equipo { get; set; }



        public int IDCajaDepto { get; set; }
        [Display(Name = "CajaDepto")]
        [JsonIgnore]
        public virtual CajaDepto CajaDepto { get; set; }

        public int IDUsuario { get; set; }
        [Display(Name = "Usuario")]
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

        public string HoraEntrada { get; set; }

        public string HoraSalida { get; set; }

        public string Recibe { get; set; }

        public int IDEstado { get; set; }
        [Display(Name = "Estado")]
        [JsonIgnore]
        public virtual Estado Estado  { get; set; }




        


    }
}
