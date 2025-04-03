using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using DataBase.IntegradorCRM.Data;

namespace MigratorDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CarregarDadosConexao();
        }


        private ConexaoDB LeituraFrmConexaoDB()
        {
            try
            {
                // Caso algum dado seja nulo ele retorna uma mensagem
                if (string.IsNullOrEmpty(Txt_Servidor.Text) ||
                    string.IsNullOrEmpty(Txt_IpHost.Text) ||
                    string.IsNullOrEmpty(Txt_DataBase.Text) ||
                    string.IsNullOrEmpty(Txt_Usuario.Text) ||
                    string.IsNullOrEmpty(Txt_Senha.Text))
                {
                    throw new ArgumentException("Todos os campos de conex�o s�o obrigat�rios.");
                }

                return new ConexaoDB
                {
                    Servidor = Txt_Servidor.Text,
                    IpHost = Txt_IpHost.Text,
                    DataBase = Txt_DataBase.Text,
                    Usuario = Txt_Usuario.Text,
                    Senha = Txt_Senha.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("OS", $"Erro: {ex.Message}");
                throw;
            }
        }

        private void CarregarDadosConexao()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "conexao.json");

                ConexaoDB conexao = ConexaoDB.LoadConnectionData(filePath);
                if (conexao != null)
                {
                    Txt_Servidor.Text = conexao.Servidor;
                    Txt_IpHost.Text = conexao.IpHost;
                    Txt_DataBase.Text = conexao.DataBase;
                    Txt_Usuario.Text = conexao.Usuario;
                    Txt_Senha.Text = conexao.Senha;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados de conex�o: " + ex.Message);
            }
        }





        private void Btn_TEstar_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria uma inst�ncia de ConexaoDB com os dados fornecidos no formul�rio
                ConexaoDB conexao = new ConexaoDB
                {
                    Servidor = Txt_Servidor.Text,
                    IpHost = Txt_IpHost.Text,
                    DataBase = Txt_DataBase.Text,
                    Usuario = Txt_Usuario.Text,

                    Senha = Txt_Senha.Text
                };

                // Monta a string de conex�o com os dados fornecidos
                string connectionString = $"Server={conexao.IpHost};Database={conexao.DataBase};User Id={conexao.Usuario};Password={conexao.Senha};TrustServerCertificate=True";
                MetodosGerais.RegistrarInicioLog("Conex�oDB");
                MetodosGerais.RegistrarLog("Conex�oDB", $"Testando conex�o banco de dados {conexao.DataBase}...");

                // Tenta abrir a conex�o
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    MessageBox.Show("Conex�o bem-sucedida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MetodosGerais.RegistrarLog("Conex�oDB", $"Conex�o bem-sucedida com o banco de dados {conexao.DataBase}!");
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("Conex�oDB", $"Erro ao testar conex�o: {ex.Message}. Verique a string de conex�o!");

                MessageBox.Show("Erro ao testar conex�o: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Conex�oDB", $"Erro ao testar conex�o: {ex.Message}. Verique a string de conex�o!");
                MessageBox.Show("Erro ao testar conex�o: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("Conex�oDB");
            }
        }

        private void Btn_SalvarConexao_Click(object sender, EventArgs e)
        {
            try
            {
                ConexaoDB conexao = LeituraFrmConexaoDB();

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "conexao.json");

                // Salva um arquivo Json com os dados da conex�o
                conexao.SaveConnectionData(filePath);

                MessageBox.Show("Valores Salvos", "Envio de Ordem de Servi�o", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
                throw;
            }
        }

        private void Btn_CriarDataBase_Click(object sender, EventArgs e)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                .AddDbContext<IntegradorDBContext>(options =>
                 options.UseSqlServer($"Server={Txt_IpHost.Text};Database={Txt_DataBase.Text};User Id={Txt_Usuario.Text};Password={Txt_Senha.Text}; TrustServerCertificate=True"))
                .BuildServiceProvider();

                using (var context = serviceProvider.GetService<IntegradorDBContext>())
                {
                    MessageBox.Show($"Aplicando migra��es...", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Aplicando migra��es...");
                    context.Database.Migrate();
                    MessageBox.Show($"Migra��es aplicadas com sucesso.", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.WriteLine("Migra��es aplicadas com sucesso.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Conexao_Erro", $"Erro: {ex.Message}");
                throw;
            }
        }
    }
}
