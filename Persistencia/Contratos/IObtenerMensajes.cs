﻿using System;
using System.Collections.Generic;
using System.Text;
using Persistencia.Entidades;

namespace Persistencia.Contratos
{
    interface IObtenerMensajes
    {
        List<MensajeEntidad> GetMensajes(long diag);
    }
}
