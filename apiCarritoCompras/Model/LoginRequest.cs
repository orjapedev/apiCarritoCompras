using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiCarritoCompras.Model
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El campo transacción es requerido")]
        public string transaccion { get; set; }

        public datosUsuario datosUsuario { get; set; }
    }

    public class datosUsuario
    {
        [Required(ErrorMessage = "El campo email es requerido")]
        public string email { get; set; }
        [Required(ErrorMessage = "El campo password es requerido")]
        public string password { get; set; }
    }
}
