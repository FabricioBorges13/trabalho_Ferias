using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.Dados.Context;
using SolidOpsTrabalho.Infra.Dados.Features.Vendas;
using SolidOpsTrabalho.Infra.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolidOpsTrabalho.Apresentacao
{
    public partial class Form1 : Form
    {
        private IVendaService _service;

        private string CaminhoPastaDeVendas;
        private string CaminhoPastaDeVendasValidas;
        private string CaminhoPastaDeVendasInvalidas;

        public Form1()
        {
            InitializeComponent();
            var context = new SolidOpsContext();
            var repository = new VendaRepository(context);
            _service = new VendaService(repository);
            
            CaminhoPastaDeVendas = ConfigurationManager.AppSettings["CaminhoPastaVendas"];
            CaminhoPastaDeVendasValidas = ConfigurationManager.AppSettings["CaminhoPastaVendasValidas"];
            CaminhoPastaDeVendasInvalidas = ConfigurationManager.AppSettings["CaminhoPastaVendasInvalidas"];

            PopularListas();
        }

        public void PopularListas()
        {
            listBox1.DataSource = _service.ListarArquivos(CaminhoPastaDeVendas);
            listBox2.DataSource = _service.ListarArquivos(CaminhoPastaDeVendasValidas);
            listBox3.DataSource = _service.ListarArquivos(CaminhoPastaDeVendasInvalidas);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PopularListas();
        }
    }
}
