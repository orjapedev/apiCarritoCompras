using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace apiCarritoCompras.Model
{
    public partial class PlanesProducto
    {
        [JsonIgnore]
        public int? IdPlan { get; set; }
        [JsonIgnore]
        public int? IdProducto { get; set; }

        public virtual Plane IdPlanNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
