using System;
using System.Collections.Generic;

#nullable disable

namespace apiCarritoCompras.Model
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public bool? Estado { get; set; }
        public string Detalle { get; set; }
        public string Imagen { get; set; }
    }
}
