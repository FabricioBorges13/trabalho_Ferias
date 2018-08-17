using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.CSV;
using SolidOpsTrabalho.Infra.Dados.Context;
using SolidOpsTrabalho.Infra.Dados.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SolidOpsTrabalho.Aplicacao.Features.Vendas
{
    public class VendaTask
    {
        public CSVService _CSVService;
        private string CaminhoPastaDeVendas;
        private string CaminhoPastaDeVendasValidas;
        private string CaminhoPastaDeVendasInvalidas;
        VendaService vendaService;
        string NomeDoArquivo;
        private string CaminhoDoArquivoSendoAnalizado;

        public VendaTask()
        {
            var context = new SolidOpsContext();
            var repository = new VendaRepository(context);
            vendaService = new VendaService(repository);
            CaminhoPastaDeVendas = ConfigurationManager.AppSettings["CaminhoPastaVendas"];
            CaminhoPastaDeVendasValidas = ConfigurationManager.AppSettings["CaminhoPastaVendasValidas"];
            CaminhoPastaDeVendasInvalidas = ConfigurationManager.AppSettings["CaminhoPastaVendasInvalidas"];
            
        }

        public void TaskLeitura(string caminho, string nomeDoArquivo)
        {
            this.NomeDoArquivo = nomeDoArquivo;
            _CSVService = new CSVService();
            CaminhoDoArquivoSendoAnalizado = caminho;
            var leitura = Task.Run(() => LerArquivo(caminho));
            leitura.Wait();
        }

        public void TaskValidarVenda(Venda venda)
        {
            var validar = Task.Run(() => ValidarVenda(venda));
            validar.Wait();
        }

        public void TaskMoverInvalida(Venda venda)
        {
            var invalida = Task.Run(() => MoverParaDiretorioDeVendasInvalidas());
            invalida.Wait();
        }

        public void TaskMoverValida(Venda venda)
        {
            var valida = Task.Run(() => MoverParaDiretorioDeVendasValidas());
            vendaService.Adicionar(venda);
            valida.Wait();
        }

        private void ValidarVenda(Venda venda)
        {
            bool valida = false;
            var x = venda.Validar();
            int i = 0;
            while (!valida)
            {
                if (venda == null || !x || i > 2)
                {
                    TaskMoverInvalida(venda);
                    
                }
                   
                else
                {
                    TaskMoverValida(venda);
                    break;
                }
                    
            }
                      
        }

        private void LerArquivo(string caminho)
        {
            Venda venda = new Venda();
            try
            {
               var vendas = _CSVService.LeiturasDeDados(caminho);

               if (vendas.Count > 1)
                {
                    venda = null;
                } else
                {
                    venda = vendas.LastOrDefault();
                }
            }
            catch (Exception)
            {
                venda = null;             
            }
                     
            TaskValidarVenda(venda);
            
        }

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
            var caminhoVendas = new DirectoryInfo(CaminhoDoArquivoSendoAnalizado);
            string novo = DateTime.Now.Ticks.ToString() ;
            caminho = Path.Combine(caminho, novo + " - " + NomeDoArquivo);

            File.Move(CaminhoDoArquivoSendoAnalizado, caminho);

        }
    }
}
