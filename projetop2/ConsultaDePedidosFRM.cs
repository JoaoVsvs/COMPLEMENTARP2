using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetop2
{
    public partial class ConsultaDePedidosFRM : Form
    {
        public ConsultaDePedidosFRM()
        {
            InitializeComponent();
            ConfigurarListViews();
        }

        private void ConfigurarListViews()
        {
            listViewPedidos.View = View.Details;
            listViewPedidos.Columns.Add("Código do Pedido", 150);
            listViewPedidos.Columns.Add("Data", 150);

            listViewItens.View = View.Details;
            listViewItens.Columns.Add("Produto", 150);
            listViewItens.Columns.Add("Quantidade", 100);
            listViewItens.Columns.Add("Total", 100);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            {
                string cpf = txtCPF.Text.Trim();

                if (string.IsNullOrEmpty(cpf))
                {
                    MessageBox.Show("Por favor, insira um CPF.");
                    return;
                }

                lblNomeCliente.Text = "Nome do Cliente: " + BuscarNomeClientePorCPF(cpf);

                if (CarregarPedidosCliente(cpf))
                {
                    MessageBox.Show("Pedidos carregados com sucesso.");
                }
                else
                {
                    MessageBox.Show("Nenhum pedido encontrado para este CPF.");
                }
            }
        }

        private string BuscarNomeClientePorCPF(string cpf)
        {
            if (cpf == "12345678900") return "João Silva";
            return "Cliente Desconhecido";
        }

        private bool CarregarPedidosCliente(string cpf)
        {
            string caminhoArquivo = @"C:\Users\joaoe\Downloads\P2COMPLEMENTO\projetop2\pedidos.csv";

            if (!File.Exists(caminhoArquivo))
            {
                MessageBox.Show("Arquivo de pedidos não encontrado.");
                return false;
            }

            var linhas = File.ReadAllLines(caminhoArquivo);
            listViewPedidos.Items.Clear();

            foreach (var linha in linhas)
            {
                var dados = linha.Split(';');

                if (dados[0] == cpf)
                {
                    var item = new ListViewItem(dados[1]); // Código do pedido
                    item.SubItems.Add(dados[2]);          // Data do pedido
                    listViewPedidos.Items.Add(item);
                }
            }

            return listViewPedidos.Items.Count > 0;
        }

        private void listViewPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPedidos.SelectedItems.Count == 0) return;

            string codigoPedido = listViewPedidos.SelectedItems[0].Text;
            CarregarItensDoPedido(codigoPedido);
        }

        private void CarregarItensDoPedido(string codigoPedido)
        {
            string caminhoArquivo = @"C:\Users\joaoe\Downloads\P2COMPLEMENTO\projetop2\itens_pedido.csv";

            if (!File.Exists(caminhoArquivo))
            {
                MessageBox.Show("Arquivo de itens do pedido não encontrado.");
                return;
            }

            var linhas = File.ReadAllLines(caminhoArquivo);
            listViewItens.Items.Clear();
            decimal totalPedido = 0;

            foreach (var linha in linhas)
            {
                var dados = linha.Split(';');

                if (dados[0] == codigoPedido)
                {
                    var item = new ListViewItem(dados[1]);
                    item.SubItems.Add(dados[2]);          
                    decimal totalItem = decimal.Parse(dados[3]);
                    totalPedido += totalItem;
                    item.SubItems.Add(totalItem.ToString("C2"));
                    listViewItens.Items.Add(item);
                }
            }

            lblTotalPedido.Text = $"Total do Pedido: {totalPedido:C2}";
        }
    }
}