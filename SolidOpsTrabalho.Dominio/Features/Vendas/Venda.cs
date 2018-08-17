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
        public double PrecoTotal { get { return Quantidade * PrecoUnitario; } set { } }
        public int Quantidade { get; set; }
        public bool VendaValida { get; set; }

        public virtual bool Validar()
        {
            VendaValida = true;
            ValidarNomeCliente();
            ValidarProduto();

            return VendaValida;
        }

        private void ValidarProduto()
        {
            VendaValida = VendaValida ?  !String.IsNullOrEmpty(Produto) : VendaValida;
        }

        public void ValidarNomeCliente()
        {
            VendaValida = VendaValida ? !String.IsNullOrEmpty(NomeDoCliente) : VendaValida;
        }
        public bool ValidarListaDeVendas(List<Venda> vendas) {
            return vendas.Count == 1;
        }
    }
}
