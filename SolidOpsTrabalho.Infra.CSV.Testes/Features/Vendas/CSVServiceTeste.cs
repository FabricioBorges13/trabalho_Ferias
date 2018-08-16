using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.CSV.Testes.Features.Vendas
{
    [TestFixture]
    public class CSVServiceTeste
    {


        string caminhoCsvTeste;
        CSVServiceTeste _csvServiceTeste;

        [SetUp]
        public void SetUp() {
            _csvServiceTeste = new CSVServiceTeste();
            string diretorioLocal = Directory.GetCurrentDirectory();
            caminhoCsvTeste = Path.Combine(diretorioLocal, "Arquivos/teste.csv");
        }
        public void InfraCSV_LeiturasDeDados_DeveRetornarUmaLindasDeVendasValidas()
        {
               
        }
        
    }
}
