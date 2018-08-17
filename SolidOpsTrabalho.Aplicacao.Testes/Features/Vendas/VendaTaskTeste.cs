using FluentAssertions;
using Moq;
using NUnit.Framework;
using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using SolidOpsTrabalho.Comum.Testes.Features;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.CSV;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Aplicacao.Testes.Features.Vendas
{
    [TestFixture]
    public class VendaTaskTeste
    {
        VendaTask _vendaTask;
        Mock<CSVService> _csvService;
        Mock<IVendaService> _vendaService;
        Mock<Venda> _venda;
        private string CaminhoPastaDeVendas;
        private string CaminhoPastaDeVendasValidas;
        private string CaminhoPastaDeVendasInvalidas;

        [SetUp]
        public void ApplService_VendaTask_Inicializador()
        {
            CaminhoPastaDeVendas = ConfigurationManager.AppSettings["CaminhoPastaVendas"];
            CaminhoPastaDeVendasValidas = ConfigurationManager.AppSettings["CaminhoPastaVendasValidas"];
            CaminhoPastaDeVendasInvalidas = ConfigurationManager.AppSettings["CaminhoPastaVendasInvalidas"];
            _vendaService = new Mock<IVendaService>();
            _vendaTask = new VendaTask();
            _csvService = new Mock<CSVService>();
            _venda = new Mock<Venda>();
        }

        [Test]
        public void ApplService_VendaTask_TaskLeitura_DeveSerValido()
        {
            _vendaTask.TaskLeitura(CaminhoPastaDeVendas + "\\venda1.csv");

            _vendaTask.Should().NotBeNull();
        }

        [Test]
        public void ApplService_VendaTask_TaskValidar_DeveSerValido()
        {
            _vendaTask.TaskValidarVenda(_venda.Object);

            _vendaTask.Should().NotBeNull();
        }

        [Test]
        public void ApplService_VendaTask_TaskMoverValida_DeveSerValido()
        {
            _vendaTask.TaskMoverValida(_venda.Object);
            _vendaService.Setup(x => x.Adicionar(_venda.Object));
            _vendaTask.Should().NotBeNull();
        }

        [Test]
        public void ApplService_VendaTask_TaskMoverInvalida_DeveSerValido()
        {
            _vendaTask.TaskMoverInvalida(_venda.Object);

            _vendaTask.Should().NotBeNull();
        }
    }
}
