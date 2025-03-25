﻿using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Modelos.IntegradorCRM.Models.EF;
using System.ComponentModel.DataAnnotations;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_OSAcoesCRM_UC : UserControl
    {

        private readonly DAL<OSAcoesCRMModel> dalOSAcoes;
        private List<OSAcoesCRMModel> OSAcaoList;

        public Frm_OSAcoesCRM_UC()
        {
            InitializeComponent();


            dalOSAcoes = new DAL<OSAcoesCRMModel>(new IntegradorDBContext());

            AddColumnDataGridView();
            CarregarListaDeOSAcao();

        }

        internal OSAcoesCRMModel BuscarOSAcoes(int IdCategoria)
        {
            try
            {
                return OSAcaoList.FirstOrDefault(x => x.IdCategoria == IdCategoria);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Integrador Com CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
                return null;
            }
        }
        internal async Task CarregarListaDeOSAcao()
        {
            try
            {
                if (OSAcaoList is not null)
                {
                    OSAcaoList.Clear();
                }
                DAL<OSAcoesCRMModel> _dalOSAcoes = new DAL<OSAcoesCRMModel>(new IntegradorDBContext());
                OSAcaoList = (await _dalOSAcoes.ListarAsync()).ToList();
                CarregarDados();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Integrador Com CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }

        }


        private void Btn_Remover_Click(object sender, EventArgs e)
        {
            try
            {
                var resposta = MessageBox.Show("Você Realmente quer excluir o dado selecionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resposta == DialogResult.Yes)
                {
                    // Retrieve the selected row data
                    var selectedRow = DGV_Dados.CurrentRow;
                    int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    OSAcoesCRMModel OSAcao = OSAcaoList.FirstOrDefault(x => x.Id == id);
                    if (OSAcao is not null)
                    {
                        dalOSAcoes.DeletarAsync(OSAcao);
                        OSAcaoList.Remove(OSAcao);
                        CarregarDados();
                    }

                    MetodosGerais.RegistrarLog("Geral", $"Dado Excluido: Id {OSAcao.Id} - Table: boletoAcoes_CRM");
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Integrador Com CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }

        private void AddColumnDataGridView()
        {
            try
            {
                // Se o DataGridView não tiver colunas, adicione-as
                if (DGV_Dados.Columns.Count == 0)
                {
                    DGV_Dados.Columns.Add("ID", "ID");
                    DGV_Dados.Columns["ID"].ReadOnly = true;
                    DGV_Dados.Columns["ID"].Width = 30;

                    DGV_Dados.Columns.Add("IdCategoria", "ID Categoria");
                    DGV_Dados.Columns["IdCategoria"].Width = 350;


                    DGV_Dados.Columns.Add("Mensagem", "Mensagem Ação");
                    DGV_Dados.Columns["Mensagem"].Width = 450;

                    // Impede que a última coluna ocupe todo o espaço
                    DGV_Dados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"Integrador Com CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }
      
       

      

       

        // Recebe um object e convert para uma linha do DataGridView
        private void AddAcaoToDataGridView(OSAcoesCRMModel OSAcao)
        {
            try
            {
                AddColumnDataGridView();

                // Adicionar a linha ao DataGridView
                DGV_Dados.Rows.Add(
                    OSAcao.Id,
                    OSAcao.IdCategoria,
                    OSAcao.Mensagem_Atualizacao
                );
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Integrador Com CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }

        private async void Btn_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in DGV_Dados.Rows)
                {


                    // Obter o ID da linha
                    var idValue = row.Cells["ID"].Value;
                    int? id = idValue != null ? Convert.ToInt32(idValue) : (int?)null;

                    // Obter os dados da linha
                    int IdCategoria = Convert.ToInt32(row.Cells["IdCategoria"].Value);
                    string codigoAcao = row.Cells["Codigo_Acao"].Value.ToString();
                    string Mensagem = row.Cells["Mensagem"].Value.ToString();


                    // Criar um objeto para representar o registro da linha
                    var osAcao = new OSAcoesCRMModel
                    {
                        Id = id ?? 0,  // Se o ID for nulo, inicialize com 0 para um novo registro
                        IdCategoria = IdCategoria,
                        Mensagem_Atualizacao = Mensagem,

                    };

                    if (id.HasValue && id.Value > 0)
                    {
                        // Verifica se o registro já existe no banco
                        OSAcoesCRMModel registroExistente = await dalOSAcoes.BuscarPorAsync(x => x.Id == id);

                        if (registroExistente != null)
                        {
                            // Atualiza os dados do registro existente
                            registroExistente.IdCategoria = IdCategoria;
                            registroExistente.Mensagem_Atualizacao = Mensagem;
                            registroExistente.Data_Criacao = registroExistente.Data_Criacao;

                            await dalOSAcoes.AtualizarAsync(registroExistente);
                        }
                    }
                    else
                    {
                        // Adiciona um novo registro se o ID for nulo ou 0
                        osAcao.Data_Criacao = DateTime.Now;
                        await dalOSAcoes.AdicionarAsync(osAcao);
                    }
                }

                MessageBox.Show("Dados salvos com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Integrador Com CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
            finally
            {
                CarregarListaDeOSAcao();
            }
        }

        internal async Task CarregarDados()
        {
            try
            {
                if (OSAcaoList is not null)
                {
                    DGV_Dados.Rows.Clear();
                    foreach (OSAcoesCRMModel OS in OSAcaoList)
                    {
                        AddAcaoToDataGridView(OS);
                    }
                }

            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Integrador Com CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }

        private void Txt_DiasCobrancas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere digitado não é um número e não é a tecla de backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancela o evento se o caractere não for válido (não numérico)
                e.Handled = true;
            }
        }

        private void DGV_Dados_DoubleClick(object sender, EventArgs e)
        {
            DoubleCliclGrid();
        }
        private async Task DoubleCliclGrid()
        {
            var selectedRow = DGV_Dados.CurrentRow;


            OSAcoesCRMModel oSAcoes = new OSAcoesCRMModel()
            {
                Id = Convert.ToInt32(selectedRow.Cells["ID"].Value),
                IdCategoria = Convert.ToInt32(selectedRow.Cells["IdCategoria"].Value),
                Mensagem_Atualizacao = selectedRow.Cells["Mensagem"].Value.ToString()
            };

            Frm_CadatroOSAcoes FrmCadastroOS = new Frm_CadatroOSAcoes(false, oSAcoes, "Atualizar");
            await FrmCadastroOS.MostrarFormulario();
            await CarregarListaDeOSAcao();
        }

        private async Task Incluir()
        {

            Frm_CadatroOSAcoes FrmCadastroOS = new Frm_CadatroOSAcoes(true, new OSAcoesCRMModel(), "Incluir");
            await FrmCadastroOS.MostrarFormulario();
            await CarregarListaDeOSAcao();
        }

        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            Incluir();
        }
    }
}
