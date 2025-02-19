﻿namespace Modelos.IntegradorCRM.Models.Retornos
{
    public class RetornoBoleto
    {
        public string Num_DocReceber { get; set; }
        public string Id_DocReceber { get; set; }
        public string Id_Entidade { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Identificador_Cliente { get; set; }
        public string Situacao { get; set; }
        public DateTime Data_Vencimento { get; set; }
    }
}
