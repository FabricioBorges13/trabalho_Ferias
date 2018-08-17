using SolidOpsTrabalho.Dominio.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.Dados.Context
{
    public class SolidOpsContext: DbContext
    {
        public DbSet<Venda> Vendas { get; set; }

        public SolidOpsContext() : base("SolidOpsTrabalhoDB")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public SolidOpsContext(DbConnection connection) : base(connection, true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Busca todos as configurações criadas nesse assembly, que são as classes que são derivadas de EntityTypeConfiguration
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            // Chama o OnModelCreating do EF para dar continuidade na criação do modelo
            base.OnModelCreating(modelBuilder);
        }

    }
}
