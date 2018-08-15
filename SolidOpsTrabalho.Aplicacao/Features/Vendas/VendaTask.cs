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
        private string CaminhoPastaDeVendas;
        private string CaminhoPastaDeVendasValidas;
        private string CaminhoPastaDeVendasInvalidas;

        public VendaTask(string caminho)
        {
            TaskLeitura(CaminhoPastaDeVendas);
        }
        public void TaskLeitura(string folderPath)
        {
            _CSVService = new CSVService();

            var leitura = Task.Run(() => LerArquivos(folderPath));
            leitura.Wait();
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
            TaskValidarVenda(list.FirstOrDefault());
            var lista = new List<Venda>();

            foreach (var item in list)
            {
                lista.Add(item);
            }

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

            //  if (caminhoParaMover.Exists)
            //  {
            var files = caminhoVendas.GetFiles(".csv");
            files.ToList().ForEach(f => File.Move(CaminhoPastaDeVendas, caminho));
            // }
        }
    }
}
