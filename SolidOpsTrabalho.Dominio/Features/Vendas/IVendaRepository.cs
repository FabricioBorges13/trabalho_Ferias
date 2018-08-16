using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Dominio.Features.Vendas
{
    public interface IVendaRepository
    {
        void Adicionar(Venda venda);
    }
}
