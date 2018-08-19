using SimpleInjector;
using SimpleInjector.Lifestyles;
using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.Dados.Context;
using SolidOpsTrabalho.Infra.Dados.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Infra.WindowsServices.IoC
{
    public class SimpleInjectorContainer
    {
        public static VendaTask Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterServices(container);

            container.Verify();

            return container.GetInstance<VendaTask>();
        }

        /// <summary>
        /// Registra todos os serviços que podem ser injetados nos construtores
        /// </summary>
        /// <param name="container">É o contexto de injeção que deve conter as classes que podem ser injetadas</param>
        public static void RegisterServices(Container container)
        {
            container.Register<IVendaService, VendaService>();
            container.Register<IVendaRepository, VendaRepository>();
            // TODO: Por enquanto estaremos criando o contexto do EF por aqui. Precisaremos trocar por uma Factory
            container.Register<SolidOpsContext>(() => new SolidOpsContext(), Lifestyle.Singleton);
        }
    }
}
