using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCarga
{
    public class Modelo
    {
        
        public string idSistema { get; private set; }
        public string descricaoSistema { get; private set; }
        public string tenantEmpresa { get; private set; }
        public int codigoFilialOrigem { get; private set; }
        public string descricaoFilialOrigem { get; private set; }
        public string idOrigemPedido { get; private set; }
        public string origemPedido { get; private set; }
        public string idStatusPedido { get; private set; }
        public string statusOrigem { get; private set; }        
        public string pedido { get; private set; }
        public string idUsuarioOrcamento { get; private set; }
        public string nomeUsuarioOrcamento { get; private set; }
        public DateTime dataOrcamento { get; private set; }
        public string horaOrcamento { get; private set; }
        public string idCanalCaptacao { get; private set; }
        public string canalCaptacao { get; private set; }
        public string idCliente { get; private set; }
        public string nomeCliente { get; private set; }
        public string idCidadeCliente { get; private set; }
        public string cidadeCliente { get; private set; }
        public string ufCliente { get; private set; }
        public string idGenero { get; private set; }
        public string generoCliente { get; private set; }
        public int idadeCliente { get; private set; }
        public string numeroPedido { get; private set; }
        public string serieManipulado { get; private set; }        
        public string codigoItemVarejo { get; private set; }
        public string descricaoItem { get; private set; }
        public string unidadeItem { get; private set; }
        public string idTipoItem { get; private set; }
        public string descricaoTipoItem { get; private set; }
        public string codigoItem { get; private set; }
        public string descricaoFormaFarmaceutica { get; private set; }
        public  string idGrupoVarejo { get; private set; }
        public string descricaoGrupoVarejo { get; private set; }
        public string idSetorVerejo { get; private set; }
        public string descricaoSetorVarejo { get; private set; }
        public int quantidadeItem { get; private set; }
        public double valorUnitarioItem { get; private set; }
        public double valorLiquidoTotal { get; private set; }
        public string desconto { get; private set; }
        public string acrescimo { get; private set; }
        public string subsidio { get; private set; }
        public string taxaEntrega { get; private set; }
        public string cortesia { get; private set; }
        public string idStatusItem { get; private set; }
        public string statusItem { get; private set; }
        public DateTime dataAprovacao  { get; private set; }
        public string horaAprovacao { get; private set; }
        public string idProfissaoPrescritor { get; private set; }
        public string siglaProfissaoPrescritor { get; private set; }
        public string descricaoProfissaoPrescritor { get; private set; }
        public string ufRegistroPrescritor { get; private set; }
        public string numeroRegistroPrescritor { get; private set; }
        public string nomePrescritor { get; private set; }
        public string idEspecialidade { get; private set; }
        public string especialidadePrescritor { get; private set; }
        public string idUsuarioAprovacao { get; private set; }
        public string nomeUsarioAprovacao { get; private set; }



        public Modelo(string idSistema, string descricaoSistema, string tenantEmpresa, string codigoFilialOrigem, string descricaoFilialOrigem, string idOrigemPedido, string origemPedido, string idStatusPedido, string statusOrigem, string pedidoManipulacao, string pedidoPDV, string idUsuarioOrcamento, string nomeUsuarioOrcamento, string dataOrcamento, string horaOrcamento, string idCanalCaptacao, string canalCaptacao, string idCliente, string nomeCliente, string idCidadeCliente, string cidadeCliente, string ufCliente, string idGenero, string generoCliente, string idadeCliente, string numeroPedido, string serieManipulado, string codigoItemVarejo, string descricaoItem, string unidadeItem, string idTipoItem, string descricaoTipoItem, string idFormaFarmaceutica, string descricaoFormaFarmaceutica, string idGrupoVarejo, string descricaoGrupoVarejo, string idSetorVerejo, string descricaoSetorVarejo, double quantidadeItem, string valorUnitarioItem, string valorLiquidoTotal, string desconto, string acrescimo, string subsidio, string taxaEntrega, string cortesia, string idStatusItem, string statusItem, string dataAprovacao, string horaAprovacao, string idProfissaoPrescritor, string siglaProfissaoPrescritor, string descricaoProfissaoPrescritor, string ufRegistroPrescritor, string numeroRegistroPrescritor, string nomePrescritor, string idEspecialidade, string especialidadePrescritor, string idUsuarioAprovacao, string nomeUsarioAprovacao)
        {
            this.idSistema = idSistema;
            this.descricaoSistema = descricaoSistema;
            this.tenantEmpresa = tenantEmpresa;
            this.codigoFilialOrigem = Convert.ToInt32(codigoFilialOrigem);
            this.descricaoFilialOrigem = descricaoFilialOrigem;
            this.idOrigemPedido = idOrigemPedido;
            this.origemPedido = origemPedido;
            this.idStatusPedido = idStatusPedido;
            this.statusOrigem = statusOrigem;
            if(pedidoManipulacao != "")
            {
                pedido = pedidoManipulacao;
            }
            if(pedidoPDV != "")
            {
                pedido = pedidoPDV;
            }
            this.idUsuarioOrcamento = idUsuarioOrcamento;
            this.nomeUsuarioOrcamento = nomeUsuarioOrcamento;
            this.dataOrcamento = DateTime.ParseExact(dataOrcamento, "ddMMyyyy", CultureInfo.InvariantCulture).Date;
            this.horaOrcamento = horaOrcamento;
            this.idCanalCaptacao = idCanalCaptacao;
            this.canalCaptacao = canalCaptacao;
            this.idCliente = idCliente;
            this.nomeCliente = nomeCliente;
            this.idCidadeCliente = idCidadeCliente;
            this.cidadeCliente = cidadeCliente;
            this.ufCliente = ufCliente;
            this.idGenero = idGenero;
            this.generoCliente = generoCliente;

            if(idadeCliente == "")
            {
                this.idadeCliente = 0;

            }
            else
            {
                this.idadeCliente = Convert.ToInt32(idadeCliente);
            }
            this.numeroPedido = numeroPedido;
            this.serieManipulado = serieManipulado;

            this.descricaoItem = descricaoItem;
            this.unidadeItem = unidadeItem;
            this.idTipoItem = idTipoItem;
            this.descricaoTipoItem = descricaoTipoItem;

            if(idFormaFarmaceutica != "")
            {
                codigoItem = idFormaFarmaceutica;
            }
            if(codigoItemVarejo != "")
            {
                codigoItem = codigoItemVarejo;
            }
            this.descricaoFormaFarmaceutica = descricaoFormaFarmaceutica;
            this.idGrupoVarejo = idGrupoVarejo;
            this.descricaoGrupoVarejo = descricaoGrupoVarejo;
            this.idSetorVerejo = idSetorVerejo;
            this.descricaoSetorVarejo = descricaoSetorVarejo;
            this.quantidadeItem = Convert.ToInt32(quantidadeItem);
            this.valorUnitarioItem = Convert.ToDouble(valorUnitarioItem);
            this.valorLiquidoTotal = Convert.ToDouble(valorLiquidoTotal);
            this.desconto = desconto;
            this.acrescimo = acrescimo;
            this.subsidio = subsidio;
            this.taxaEntrega = taxaEntrega;
            this.cortesia = cortesia;
            this.idStatusItem = idStatusItem;
            this.statusItem = statusItem;
            if(dataAprovacao == "")
            {
                this.dataAprovacao = DateTime.ParseExact(dataOrcamento, "ddMMyyyy", CultureInfo.InvariantCulture).Date;
            }
            else
            {
                this.dataAprovacao = DateTime.ParseExact(dataAprovacao, "ddMMyyyy", CultureInfo.InvariantCulture).Date;
            }
            //this.dataAprovacao = dataAprovacao;
            this.horaAprovacao = horaAprovacao;
            this.idProfissaoPrescritor = idProfissaoPrescritor;
            this.siglaProfissaoPrescritor = siglaProfissaoPrescritor;
            this.descricaoProfissaoPrescritor = descricaoProfissaoPrescritor;
            this.ufRegistroPrescritor = ufRegistroPrescritor;
            this.numeroRegistroPrescritor = numeroRegistroPrescritor;
            this.nomePrescritor = nomePrescritor;
            this.idEspecialidade = idEspecialidade;
            this.especialidadePrescritor = especialidadePrescritor;
            this.idUsuarioAprovacao = idUsuarioAprovacao;
            this.nomeUsarioAprovacao = nomeUsarioAprovacao;
        }

    }
}
