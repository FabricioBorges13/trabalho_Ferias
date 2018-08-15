using SolidOpsTrabalho.Aplicacao.Features.Vendas;
using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.Dados.Context;
using SolidOpsTrabalho.Infra.Dados.Features.Vendas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Form1()
        {
            InitializeComponent();
            var context = new SolidOpsContext();
            var repository = new VendaRepository(context);
            _service = new VendaService(repository);
            PopularListas();
        }

        public void PopularListas()
        {
            listBox1.DataSource = _service.ObterVendas().ToList();
        }
    }
}
