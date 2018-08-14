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
namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVService a = new CSVService();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktop, "as/");

            a.GerarMassaDados(folderPath, 4);
            string filePath = Path.Combine(desktop, "as/Venda3.csv");
            var s = a.LeiturasDeDados(filePath);
            foreach (var item in s)
            {
                Debug.Write(item.Id);
            }
        }
    }
}
