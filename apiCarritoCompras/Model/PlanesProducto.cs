using System;
using System.Collections.Generic;

#nullable disable

namespace apiCarritoCompras.Model
{
    public partial class PlanesProducto
    {
        public int? IdPlan { get; set; }
        public int? IdProducto { get; set; }

        public virtual Plane IdPlanNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
