using FluentAssertions;
using Moq;
using NUnit.Framework;
using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using SolidOpsTrabalho.Comum.Testes.Features;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Aplicacao.Testes.Features.Vendas
{
    [TestFixture]
    public class VendaServiceTeste
    {
        Mock<IVendaRepository> _vendaRepositorio;
        VendaService _vendaService;
        Mock<Venda> _venda;

        [SetUp]
        public void ApplService_Venda_Inicializador()
        {
            _vendaRepositorio = new Mock<IVendaRepository>();
            _vendaService = new VendaService(_vendaRepositorio.Object);
            _venda = new Mock<Venda>();
        }

        [Test]
        public void ApplService_Venda_AdicionarDeveSerValido()
        {
            //Arrange
            var cliente = new Venda() { Id = 1 };
            _vendaRepositorio.Setup(x => x.Adicionar(_venda.Object));
            _venda.Setup(x => x.Validar());

            //Action
            _vendaService.Adicionar(_venda.Object);

            //Assert
            _vendaRepositorio.Verify(x => x.Adicionar(_venda.Object));
            _venda.Verify(x => x.Validar());
        }

        [Test]
        public void ApplService_Venda_ListarArquivosDeveSerValido()
        {
            string caminho = @"C:\vendas\vendas";
            var lista = _vendaService.ListarArquivos(caminho);

            lista.Count.Should().BeGreaterThan(0);
         }
    }
}
