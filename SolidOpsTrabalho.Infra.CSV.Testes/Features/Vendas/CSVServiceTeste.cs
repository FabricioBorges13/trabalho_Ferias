using FluentAssertions;
using NUnit.Framework;


using System.Collections.Generic;

using System.IO;



namespace SolidOpsTrabalho.Infra.CSV.Testes.Features.Vendas
{
    [TestFixture]
    public class CSVServiceTeste
    {


        string caminhoCsvTeste;
        CSVService _csvServiceTeste;

        [SetUp]
        public void SetUp() {
            _csvServiceTeste = new CSVService();
            caminhoCsvTeste = Path.GetTempPath();
        }

        [Test]
        public void InfraCSV_LeiturasDeDados_DeveRetornarUmaListaComPeloMenosUmaVenda()
        {
            _csvServiceTeste = new CSVService();
            int quantidadeDeArquivos = 1;
            _csvServiceTeste.GerarMassaDados(caminhoCsvTeste, quantidadeDeArquivos);
            caminhoCsvTeste = Path.Combine(caminhoCsvTeste, "Venda0.csv");

            var s = _csvServiceTeste.LeiturasDeDados(caminhoCsvTeste);

            s.Should().NotBeEmpty();
            File.Delete(caminhoCsvTeste);
        }

        [Test]
        public void InfraCSV_GerarMassaDeDados_DeveGerar_UmArquivoCsvComUmaVendaValida()
        {
            _csvServiceTeste = new CSVService();
            int quantidadeDeArquivos = 1;

            _csvServiceTeste.GerarMassaDados(caminhoCsvTeste, quantidadeDeArquivos);
            caminhoCsvTeste = Path.Combine(caminhoCsvTeste, "Venda0.csv");

            File.Exists(caminhoCsvTeste).Should().BeTrue();
            File.Delete(caminhoCsvTeste);
        }
    }
}
