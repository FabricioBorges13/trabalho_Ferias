using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SolidOpsTrabalho.Aplicacao.Features.Vendas
{
    public class VendaTask
    {
        public VendaTask()
        {
            string diretorio = @"C:\Users\fabri\Desktop\teste";
            var vendaTask = Task.Run(() => LerArquivos(diretorio));
        }

        private void LerArquivos(string path)
        {
            FileStream caminho = File.OpenRead(path);
            var arquivos = Directory.GetFiles("*.csv");

            Thread.CurrentThread.Start();
        }
    }
}
