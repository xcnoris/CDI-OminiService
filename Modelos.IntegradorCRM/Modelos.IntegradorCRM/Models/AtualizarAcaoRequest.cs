﻿namespace Modelos.IntegradorCRM.Models
{
    public class AtualizarAcaoRequest
    {
        public string codigoOportunidade { get; set; }
        public string codigoAcao { get; set; }
        public string codigoJornada { get; set; }
        public string textoFollowup { get; set; }
    }
}
