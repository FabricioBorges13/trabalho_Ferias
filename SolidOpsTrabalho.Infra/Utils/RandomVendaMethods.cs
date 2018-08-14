using SolidOpsTrabalho.Dominio.Features.Vendas;
using System;
using System.Collections.Generic;

namespace SolidOpsTrabalho.Infra.Utils
{
    public static class RandomVendaMethods
    {
        public static List<Venda> gerarListaDeVendaRandom(int quantidade)
        {
            List<Venda> vendasAleatorias = new List<Venda>();
            for (int i = 0; i < quantidade; i++)
            {
                vendasAleatorias.Add(GerarVendaRandom(i));
            }
            return vendasAleatorias;
        }

        public static Venda GerarVendaRandom(int id)
        {
            Random random = new Random();
            Venda venda = new Venda();
            venda.Id = id;
            venda.NomeDoCliente = RandomStringMethods.randomWords();
            venda.PrecoUnitario = random.Next();
            venda.Produto = RandomStringMethods.randomWords();
            venda.Quantidade = random.Next();
            return venda;
        }
    }
}
