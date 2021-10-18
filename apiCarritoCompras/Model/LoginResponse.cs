using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCarritoCompras.Model
{
    public class LoginResponse
    {

        public string codigoRetorno { get; set; }

        public string mensajeRetorno { get; set; }

        public Usuario usuario { get; set; }

        public string token { get; set; }
    }


}
