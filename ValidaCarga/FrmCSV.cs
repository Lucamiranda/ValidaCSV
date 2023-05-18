using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidaCarga
{
    public partial class frmCSV : Form
    {

        public frmCSV(List<Modelo> lista)
        {
            InitializeComponent();
            dataGridView1.DataSource = lista;
            LayoutGrid();
        }

        private void LayoutGrid()
        {
//            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["idSistema"].HeaderText = "ID DO SISTEMA";
            dataGridView1.Columns["descricaoSistema"].HeaderText = "SISTEMA";
            dataGridView1.Columns["tenantEmpresa"].HeaderText = "CÓD. FILIAL";
            dataGridView1.Columns["codigoFilialOrigem"].HeaderText = "ID FILIAL";
            dataGridView1.Columns["descricaoFilialOrigem"].HeaderText = "NOME FILIAL";
            dataGridView1.Columns["descricaoFilialOrigem"].Width = 150;
            dataGridView1.Columns["idOrigemPedido"].HeaderText = "ID PEDIDO";
            dataGridView1.Columns["origemPedido"].HeaderText = "TIPO PEDIDO";
            dataGridView1.Columns["idStatusPedido"].HeaderText = "ID STATUS PEDIDO";
            dataGridView1.Columns["statusOrigem"].HeaderText = "STATUS PEDIDO";
            dataGridView1.Columns["pedido"].HeaderText = "PEDIDOS";
            dataGridView1.Columns["idUsuarioOrcamento"].HeaderText = "CÓD. FUNCIONARIO ORÇAMENTO";
            dataGridView1.Columns["nomeUsuarioOrcamento"].HeaderText = "FUNCIONARIO ORÇAMENTO";
            dataGridView1.Columns["nomeUsuarioOrcamento"].Width = 250;
            dataGridView1.Columns["dataOrcamento"].HeaderText = "DATA ORÇAMENTO";
            dataGridView1.Columns["horaOrcamento"].HeaderText = "HORA ORÇAMENTO";
            dataGridView1.Columns["idCanalCaptacao"].HeaderText = "ID CANAL CAPTAÇÃO";
            dataGridView1.Columns["canalCaptacao"].HeaderText = "CANAL CAPTAÇÃO";
            dataGridView1.Columns["idCliente"].HeaderText = "CÓD. CLIENTE";
            dataGridView1.Columns["nomeCliente"].HeaderText = "NOME CLIENTE";
            dataGridView1.Columns["nomeCliente"].Width = 250;
            dataGridView1.Columns["idCidadeCliente"].HeaderText = "ID CIDADE";
            dataGridView1.Columns["cidadeCliente"].HeaderText = "CIDADE";
            dataGridView1.Columns["cidadeCliente"].Width = 120;
            dataGridView1.Columns["ufCliente"].HeaderText = "UF";
            dataGridView1.Columns["idGenero"].HeaderText = "SIGLA GENERO";
            dataGridView1.Columns["generoCliente"].HeaderText = "GENERO";
            dataGridView1.Columns["idadeCliente"].HeaderText = "IDADE CLIENTE";
            dataGridView1.Columns["numeroPedido"].HeaderText = "PEDIDO MANIPULAÇÃO";
            dataGridView1.Columns["serieManipulado"].HeaderText = "SERIE PEDIDO";
            dataGridView1.Columns["codigoItemVarejo"].HeaderText = "CÓD. ITEM VAREJO";
            dataGridView1.Columns["descricaoItem"].HeaderText = "DESCRIÇÃO ITEM";
            dataGridView1.Columns["descricaoItem"].Width = 300;
            dataGridView1.Columns["unidadeItem"].HeaderText = "UNIDADE ITEM";
            dataGridView1.Columns["idTipoItem"].HeaderText = "ID TIPO ITEM";
            dataGridView1.Columns["descricaoTipoItem"].HeaderText = "DESC. TIPO ITEM";
            dataGridView1.Columns["codigoItem"].HeaderText = "ID FORM. FARM.";
            dataGridView1.Columns["descricaoFormaFarmaceutica"].HeaderText = "DESC. FORM. FARMACEUTICA";
            dataGridView1.Columns["idGrupoVarejo"].HeaderText = "ID GRUPO";
            dataGridView1.Columns["descricaoGrupoVarejo"].HeaderText = "GRUPO DO PRODUTO";
            dataGridView1.Columns["idSetorVerejo"].HeaderText = "SETOR PRODUTO";
            dataGridView1.Columns["descricaoSetorVarejo"].HeaderText = "DESC. SETOR";
            dataGridView1.Columns["descricaoSetorVarejo"].Width = 200;
            dataGridView1.Columns["quantidadeItem"].HeaderText = "QNT. ITEM";
            dataGridView1.Columns["valorUnitarioItem"].HeaderText = "VALOR UNITARIO";
            dataGridView1.Columns["valorUnitarioItem"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["valorLiquidoTotal"].HeaderText = "VALOR TOTAL";
            dataGridView1.Columns["valorLiquidoTotal"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["desconto"].HeaderText = "DESCONTO";
            dataGridView1.Columns["desconto"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["acrescimo"].HeaderText = "ACRESCIMO";
            dataGridView1.Columns["acrescimo"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["subsidio"].HeaderText = "SUBSIDIO";
            dataGridView1.Columns["subsidio"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["taxaEntrega"].HeaderText = "TAXA ENTREGA";
            dataGridView1.Columns["taxaEntrega"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["cortesia"].HeaderText = "CORTESIA";
            dataGridView1.Columns["idStatusItem"].HeaderText = "ID STATUS ITEM";
            dataGridView1.Columns["statusItem"].HeaderText = "STATUS ITEM";
            dataGridView1.Columns["dataAprovacao"].HeaderText = "DATA APROVAÇÃO";
            dataGridView1.Columns["horaAprovacao"].HeaderText = "HORA APROVAÇÃO";
            dataGridView1.Columns["idProfissaoPrescritor"].HeaderText = "ID PRESCRITOR";
            dataGridView1.Columns["siglaProfissaoPrescritor"].HeaderText = "SIGLA PROFISSÃO PRESCRITOR";
            dataGridView1.Columns["descricaoProfissaoPrescritor"].HeaderText = "PROFISSÃO PRECRITO";
            dataGridView1.Columns["ufRegistroPrescritor"].HeaderText = "UF PRESCRITOR";
            dataGridView1.Columns["numeroRegistroPrescritor"].HeaderText = "REG. PRESCRITOR";
            dataGridView1.Columns["nomePrescritor"].HeaderText = "PRESCRITOR";
            dataGridView1.Columns["nomePrescritor"].Width = 250;
            dataGridView1.Columns["idEspecialidade"].HeaderText = "ID ESPECIALIDADE";
            dataGridView1.Columns["especialidadePrescritor"].HeaderText = "ESPECIALIDADE";
            dataGridView1.Columns["idUsuarioAprovacao"].HeaderText = "CÓD. FUNCIONARIO APROVADOR";
            dataGridView1.Columns["nomeUsarioAprovacao"].HeaderText = "FUNCIONARIO APROVADOR";
            dataGridView1.Columns["nomeUsarioAprovacao"].Width = 250;

        }

    }
}
