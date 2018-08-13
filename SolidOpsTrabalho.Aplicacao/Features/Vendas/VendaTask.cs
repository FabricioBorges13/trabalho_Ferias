using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Aplicacao.Features.Vendas
{
    public class VendaTask
    {
        public VendaTask()
        {
            var vendaTask = Task.Run(() => LerArquivos());
        }

        private void LerArquivos()
        {
            throw new NotImplementedException();
        }
    }
}
