using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiCarritoCompras.Model
{
    public class PlanRequest
    {
        [Required(ErrorMessage ="El campo transacción es requerido")]
        public string transaccion { get; set; }
    }
}
