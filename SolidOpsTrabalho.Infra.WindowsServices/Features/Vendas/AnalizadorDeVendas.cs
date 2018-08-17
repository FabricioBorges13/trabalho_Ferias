using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using SolidOpsTrabalho.Infra.Dados.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.WindowsServices.Features.Vendas
{
    public class AnalizadorDeVendas
    {
        private string CaminhoPastaDeVendas;
        private string CaminhoPastaDeVendasValidas;
        private string CaminhoPastaDeVendasInvalidas;

        public AnalizadorDeVendas()
        {
            CaminhoPastaDeVendas = ConfigurationManager.AppSettings["CaminhoPastaVendas"];
            CaminhoPastaDeVendasValidas = ConfigurationManager.AppSettings["CaminhoPastaVendasValidas"];
            CaminhoPastaDeVendasInvalidas = ConfigurationManager.AppSettings["CaminhoPastaVendasInvalidas"];
        }
        public void Watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = CaminhoPastaDeVendas;
            watcher.NotifyFilter = NotifyFilters.Attributes |
                 NotifyFilters.CreationTime |
                 NotifyFilters.FileName |
                 NotifyFilters.LastAccess |
                 NotifyFilters.LastWrite |
                 NotifyFilters.Size |
                 NotifyFilters.Security;
            watcher.Filter = "*.csv";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            DirectoryInfo pasta = new DirectoryInfo(CaminhoPastaDeVendas);
            FileInfo[] Files = pasta.GetFiles("*.csv");

            foreach (FileInfo file in Files)
            {                          
                if (WaitForFile(file))
                {
                    var task = new VendaTask();
                    task.TaskLeitura(CaminhoPastaDeVendas + "\\" + file.Name, file.Name);

                }
            }
           
        }

        private bool WaitForFile(FileInfo file)
        {
            FileStream stream = null;
            bool FileReady = false;
            while (!FileReady)
            {
                try
                {
                    using (stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        FileReady = true;
                    }
                }
                catch (IOException)
                {
                    //File isn't ready yet, so we need to keep on waiting until it is.
                }
                //We'll want to wait a bit between polls, if the file isn't ready.
                if (!FileReady) Thread.Sleep(1000);
            }

            return FileReady;
        }
    }
}
