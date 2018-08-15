﻿using SolidOpsTrabalho.Dominio.Features.Vendas;
using SolidOpsTrabalho.Infra.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOpsTrabalho.Aplicacao.Features.Vendas
{
    public class VendaService : IVendaService
    {
        public IVendaRepository _repository;

        public VendaService(IVendaRepository repository)
        {
            _repository = repository;
        }

        public void Atualizar()
        {
            throw new NotImplementedException();
        }

        public void Finalizar()
        {
            throw new NotImplementedException();
        }

        public void Inicializar()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Venda> ObterVendas()
        {
            return _repository.ObterTodos();
        }
    }
}