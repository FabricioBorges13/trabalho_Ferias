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


        public VendaTask(string caminho)
        {
            TaskLeitura(caminho);
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

        private void ValidarVenda(Venda venda)
        {
            if (venda.ValidarNomeCliente() == false)
                throw new Exception();

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
    }
}
