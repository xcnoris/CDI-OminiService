﻿using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    internal class MetodosGeraisBoleto
    {
        public string Message;
        public bool Status;

        public void AtualizarAcaoNoCRM(int diasAtraso,  string codigoJornada, Frm_DadosAPIUC DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, RelacaoBoletoCRMModel BoletoRelacao, bool foiQuitado, bool naTableRelacao)
        {
            try
            {
                string codAcao = SelecionarCodAcao(diasAtraso);
                string textoFollowup = SelecionarMensagemAtualizacao(diasAtraso);

                AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                {
                    codigoOportunidade = BoletoRelacao.Cod_Oportunidade,
                    codigoAcao = codAcao,
                    codigoJornada = codigoJornada,
                    textoFollowup = textoFollowup
                };

                /*
                    Verifica se o boleto já esta na tabela relação,caso já esteja, significa que não precisa fazer
                    uma consuta no banco para descobrir o Id, visto que a instancia que veio no parametro já tem o Id

                */
                if (foiQuitado)
                {
                    BoletoRelacao.Quitado = 1;
                }
                if (naTableRelacao == true)
                {
                    EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoRelacao, foiQuitado);     
                }
                else
                {
                    RelacaoBoletoCRMModel BoletoInTableRElacao = dalBoleto.BuscarPor(x => x.Id_DocumentoReceber == BoletoRelacao.Id_DocumentoReceber);
                    BoletoInTableRElacao.Situacao = BoletoRelacao.Situacao;
                    BoletoInTableRElacao.DiasEmAtraso = BoletoRelacao.DiasEmAtraso;
                    EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoInTableRElacao, foiQuitado);
                }



                MetodosGerais.RegistrarLog("BOLETO", $"Doc a Receber atualizado para a etapa '{textoFollowup}'");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
            }
        }
        internal void VerificarAtrasoEBoleto(RelacaoBoletoCRMModel boleto, int diasAtraso, string codigoJornada,Frm_DadosAPIUC DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, int DiasAtrasoRelBoleto)
        {
            // Lista de dias para verificar
            int[] diasParaVerificar = { 2, 5, 6, 10, 35 };

            // Verifica se o dia de atraso está na lista e não é igual ao registrado
            if (diasParaVerificar.Contains(diasAtraso) && DiasAtrasoRelBoleto != diasAtraso)
            {
                boleto.DiasEmAtraso = diasAtraso;
                AtualizarAcaoNoCRM(diasAtraso, codigoJornada, DadosAPI, dalBoleto, boleto, false, true);
            }
            else if (!diasParaVerificar.Contains(diasAtraso))
            {
                // Se o dia de atraso não é um dos significativos, registrar no log
                MetodosGerais.RegistrarLog("BOLETO", $"Boleto não está em atraso significativo.");
            }
        }


        internal string SelecionarCodAcao(int diasAtraso)
        {
            try
            {
                switch (diasAtraso)
                {
                    case 1:   // Quitado
                        return "865D7975D28B7C88CBBC";

                    case 2:   // Atraso 2 dias
                        return "29EF5E09D22A38B6D1D1";
                    case 3:  // Estornado/Cancelado
                        return "FE932087C38FC2EBD8C0";

                    case 5: // Atraso 5 dias
                        return "98E9864A3CEFC1679EBC";

                    case 6:  //Atraso 6 dias
                        return "BFB6C9C1B9857FD5919F";

                    case 10:  // Atraso 10 dias
                        return "9A9E99BBCF9FF45B91BB";

                    case 35:  // Atraso 35 dias
                        return "02820F32C84EAE405E5A";
                    

                    default:
                        MetodosGerais.RegistrarLog("BOLETO", "Número inválido. Por favor, escolha um número de 1 a 5.");
                        return null;
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
                return null;
            }

        }

        internal string SelecionarMensagemAtualizacao(int diasAtraso)
        {
            try
            {
                switch (diasAtraso)
                {
                    case 1:  // Pago
                        return "Pago / Aguardando Liberação";

                    case 2:
                        return "Atraso 2 dias";
                    case 3:
                        return "Estornado/Cancelado";

                    case 5:
                        return "Atraso 5 dias";

                    case 6:
                        return "Atraso 6 dias";

                    case 10:
                        return "Atraso 10 dias";

                    case 35:
                        return "Atraso 35 dias";


                    default:
                        MetodosGerais.RegistrarLog("BOLETO", "Número inválido. Por favor, escolha um número de 1 a 5.");
                        return null;
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
                return null;
            }
        }
    }
}
