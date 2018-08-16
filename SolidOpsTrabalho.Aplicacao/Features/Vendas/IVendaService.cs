using SolidOpsTrabalho.Dominio.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Aplicacao.Features.Vendas
{
    public interface IVendaService
    {
        void Inicializar();
        void Finalizar();
        void Atualizar();
        IQueryable<Venda> ObterVendas();
        
    }
}
