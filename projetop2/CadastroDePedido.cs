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
    public partial class CadastroDePedido : Form
    {
        private List<ItemPedido> itensPedido = new List<ItemPedido>();
        private decimal totalPedido = 0;
        public CadastroDePedido()
        {
            InitializeComponent();
            ConfigurarDataGrid();
        }

        private void ConfigurarDataGrid()
        {
            dataGridViewItens.Columns.Add("Produto", "Produto");
            dataGridViewItens.Columns.Add("Quantidade", "Quantidade");
            dataGridViewItens.Columns.Add("Total", "Total");
        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            {
                string cpf = txtCPF.Text.Trim();

                if (string.IsNullOrEmpty(cpf))
                {
                    MessageBox.Show("Por favor, digite um CPF.");
                    return;
                }

                string nomeCliente = BuscarNomeClientePorCPF(cpf);
                if (nomeCliente != null)
                {
                    lblNome.Text = $"Nome do Cliente: {nomeCliente}";
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.");
                }
            }
        }
    }
}
