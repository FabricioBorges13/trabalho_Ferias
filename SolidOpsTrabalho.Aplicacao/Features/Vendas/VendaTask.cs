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
        

        public VendaTask(string folderPath)
        {
            _CSVService = new CSVService();
            var leitura = Task.Run(() => LerArquivos(folderPath));
            leitura.Wait();

            //var validar = Task.Run(() => ValidarVendar());
            //validar.Wait();
        }

        //private void ValidarVendar()
        //{
        //    throw new NotImplementedException();
        //}

        private void LerArquivos(string caminho)
        {
            _CSVService.LeiturasDeDados(caminho);
        }
    }
}
