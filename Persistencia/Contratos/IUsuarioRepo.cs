using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.Contratos
{
    interface IUsuarioRepo
    {
        bool Ingresar(string nombreUsuario, string password, string programa);
    }
}
