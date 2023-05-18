using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCarga.Paineis
{
    internal class Pedidos
    {
        private List<Modelo> csv;
        private int filial;
        private DateTime inicio;
        private DateTime fim;

        public Pedidos(List<Modelo> planilha, int codigoFilial, DateTime dataInicio, DateTime dataFim)
        {

            csv = planilha;
            filial = codigoFilial;
            inicio = dataInicio;
            fim = dataFim;
        }
        public Pedidos()
        {

        }

        public List<Tuple<double, string, string, int, double, double>> PedidosAprovados()
        {

            List<Tuple<double, string, string, int, double, double>> Aprovados = new List<Tuple<double, string, string, int, double, double>>();
            double TicketMedioPedidos;
            double TicketMedioItens;

            var PedidosAprovados = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusItem.Equals("Aprovado"))
                .GroupBy(aprovados => aprovados.statusOrigem.Equals("Aprovado"))
                .Select(aprovados => new
                {
                    clientes = aprovados.Select(x => x.idCliente),
                    pedidos = aprovados.Where(x =>x.statusItem.Equals("Aprovado")).Select(x => x.pedido),
                    itens = aprovados.Sum(x => x.quantidadeItem),
                    valor = aprovados.Sum(x => x.valorLiquidoTotal)
                });

            foreach (var pedidoAprovado in PedidosAprovados)
            {
                TicketMedioPedidos = pedidoAprovado.valor / pedidoAprovado.pedidos.Distinct().Count();
                TicketMedioItens = pedidoAprovado.valor / pedidoAprovado.itens;
                Aprovados.Add(Tuple.Create(pedidoAprovado.valor, pedidoAprovado.pedidos.Distinct().Count().ToString(), pedidoAprovado.clientes.Distinct().Count().ToString(),
                    pedidoAprovado.itens, TicketMedioPedidos, TicketMedioItens));
            }
            return Aprovados;

        }

        public List<Tuple<double, int, int, double>> PedidosRejeitados()
        {
            List<Tuple<double, int, int, double>> Rejeitados = new List<Tuple<double, int, int, double>>();
            double TicketMedioPedidos;

            if (csv.Select(x => x.descricaoSistema.Equals("Phusion")).FirstOrDefault().Equals(true))
            {

            }

            var PedidosRejeitados = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusOrigem.Equals("Rejeitado"))
                .GroupBy(rejeitadoPedidos => rejeitadoPedidos.statusOrigem.Equals("Rejeitado"))
                .Select(rejeitado => new
                {
                    clientes = rejeitado.Select(x => x.idCliente),
                    pedidos = rejeitado.Select(x => x.pedido),
                    valor = rejeitado.Sum(x => x.valorLiquidoTotal)
                });

            foreach (var pedidoRejeitado in PedidosRejeitados)
            {
                TicketMedioPedidos = pedidoRejeitado.valor / pedidoRejeitado.pedidos.Distinct().Count();

                Rejeitados.Add(Tuple.Create(pedidoRejeitado.valor, pedidoRejeitado.pedidos.Distinct().Count(), pedidoRejeitado.clientes.Distinct().Count(),
                   TicketMedioPedidos));
            }
            return Rejeitados;
        }
        public List<Tuple<double, int, double>> ItensRecusados()
        {
            List<Tuple<double, int, double>> recusados = new List<Tuple<double, int, double>>();
            double TicketMedioItens;


            var itens = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim && x.statusItem.Equals("Recusado"))
                .GroupBy(rejeitadoPedidos => rejeitadoPedidos.statusItem.Equals("Recusado"))
                .Select(rejeitado => new
                {
                    itens = rejeitado.Sum(x => x.quantidadeItem),
                    valor = rejeitado.Sum(x => x.valorLiquidoTotal)
                });

            foreach (var itensRecusados in itens)
            {
                TicketMedioItens = itensRecusados.valor / itensRecusados.itens;

                recusados.Add(Tuple.Create(itensRecusados.valor, itensRecusados.itens,
                   TicketMedioItens));
            }
            return recusados;
        }

        public List<Tuple<double, int, int, int, double>> NoCarrinho()
        {
            List<Tuple<double, int, int, int, double>> Rejeitados = new List<Tuple<double, int, int, int, double>>();
            double TicketMedioPedidos;


            var PedidosRejeitados = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataOrcamento >= inicio && x.dataOrcamento <= fim && x.statusItem.Equals("No Carrinho"))
                .GroupBy(rejeitadoPedidos => rejeitadoPedidos.statusItem.Equals("No Carrinho"))
                .Select(rejeitado => new
                {
                    itens = rejeitado.Sum(x => x.quantidadeItem),
                    clientes = rejeitado.Select(x => x.idCliente),
                    pedidos = rejeitado.Select(x => x.pedido),
                    valor = rejeitado.Sum(x => x.valorLiquidoTotal)
                });

            foreach (var pedidoRejeitado in PedidosRejeitados)
            {
                TicketMedioPedidos = pedidoRejeitado.valor / pedidoRejeitado.itens;

                Rejeitados.Add(Tuple.Create(pedidoRejeitado.valor, pedidoRejeitado.itens, pedidoRejeitado.pedidos.Distinct().Count(), pedidoRejeitado.clientes.Distinct().Count(),
                   TicketMedioPedidos));
            }
            return Rejeitados;
        }

        public List<Tuple<string, double, int>> PedidosPorCanal()
        {
            List<Tuple<string, double, int>> PorCanal = new List<Tuple<string, double, int>>();


            var canais = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim)
            .GroupBy(porCanal => porCanal.canalCaptacao)
            .Select(porCanal => new
            {
                canal = porCanal.Key,
                pedidos = porCanal.Select(x => x.pedido),
                valor = porCanal.Sum(x => x.valorLiquidoTotal)
            });

            foreach (var item in canais)
            {
                PorCanal.Add(Tuple.Create(item.canal.ToString(), item.valor, item.pedidos.Distinct().Count()));
            }

            return PorCanal;
        }

        public List<Tuple<string, double, int>> PedidosPorTipo()
        {

            List<Tuple<string, double, int>> PorTipo = new List<Tuple<string, double, int>>();

            var tipo = csv.Where(x => x.codigoFilialOrigem.Equals(filial) && x.dataAprovacao >= inicio && x.dataAprovacao <= fim)
            .GroupBy(tipoItem => tipoItem.descricaoTipoItem)
            .Select(tipoItem => new
            {
                canal = tipoItem.Key,
                pedidos = tipoItem.Select(x => x.pedido),
                valor = tipoItem.Sum(x => x.valorLiquidoTotal)
            });

            foreach (var item in tipo)
            {
                PorTipo.Add(Tuple.Create(item.canal.ToString(), item.valor, item.pedidos.Distinct().Count()));
            }

            return PorTipo;

        }
    }
}
