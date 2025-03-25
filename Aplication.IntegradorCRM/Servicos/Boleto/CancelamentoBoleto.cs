﻿
using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class CancelamentoBoleto
    {
        public async static Task Cancelar(RelacaoBoletoCRMModel boletoRelacao, DadosAPIModels dadosAPI)
        {
            try
            {
                ModeloOportunidadeRequest? RequestQuitacao = await Boleto_Services.InstanciarAcaoRequestSitucaoBoleto(boletoRelacao.Celular_Entidade, Situacao_Boleto.Cancelada_Ou_Estornado);
              

                ModeloOportunidadeRequest? atualizacaoRequest = await Boleto_Services.InstanciarAcaoRequestSitucaoBoleto(boletoRelacao.Celular_Entidade, Situacao_Boleto.Cancelada_Ou_Estornado);
                if (atualizacaoRequest is null)
                {
                    MetodosGerais.RegistrarLog("ENV_BOLETO", $"[ERROR]: Ação de cancelamento não encontrada para o boleto: {boletoRelacao.Id_DocumentoReceber}!");
                    return;
                }

                try
                {
                    await CancelarBoletoNoCRM(boletoRelacao, atualizacaoRequest, dadosAPI);
                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto {boletoRelacao.Id_DocumentoReceber} atualizado para a etapa Cancelada.");
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("ENV_BOLETO", $"[ERROR]: Falha ao atualizar boleto {boletoRelacao.Id_DocumentoReceber} para etapa Cancelado - {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}.Erro ao tentar atualizar boleto para etapa cancelado: {boletoRelacao.Id_DocumentoReceber}");
                //Message = $"[ERROR]: {ex.Message}";
                //Status = false;
            }
        }


        private async static Task CancelarBoletoNoCRM(RelacaoBoletoCRMModel boletoRelacao, ModeloOportunidadeRequest RequestCancelamento, DadosAPIModels DadosAPI)
        {
            using var dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());

            boletoRelacao.Situacao = 3;
            // É passado o parametro "foiQuitado" como true para remover qualquer registro de aviso que esteja aguardando para envio
            await EnviarMensagemBoleto.EnviarMensagem(RequestCancelamento, DadosAPI, dalBoleto, boletoRelacao, true, false, DadosAPI.CodAPI_EnvioPDF);
        }
    }
}
