using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace apiCarritoCompras.Model
{
    public partial class Plane
    {
        public Plane()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPlan { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public string Descripcion { get; set; }
        public decimal? Valor { get; set; }
        public string Frecuencia { get; set; }
        public string Codigo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
