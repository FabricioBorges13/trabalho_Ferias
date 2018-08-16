using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.Utils
{
    public static class ScannerDePasta
    {

        public static List<string> ListarArquivos(string caminho)
        {
            List<string> arquivos = new List<string>();

            DirectoryInfo pasta = new DirectoryInfo(caminho);
            FileInfo[] files = pasta.GetFiles("*.csv");

            foreach(FileInfo file in files)
            {
                arquivos.Add(file.Name);
            }

            return arquivos;
        }
    }
}
