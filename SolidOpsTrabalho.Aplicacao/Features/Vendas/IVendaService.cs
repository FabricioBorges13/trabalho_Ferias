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
        List<string> ListarArquivos(string caminho);
        void Adicionar(Venda venda);
    }
}
