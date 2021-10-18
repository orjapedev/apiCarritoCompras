using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCarritoCompras.Model
{
    public class PlanResponse
    {
        public string codigoRetorno { get; set; }

        public List<Plane> retorno { get; set; }
    }

}
