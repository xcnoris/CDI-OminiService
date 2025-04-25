using System.Net;
using NLog;

namespace Integrador_Com_CRM
{
    internal static class Program
    {
        private static Mutex mutex;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            LogManager.LoadConfiguration("nlog.config");
            string mutexName = "Global\\Integrador_Com_CRM";

            // Tenta criar o Mutex e verifica se j� existe uma inst�ncia.
            bool isNewInstance;
            mutex = new Mutex(true, mutexName, out isNewInstance);

            if (!isNewInstance)
            {
                // Se j� houver uma inst�ncia, exibe uma mensagem e sai.
                MessageBox.Show("O programa j� est� em execu��o.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Frm_Tela_Principal());

            // Mant�m o Mutex ativo para garantir que ele n�o seja liberado at� o fechamento da aplica��o.
            GC.KeepAlive(mutex);
        }
    }
}