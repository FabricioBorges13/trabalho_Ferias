using FluentAssertions;
using NUnit.Framework;
using SolidOpsTrabalho.Comum.Testes.Features;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Dominio.Testes.Features.Vendas
{
    [TestFixture]
    public class VendasTeste
    {
        [Test]
        public void Venda_Preco_Total()
        {
            double PrecoEsperado = 1;
            Venda venda = ObjectMother.Venda;

            venda.PrecoTotal.Should().Be(PrecoEsperado);
        }

    }
}
