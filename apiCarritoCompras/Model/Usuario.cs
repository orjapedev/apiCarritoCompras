using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace apiCarritoCompras.Model
{
    public partial class Usuario
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int? PlanId { get; set; }
        public string Telefono { get; set; }

        [JsonIgnore]
        public string Clave { get; set; }

        [JsonIgnore]
        public virtual Plane Plan { get; set; }
    }
}
