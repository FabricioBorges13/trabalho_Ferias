using SolidOpsTrabalho.Infra.Dados.Context;
using SolidOpsTrabalho.Infra.Dados.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Topshelf;

namespace SolidOpsTrabalho.Infra.WindowsServices.Features.Vendas
{
    public class TownCrier
    {
        readonly Timer _timer;
        private VendaRepository vendaRepository;
        private SolidOpsContext solidOpsContext;

        public TownCrier()
        {
            solidOpsContext = new SolidOpsContext();
            vendaRepository = new VendaRepository(solidOpsContext);

            var vendas = new AnalizadorDeVendas(vendaRepository);
            vendas.Watch();

            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);
            
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }

    public class ArquivosVendasService
    {

        public static void Main(string[] args)
        {

            var rc = HostFactory.Run(x =>                                   //1
            {
                x.Service<TownCrier>(s =>                                   //2
                {
                    s.ConstructUsing(name => new TownCrier());                //3
                    s.WhenStarted(tc => tc.Start());                         //4
                    s.WhenStopped(tc => tc.Stop());                          //5
                });
                x.RunAsLocalSystem();                                       //6
                
                x.SetDescription("Serviço de analise e processamento de arquivos de vendas");                   //7
                x.SetDisplayName("Vendas Service");                                  //8
                x.SetServiceName("VendasService");                                  //9
            });                                                             //10
            
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            Environment.ExitCode = exitCode;
        }

        public string returnPath()
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            return folder;
        }
    }

   
}
