﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Models.EF
{
    internal class BoletoAcoesCRMModel
    {
        public int Id { get; set; }
        public int Dias_Cobrancas { get; set; }
        public string Codigo_Acao { get; set; }
        public string Mensagem_Atualizacao { get; set; }
    }
}
