using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.Dados.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.Dados.Features.Vendas
{
    public class VendaRepository : IVendaRepository
    {
        private SolidOpsContext _context;

        public VendaRepository(SolidOpsContext context)
        {
            _context = context;
        }

        public void Adicionar(Venda venda)
        {
            var newVenda = _context.Vendas.Add(venda);
            _context.SaveChanges();
        }

        public IQueryable<Venda> ObterTodos()
        {
            return _context.Vendas;
        }
    }
}
