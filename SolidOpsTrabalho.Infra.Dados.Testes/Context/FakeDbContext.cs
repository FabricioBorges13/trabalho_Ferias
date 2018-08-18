using SolidOpsTrabalho.Infra.Dados.Context;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.Dados.Testes.Context
{
    public class FakeDbContext: SolidOpsContext
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {
        }
    }
}
