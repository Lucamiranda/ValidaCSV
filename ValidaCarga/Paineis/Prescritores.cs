using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ValidaCarga
{
    internal class Prescritores
    {
        private List<Modelo> csv;
        private int filial;
        private DateTime inicio;
        private DateTime fim;

        public Prescritores(List<Modelo> lista, int codFilial, DateTime dataInicio, DateTime dataFim)
        {
            csv = lista;
            filial = codFilial;
            inicio = dataInicio;
            fim = dataFim;
        }

        public List<Tuple<string, double, int, int, int, double>> ReceitasPrescritores()
        {
            List<Tuple<string, double, int, int, int, double>> lista = new List<Tuple<string, double, int, int, int, double>>();

            double ticketMedio;



            var tipo = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusItem.Equals("Aprovado"))
                        .GroupBy(Clientes => Clientes.nomePrescritor)
                        .Select(cliente => new
                        {
                            cliente = cliente.Key,
                            valor = cliente.Sum(x => x.valorLiquidoTotal),
                            codigoItem = cliente.Select(x => x.codigoItem),
                            itens = cliente.Sum(x => x.quantidadeItem),
                            pedidos = cliente.Select(x => x.pedido),

                        });

            foreach (var item in tipo)
            {
                ticketMedio = item.valor / item.pedidos.Distinct().Count();


                lista.Add(Tuple.Create(item.cliente.ToString(), item.valor, item.codigoItem.Distinct().Count(), item.itens, item.pedidos.Distinct().Count(), ticketMedio));

            }

            return lista;
        }
        public List<Tuple<string, double, int, int, double>> Especialidades()
        {

            List<Tuple<string, double, int,  int, double>> lista = new List<Tuple<string, double, int, int, double>>();

            double ticketMedio;

            var tipo = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusItem.Equals("Aprovado"))
                        .GroupBy(Clientes => Clientes.especialidadePrescritor)
                        .Select(cliente => new
                        {
                            cliente = cliente.Key,
                            valor = cliente.Sum(x => x.valorLiquidoTotal),
                            itens = cliente.Select(x => x.codigoItem),
                            pedidos = cliente.Select(x => x.pedido),

                        });

            foreach (var item in tipo)
            {
                ticketMedio = item.valor / item.pedidos.Distinct().Count();
                lista.Add(Tuple.Create(item.cliente.ToString(), item.valor, item.itens.Distinct().Count(), item.pedidos.Distinct().Count(), ticketMedio));

            }

            return lista;
        }
    }
}
