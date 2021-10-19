using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCarritoCompras.Model
{
    public class ProductoResponse
    {

        public string codigoRetorno { get; set; }

        public string mensajeRetorno { get; set; }

        public List<Producto> data { get; set; }
    }

}
