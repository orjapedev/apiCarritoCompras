using System;
using System.Collections.Generic;

#nullable disable

namespace apiCarritoCompras.Model
{
    public partial class Plane
    {
        public Plane()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal? Valor { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
