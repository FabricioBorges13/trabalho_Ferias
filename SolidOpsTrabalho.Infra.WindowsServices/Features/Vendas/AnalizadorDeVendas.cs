﻿using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
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
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Hello World!");

            DirectoryInfo pasta = new DirectoryInfo(CaminhoPastaDeVendas);
            FileInfo[] Files = pasta.GetFiles("*.csv");

            foreach (FileInfo file in Files)
            {
                var task = new VendaTask(CaminhoPastaDeVendas +"\\"+ file.Name);
                // o VendaTask deve retornar se o arquivo é valido ou não
                // o AnalizadorDeVenddas vai verificar o retorno e salvar no banco o arquivo no seu lugar correto
            }
           
        }


        //os 3 metodos abaixo vão para dentro do VendaTask, que vai processar e mover os arquivos
        private void MoverParaDiretorioDeVendasValidas()
        {
            MoverArquivo(CaminhoPastaDeVendasValidas);
        }

        private void MoverParaDiretorioDeVendasInvalidas()
        {
            MoverArquivo(CaminhoPastaDeVendasInvalidas);
        }

        private void MoverArquivo(string caminho)
        {
            var caminhoVendas = new DirectoryInfo(CaminhoPastaDeVendas);

          //  if (caminhoParaMover.Exists)
          //  {
                var files = caminhoVendas.GetFiles(".csv");
                files.ToList().ForEach(f => File.Move(CaminhoPastaDeVendas, caminho));
           // }
        }
    }
}
