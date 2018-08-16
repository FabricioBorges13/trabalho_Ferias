using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.CSV;
using System;
using System.Collections.Generic;
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
        string CaminhoPastaDeVendas = @"C:\vendas\vendas";
        private string CaminhoPastaDeVendasValidas = @"C:\vendas\validas";
        private string CaminhoPastaDeVendasInvalidas = @"C:\vendas\invalidas";


        public List<Venda> TaskLeitura(string caminho)
        {
            _CSVService = new CSVService();

            var leitura = Task.Run(() => LerArquivos(caminho));
            leitura.Wait();

            return LerArquivos(caminho).ToList();
        }

        public void TaskValidarVenda(Venda venda)
        {
            var validar = Task.Run(() => ValidarVenda(venda));
            validar.Wait();
        }

        public void TaskMoverInvalida()
        {
            var invalida = Task.Run(() => MoverParaDiretorioDeVendasInvalidas());
            invalida.Wait();
        }

        private void TaskMoverValida()
        {
            var valida = Task.Run(() => MoverParaDiretorioDeVendasValidas());
            valida.Wait();
        }

        private void ValidarVenda(Venda venda)
        {
            if (venda.Validar() == false)
                TaskMoverInvalida();
            else
                TaskMoverValida();
        }       

        private List<Venda> LerArquivos(string caminho)
        {
            var list = _CSVService.LeiturasDeDados(caminho);
            
            var lista = new List<Venda>();

            foreach (var item in list)
            {
                lista.Add(item);
            }
            TaskValidarVenda(lista.LastOrDefault());
            return lista;
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
            var caminhoVendas = new DirectoryInfo(caminho);

            var files = caminhoVendas.GetFiles(".csv");
            files.ToList().ForEach(f => File.Move(CaminhoPastaDeVendas, caminho));
           
        }
    }
}
