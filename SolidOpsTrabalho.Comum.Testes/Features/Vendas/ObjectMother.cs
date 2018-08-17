using SolidOpsTrabalho.Dominio.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Comum.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Venda Venda
        {
            get
            {
                return new Venda
                {
                    Id = 1,
                    NomeDoCliente = "Cliente",
                    Produto = "Produto",
                    PrecoUnitario = 1,
                    Quantidade = 1,
                    VendaValida = true
                };
            }
        }

        public static List<Venda> Vendas
        {
            get
            {
                return new List<Venda>
                {
                    Venda,
                    Venda,
                    Venda,
                };
            }
        }
    }
}
