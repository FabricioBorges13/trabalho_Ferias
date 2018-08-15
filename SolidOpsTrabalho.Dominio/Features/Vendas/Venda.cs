using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Dominio.Features.Vendas
{
    public class Venda
    {
        public int Id { get; set; }
        public string NomeDoCliente { get; set; }
        public string Produto { get; set; }
        public double PrecoUnitario { get; set; }
        public double PrecoTotal { get { return Quantidade * PrecoUnitario; } }
        public int Quantidade { get; set; }
        public bool VendaValida { get; set; }

        public bool Validar()
        {
            ValidarNomeCliente();
            ValidarProduto();

            return VendaValida;
        }

        private void ValidarProduto()
        {
            if (String.IsNullOrEmpty(Produto))
                VendaValida = false;
            else
                VendaValida = true;
        }

        public void ValidarNomeCliente()
        {
            if (String.IsNullOrEmpty(NomeDoCliente))
                VendaValida = false;
            else
                VendaValida = true;
        }
    }
}
