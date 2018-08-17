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

        private void TaskMoverValida(Venda venda)
        {
            var valida = Task.Run(() => MoverParaDiretorioDeVendasValidas());
            vendaService.Add(venda);
            valida.Wait();
        }

        private void ValidarVenda(Venda venda)
        {
            if (venda == null || venda.Validar() == false)
                TaskMoverInvalida(venda);
            else
                TaskMoverValida(venda);
        }

        private Venda LerArquivo(string caminho)
        {
            var list = _CSVService.LeiturasDeDados(caminho);
            var venda = new Venda();

            venda = list.LastOrDefault();

            TaskValidarVenda(venda);
            return venda;
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
