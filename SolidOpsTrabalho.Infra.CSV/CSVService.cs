using CsvHelper;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.CSV.Features.Vendas;
using SolidOpsTrabalho.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.CSV
{
    public class CSVService
    {
        public List<Venda> LeiturasDeDados(string _caminho)
        {
            var _lista = new List<Venda>();
            using (StreamReader _leitura = new StreamReader(_caminho))
            {
                var csvLeitura = new CsvReader(_leitura);
                csvLeitura.Configuration.Delimiter = ";";
                csvLeitura.Configuration.HasHeaderRecord = true;
                csvLeitura.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");
                csvLeitura.Configuration.PrepareHeaderForMatch = (header) => header.ToLower();

                csvLeitura.Configuration.IncludePrivateMembers = true;
                csvLeitura.Configuration.RegisterClassMap<VendaGetMap>();
                _lista = csvLeitura.GetRecords<Venda>().ToList();
            }

            return _lista;
        }

        private void GerarCsv(string caminho, Venda venda)
        {
            string caminhoConcatenado = caminho + "Venda" + venda.Id.ToString() + ".csv".Trim();
            using (var fs = new FileStream(caminhoConcatenado, FileMode.OpenOrCreate))
            {
                using (var streamWriter = new StreamWriter(fs, Encoding.UTF8))
                using (var csvWriter = new CsvWriter(streamWriter))
                {
                    csvWriter.WriteHeader<VendaGetMap>();
                    csvWriter.Configuration.Delimiter = ";";
                    csvWriter.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");
                    csvWriter.Configuration.HasHeaderRecord = true;
                    csvWriter.Configuration.RegisterClassMap<VendaSetMap>();

                    csvWriter.WriteHeader(venda.GetType());
                    csvWriter.NextRecord();

                    csvWriter.WriteRecord(venda);

                    csvWriter.NextRecord();
                }
                fs.Close();
            }
        }

        public void GerarMassaDados(string caminho, int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                GerarCsv(caminho, RandomVendaMethods.GerarVendaRandom(i));
            }
        }
    }

}
