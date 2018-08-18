﻿using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using SolidOpsTrabalho.Infra.Dados.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 using System.Timers;

namespace SolidOpsTrabalho.Infra.WindowsServices.Features.Vendas
{
    public class AnalizadorDeVendas
    {
        private string CaminhoPastaDeVendas;
        private string CaminhoPastaDeVendasValidas;
        private string CaminhoPastaDeVendasInvalidas;
        private List<String> ArquivosDaPastaDeVendas;

        readonly System.Timers.Timer _timerParaLerAPastaDeTemposETempos;
        private readonly int NumeroDeArquivosParaAguardarAcumular = 15;
        private readonly int NumeroDeArquivosParaProcessarPorLote = 15;
        private readonly int TempoParaAguardarAteAProximaLeituraEmMilesimos = 3000;

        public AnalizadorDeVendas()
        {
            ArquivosDaPastaDeVendas = new List<String>();
            _timerParaLerAPastaDeTemposETempos = new System.Timers.Timer(TempoParaAguardarAteAProximaLeituraEmMilesimos) { AutoReset = true };
            _timerParaLerAPastaDeTemposETempos.Elapsed += (sender, eventArgs) => VerificarAcumuloDeArquivosEMandarParaProcessar();
            _timerParaLerAPastaDeTemposETempos.Start();

            CaminhoPastaDeVendas = ConfigurationManager.AppSettings["CaminhoPastaVendas"];
            CaminhoPastaDeVendasValidas = ConfigurationManager.AppSettings["CaminhoPastaVendasValidas"];
            CaminhoPastaDeVendasInvalidas = ConfigurationManager.AppSettings["CaminhoPastaVendasInvalidas"];
        }
        public void Watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = CaminhoPastaDeVendas;
            watcher.NotifyFilter = NotifyFilters.FileName;

            watcher.Filter = "*.csv";
            //.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;
        }


        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            ArquivosDaPastaDeVendas.Add(e.Name);
        }

        public void VerificarAcumuloDeArquivosEMandarParaProcessar()
        {
            if (ArquivosDaPastaDeVendas.Count > NumeroDeArquivosParaAguardarAcumular) {
                foreach (var item in ArquivosDaPastaDeVendas)
                {
                    Debug.WriteLine(item);
                }
               
                var ArquivosASeremProcessados = ArquivosDaPastaDeVendas.ToList();
                ArquivosDaPastaDeVendas.Clear();

                DividirArquivosEmLotes(ArquivosASeremProcessados);             
            }
        }

        public void DividirArquivosEmLotes(List<String> arquivos)
        {
            var lotesDeArquivos = arquivos.Select((value, index) => new { Index = index, Value = value })
                   .GroupBy(x => x.Index / NumeroDeArquivosParaProcessarPorLote)
                   .Select(g => g.Select(x => x.Value).ToList())
                   .ToList();

            foreach (var lote in lotesDeArquivos)
            {
                ProcessarLoteDeFormaAssincrona(lote);
            }
        }

        public async Task ProcessarLoteDeFormaAssincrona(List<String> arquivos)
        {
            await Task.Run(() => EnviarLoteParaLeituraEValidacao(arquivos));
        }

        public void EnviarLoteParaLeituraEValidacao(List<String> arquivos)
        {
            foreach (var arquivo in arquivos)
            {
                var task = new VendaTask();
                task.TaskLeitura(CaminhoPastaDeVendas + "\\" + arquivo, arquivo);
            }
        }
  
    }
}
