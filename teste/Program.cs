using SolidOpsTrabalho.Infra.CSV;
using SolidOpsTrabalho.Infra.CSV.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidOpsTrabalho.Infra.Utils;
using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using SolidOpsTrabalho.Dominio.Features.Vendas;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime  inicio = DateTime.Now;
            Venda venda = new Venda();
            CSVService a = new CSVService();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktop, "testeCSV/");
            string filePath = "";
            VendaTask vendaTask = new VendaTask();

            //a.GerarMassaDados(folderPath, 30);
            for (int i = 0; i < 3000; i++)
            {
                filePath = Path.Combine(desktop, "testeCSV/Venda" + i + ".csv");
                var s = a.LeiturasDeDados(filePath);
                foreach (var item in s)
                {
                    Debug.Write(item.Id);

                }
                vendaTask.TaskLeitura(filePath);
            }



            DateTime fim = DateTime.Now;

            TimeSpan x = fim - inicio;

            Console.WriteLine(x);
            Console.ReadKey();

            

            
        }
    }
}
