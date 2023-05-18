using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidaCarga
{
    internal class Clientes
    {
        private List<Modelo> csv;
        private int filial;
        private DateTime inicio;
        private DateTime fim;

        public Clientes(List<Modelo> lista, int codFilial, DateTime dataInicio, DateTime dataFim)
        {
            csv = lista;
            filial = codFilial;
            inicio = dataInicio;
            fim = dataFim;
        }


        public List<Tuple<string, double, int, int, int, double>> VendasClientes()
        {
            List<Tuple<string, double, int, int, int, double>> lista = new List<Tuple<string, double, int, int, int, double>>();
            double ticketMedio;


            var tipo = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusItem.Equals("Aprovado"))
                        .GroupBy(Clientes => Clientes.nomeCliente)
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

        public List<Tuple<string, double, int>> CanalCaptacao()
        {

            List<Tuple<string, double, int>> PorCanal = new List<Tuple<string, double, int>>();

            var tipo = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusItem.Equals("Aprovado"))
            .GroupBy(canal => canal.canalCaptacao)
            .Select(canal => new
            {
                canal = canal.Key,
                clientes = canal.Select(x => x.idCliente),
                valor = canal.Sum(x => x.valorLiquidoTotal)
            });

            foreach (var item in tipo)
            {
                PorCanal.Add(Tuple.Create(item.canal.ToString(), item.valor, item.clientes.Distinct().Count()));
            }

            return PorCanal;
        }


        public List<Tuple<string, string, int>>FaixaEtaria()
        {

            List<Tuple<string,string, int>> idades = new List<Tuple<string,string, int>>();

            var tipo = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusItem.Equals("Aprovado"))
                        .GroupBy(canal => canal.generoCliente)
                        .Select(canal => new
                        {
                            canal = canal.Key,
                            idade0 = canal.Where(x => x.idadeCliente > 0 && x.idadeCliente < 21).Select(x => x.idCliente).Distinct().Count(),
                            idade1 = canal.Where(x => x.idadeCliente >= 21 && x.idadeCliente < 26).Select(x => x.idCliente).Distinct().Count(),
                            idade2 = canal.Where(x => x.idadeCliente >= 26 && x.idadeCliente < 31).Select(x => x.idCliente).Distinct().Count(),
                            idade3 = canal.Where(x => x.idadeCliente >= 31 && x.idadeCliente < 36).Select(x => x.idCliente).Distinct().Count(),
                            idade4 = canal.Where(x => x.idadeCliente >= 36 && x.idadeCliente < 41).Select(x => x.idCliente).Distinct().Count(),
                            idade5 = canal.Where(x => x.idadeCliente >= 41 && x.idadeCliente < 46).Select(x => x.idCliente).Distinct().Count(),
                            idade6 = canal.Where(x => x.idadeCliente >= 46 && x.idadeCliente < 51).Select(x => x.idCliente).Distinct().Count(),
                            idade7 = canal.Where(x => x.idadeCliente >= 51 && x.idadeCliente < 56).Select(x => x.idCliente).Distinct().Count(),
                            idade8 = canal.Where(x => x.idadeCliente > 55).Select(x => x.idCliente).Distinct().Count(),
                            idade9 = canal.Where(x => x.idadeCliente == 0).Select(x => x.idCliente).Distinct().Count()
                        });

            foreach (var item in tipo)
            {
                idades.Add(Tuple.Create("<21", item.canal , item.idade0));
                idades.Add(Tuple.Create( "21 - 25", item.canal, item.idade1));
                idades.Add(Tuple.Create( "26 - 30", item.canal, item.idade2));
                idades.Add(Tuple.Create("31 - 35", item.canal, item.idade3));
                idades.Add(Tuple.Create( "36 - 40", item.canal, item.idade4));
                idades.Add(Tuple.Create("41 - 45", item.canal, item.idade5));
                idades.Add(Tuple.Create("46 - 50", item.canal, item.idade6));
                idades.Add(Tuple.Create("51 - 55", item.canal, item.idade7));
                idades.Add(Tuple.Create(">55", item.canal, item.idade8));
                idades.Add(Tuple.Create("Não Informado", item.canal, item.idade9));
            }

            return idades;
        }
    }
}
