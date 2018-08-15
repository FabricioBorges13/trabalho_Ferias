using SolidOpsTrabalho.Dominio.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.Dados.Features.Vendas
{
    [ExcludeFromCodeCoverage]
    public class VendaEntityConfiguration: EntityTypeConfiguration<Venda>
    {
        public VendaEntityConfiguration()
        {
            ToTable("TBVenda");

            this.HasKey(o => o.Id);

            this.Property(o => o.NomeDoCliente).IsRequired();
            this.Property(o => o.PrecoUnitario).IsRequired();
            this.Property(o => o.Produto).IsRequired();
            this.Property(o => o.Quantidade).IsRequired();
            this.Property(o => o.VendaValida).IsRequired();
        } 

    }
}
