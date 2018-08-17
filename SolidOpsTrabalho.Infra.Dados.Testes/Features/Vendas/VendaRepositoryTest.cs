using Effort;
using FluentAssertions;
using NUnit.Framework;
using SolidOpsTrabalho.Comum.Testes.Features;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.Dados.Features.Vendas;
using SolidOpsTrabalho.Infra.Dados.Testes.Context;
using SolidOpsTrabalho.Infra.Dados.Testes.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.Dados.Testes.Features.Vendas
{
    [TestFixture]
    public class VendaRepositoryTest : EffortTestBase
    {
        private FakeDbContext _ctx;
        private VendaRepository _repository;
        private Venda _venda;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new VendaRepository(_ctx);
            _venda = ObjectMother.Venda;
        }

        [Test]
        public void Venda_Repository_Adicionar_DeveSerOk()
        {
            //Action
            _repository.Adicionar(_venda);
            //Verify
            var vendasRegistered = _ctx.Vendas;
            vendasRegistered.Should().NotBeNull();
        }
    }
}
