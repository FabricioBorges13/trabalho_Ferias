using CsvHelper.Configuration;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.CSV.Features.Vendas
{
    public class VendaGetMap : ClassMap<Venda>
    {
        public VendaGetMap()
        {
            Map(x => x.Id).Index(0).Name("Id");
            Map(x => x.NomeDoCliente).Index(1).Name("Nome Do Cliente");
            Map(x => x.PrecoUnitario).Index(2).Name("Preco Unitario");
            Map(x => x.Produto).Index(3).Name("Produto");
            Map(x => x.Quantidade).Index(4).Name("Quantidade");
        }
    }
}
