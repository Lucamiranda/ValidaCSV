using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidaCarga.Paineis;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ValidaCarga
{
    public partial class FrmValida : Form
    {
        CargaInicial carga = new CargaInicial();
        List<Modelo> cargaInicial;

        public FrmValida()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now.AddDays(-180);
            dateTimePicker2.Value = DateTime.Now;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                try
                {
                    openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    openFileDialog.ShowDialog();

                    if(openFileDialog.FileName != "")
                    {
                        txtCaminho.Text = openFileDialog.FileName;
                        cargaInicial = carga.Planilha(txtCaminho.Text);
                        comboBox1.DataSource = carga.Filiais();
                    }             

                }
                catch (FormatException)
                {
                    MessageBox.Show("A importação falhou, valide a planilha.", "Falhou!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Planilha aberta ou invalida!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cargaInicial == null)
            {
                return;
            }
            frmCSV frmCSV = new frmCSV(cargaInicial);
            frmCSV.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpaGrid();
            Pedidos();
            Prescritores();
            Clientes();
            Vendedores();
        }

        public void Vendedores()
        {
            try
            {
                List<Tuple<string, double, int, int, double, int, int>> vendedoresAprovados;
                Vendedores pedidos = new Vendedores(cargaInicial, Convert.ToInt32(comboBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value);
                vendedoresAprovados = pedidos.VendasVendedor();

                dataGridView8.Columns[1].DefaultCellStyle.Format = "C2";
                dataGridView8.Columns[4].DefaultCellStyle.Format = "C2";
                for (int i = 0; i < vendedoresAprovados.Count; i++)
                {

                    dataGridView8.Rows.Add(vendedoresAprovados[i].Item1, Convert.ToDouble(vendedoresAprovados[i].Item2), vendedoresAprovados[i].Item3, vendedoresAprovados[i].Item4,
                        Convert.ToDouble(vendedoresAprovados[i].Item5), vendedoresAprovados[i].Item6, vendedoresAprovados[i].Item7);
                }
            }
            catch (Exception)
            {


            }

        }
        public void Pedidos()
        {

            try
            {
                List<Tuple<double, string, string, int, double, double>> pedidosAprovados;
                Pedidos pedidos = new Pedidos(cargaInicial, Convert.ToInt32(comboBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value);
                pedidosAprovados = pedidos.PedidosAprovados();
                lbVTPedidosAprovados.Text = Convert.ToDouble(pedidosAprovados[0].Item1).ToString("c2");
                lbQntPedidosAprovados.Text = pedidosAprovados[0].Item2;
                lbQtnCPedidosAprovados.Text = pedidosAprovados[0].Item3;
                lbQntItensAprovados.Text = pedidosAprovados[0].Item4.ToString();
                lbTMPPedidosAprovados.Text = Convert.ToDouble(pedidosAprovados[0].Item5).ToString("c2");
                lbTMIPedidosAprovados.Text = Convert.ToDouble(pedidosAprovados[0].Item6).ToString("c2");

                List<Tuple<double, int, int, double>> pedidosRecusados;
                pedidosRecusados = pedidos.PedidosRejeitados();

                lbVTPedidosRejeitados.Text = Convert.ToDouble(pedidosRecusados[0].Item1).ToString("C2");
                lbQntPedidosRejeitados.Text = pedidosRecusados[0].Item2.ToString();
                lbQtnCPedidosRejeitados.Text = pedidosRecusados[0].Item3.ToString();
                lbTMPPedidosRejeitados.Text = Convert.ToDouble(pedidosRecusados[0].Item4).ToString("c2");

                lbValorTotalPedidos.Text = (Convert.ToDouble(pedidosAprovados[0].Item1) + Convert.ToDouble(pedidosRecusados[0].Item1)).ToString("c2");
                lbQntTotalPedidos.Text = (Convert.ToInt32(pedidosAprovados[0].Item2) + Convert.ToInt32(pedidosRecusados[0].Item2)).ToString();

                try
                {
                    List<Tuple<double, int, double>> itensRecusados;
                    itensRecusados = pedidos.ItensRecusados();
                    lbVTItensRecusados.Text = Convert.ToDouble(itensRecusados[0].Item1).ToString("c2");
                    lbQntItensRejeitados.Text = itensRecusados[0].Item2.ToString();
                    lbTMIPedidosRejeitados.Text = Convert.ToDouble(itensRecusados[0].Item3).ToString("c2");
                }
                catch (Exception)
                {


                }
                try
                {
                    List<Tuple<double, int, int, int, double>> noCarrinho;
                    noCarrinho = pedidos.NoCarrinho();
                    lbValorNoCarrinho.Text = Convert.ToDouble(noCarrinho[0].Item1).ToString("c2");
                    lbItensNoCarrinho.Text = noCarrinho[0].Item2.ToString();
                    lbQntPedidosNoCarrinho.Text = noCarrinho[0].Item3.ToString();
                    lbQtnClientesNoCarrinho.Text = noCarrinho[0].Item4.ToString();
                    lbTicketMedioNoCarrinho.Text = Convert.ToDouble(noCarrinho[0].Item5).ToString("c2");

                }
                catch (Exception)
                {


                }
                try
                {
                    List<Tuple<string, double, int>> CanaisCaptacao;
                    CanaisCaptacao = pedidos.PedidosPorCanal();
                    dataGridView1.Columns[1].DefaultCellStyle.Format = "C2";
                    for (int i = 0; i < CanaisCaptacao.Count; i++)
                    {
                        if (CanaisCaptacao[i].Item1.Equals("Balcão"))
                        {
                            dataGridView1.Rows.Add("Sem Canal", Convert.ToDouble(CanaisCaptacao[i].Item2), Convert.ToInt32(CanaisCaptacao[i].Item3));
                        }
                        else
                        {
                            dataGridView1.Rows.Add(CanaisCaptacao[i].Item1, Convert.ToDouble(CanaisCaptacao[i].Item2), Convert.ToInt32(CanaisCaptacao[i].Item3));
                        }

                    }

                    List<Tuple<string, double, int>> TipoItem;
                    TipoItem = pedidos.PedidosPorTipo();
                    dataGridView2.Columns[1].DefaultCellStyle.Format = "C2";
                    for (int i = 0; i < TipoItem.Count; i++)
                    {

                        dataGridView2.Rows.Add(TipoItem[i].Item1, Convert.ToDouble(TipoItem[i].Item2), Convert.ToInt32(TipoItem[i].Item3));
                    }
                }
                catch (Exception)
                {


                }
            }
            catch (Exception)
            {


            }

        }

        public void Clientes()
        {

            try
            {
                List<Tuple<string, double, int, int, int, double>> vendasClientes;
                Clientes cliente = new Clientes(cargaInicial, Convert.ToInt32(comboBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value);
                vendasClientes = cliente.VendasClientes();

                dataGridView3.Columns[1].DefaultCellStyle.Format = "C2";
                dataGridView3.Columns[5].DefaultCellStyle.Format = "C2";
                for (int i = 0; i < vendasClientes.Count; i++)
                {
                    if (vendasClientes[i].Item1 == "")
                    {
                        dataGridView3.Rows.Add("CLIENTE NÃO INFORMADO", Convert.ToDouble(vendasClientes[i].Item2), vendasClientes[i].Item3, vendasClientes[i].Item4, vendasClientes[i].Item5, Convert.ToDouble(vendasClientes[i].Item6));
                    }
                    else
                    {
                        dataGridView3.Rows.Add(vendasClientes[i].Item1, Convert.ToDouble(vendasClientes[i].Item2), vendasClientes[i].Item3, vendasClientes[i].Item4, vendasClientes[i].Item5, Convert.ToDouble(vendasClientes[i].Item6));
                    }
                }

                List<Tuple<string, double, int>> canais;
                canais = cliente.CanalCaptacao();

                dataGridView4.Columns[1].DefaultCellStyle.Format = "C2";
                for (int i = 0; i < canais.Count; i++)
                {
                    if (canais[i].Item1.ToLower().Equals("balcão"))
                    {
                        dataGridView4.Rows.Add("Sem canal", Convert.ToDouble(canais[i].Item2), canais[i].Item3);
                    }
                    else
                    {
                        dataGridView4.Rows.Add(canais[i].Item1, Convert.ToDouble(canais[i].Item2), canais[i].Item3);
                    }
                }

                List<Tuple<string, string, int>> idades;
                idades = cliente.FaixaEtaria();
                dataGridView5.DataSource = idades;
                dataGridView5.Columns[0].HeaderText = "Faixa Etária";
                dataGridView5.Columns[1].HeaderText = "Sexo";
                dataGridView5.Columns[2].HeaderText = "Qtd Clientes";

            }
            catch (Exception)
            {


            }


        }
        private void Prescritores()
        {

            try
            {
                Prescritores precritores = new Prescritores(cargaInicial, Convert.ToInt32(comboBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value);
                List<Tuple<string, double, int, int, int, double>> listaPrescritores;
                listaPrescritores = precritores.ReceitasPrescritores();

                dataGridView6.Columns[1].DefaultCellStyle.Format = "C2";
                dataGridView6.Columns[5].DefaultCellStyle.Format = "C2";
                for (int i = 0; i < listaPrescritores.Count; i++)
                {
                    if (listaPrescritores[i].Item1 == "")
                    {
                        dataGridView6.Rows.Add("PRESCRITOR NÃO INFORMADO", Convert.ToDouble(listaPrescritores[i].Item2), listaPrescritores[i].Item3, listaPrescritores[i].Item4, listaPrescritores[i].Item5, Convert.ToDouble(listaPrescritores[i].Item6));
                    }
                    else
                    {
                        dataGridView6.Rows.Add(listaPrescritores[i].Item1, Convert.ToDouble(listaPrescritores[i].Item2), listaPrescritores[i].Item3, listaPrescritores[i].Item4, listaPrescritores[i].Item5, Convert.ToDouble(listaPrescritores[i].Item6));
                    }
                }


                List<Tuple<string, double, int, int, double>> especialidades;
                especialidades = precritores.Especialidades();
                dataGridView7.Columns[1].DefaultCellStyle.Format = "C2";
                dataGridView7.Columns[4].DefaultCellStyle.Format = "C2";

                for (int i = 0; i < especialidades.Count; i++)
                {
                    if (especialidades[i].Item1 == "")
                    {
                        dataGridView7.Rows.Add("ESPECIALIDADE NÃO INFORMADA", Convert.ToDouble(especialidades[i].Item2), especialidades[i].Item3, especialidades[i].Item4, Convert.ToDouble(especialidades[i].Item5));
                    }
                    else
                    {
                        dataGridView7.Rows.Add(especialidades[i].Item1, Convert.ToDouble(especialidades[i].Item2), especialidades[i].Item3, especialidades[i].Item4, Convert.ToDouble(especialidades[i].Item5));
                    }
                }
            }
            catch (Exception)
            {


            }


        }
        private void LimpaGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.DataSource = null;
            dataGridView6.Rows.Clear();
            dataGridView7.Rows.Clear();
            dataGridView8.Rows.Clear();

            lbItensNoCarrinho.Text = "";
            lbQntClientesTotalPedidos.Text = "";
            lbQntItensAprovados.Text = "";
            lbQntItensRejeitados.Text = "";
            lbQntPedidosAprovados.Text = "";
            lbQntPedidosNoCarrinho.Text = "";
            lbQntPedidosRejeitados.Text = "";
            lbQntTotalPedidos.Text = "";
            lbQtnClientesNoCarrinho.Text = "";
            lbQtnCPedidosAprovados.Text = "";
            lbQtnCPedidosRejeitados.Text = "";
            lbTicketMedioNoCarrinho.Text = "";
            lbTMIPedidosAprovados.Text = "";
            lbTMIPedidosRejeitados.Text = "";
            lbTMPPedidosAprovados.Text = "";
            lbTMPPedidosRejeitados.Text = "";
            lbValorNoCarrinho.Text = "";
            lbValorTotalPedidos.Text = "";
            lbVTItensRecusados.Text = "";
            lbVTPedidosAprovados.Text = "";
            lbVTPedidosRejeitados.Text = "";
        }
    }
}
