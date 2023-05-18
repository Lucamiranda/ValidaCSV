using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCarga.Paineis
{
    internal class Vendedores
    {

        private List<Modelo> csv;
        private int filial;
        private DateTime inicio;
        private DateTime fim;

        public Vendedores(List<Modelo> lista, int codFilial, DateTime dataInicio, DateTime dataFim)
        {
            csv = lista;
            filial = codFilial;
            inicio = dataInicio;
            fim = dataFim;
        }

        public List<Tuple<string, double, int, int, double, int, int>> VendasVendedor()
        {

            List<Tuple<string, double, int,  int, double, int, int>> lista = new List<Tuple<string, double, int, int, double, int, int>>();

            double ticketMedio;

            var tipo = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusItem.Equals("Aprovado"))
                        .GroupBy(Clientes => Clientes.nomeUsarioAprovacao)
                        .Select(cliente => new
                        {
                            cliente = cliente.Key,
                            valor = cliente.Sum(x => x.valorLiquidoTotal),
                            pedidos = cliente.Select(x => x.pedido),
                            clientes = cliente.Select(x => x.idCliente),
                            qntItens = cliente.Sum(x => x.quantidadeItem),
                            tipoItens = cliente.Select(x => x.codigoItem),

                        });

            foreach (var item in tipo)
            {
                ticketMedio = item.valor / item.pedidos.Distinct().Count();
                lista.Add(Tuple.Create(item.cliente.ToString(), item.valor, item.pedidos.Distinct().Count(),item.clientes.Distinct().Count(), ticketMedio, item.qntItens, 
                    item.tipoItens.Distinct().Count()));

            }

            return lista;

        }
    }
}
