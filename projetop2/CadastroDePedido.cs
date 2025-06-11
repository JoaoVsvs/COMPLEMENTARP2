using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            dataGridViewItens.Columns.Clear();
            dataGridViewItens.Columns.Add("Produto", "Produto");
            dataGridViewItens.Columns.Add("Quantidade", "Quantidade");
            dataGridViewItens.Columns.Add("Total", "Total");
            dataGridViewItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewItens.MultiSelect = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
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
                lblNome.Text = "Nome do Cliente:";
            }
        }

        private string BuscarNomeClientePorCPF(string cpf)
        {
            if (cpf == "12345678900") return "João Silva";
            return null;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string produto = txtProduto.Text.Trim();
            string quantidadeText = txtQuantidade.Text.Trim();

            if (string.IsNullOrEmpty(produto) || string.IsNullOrEmpty(quantidadeText))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            if (!int.TryParse(quantidadeText, out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            decimal preco = BuscarPrecoProduto(produto);
            if (preco == 0)
            {
                MessageBox.Show("Produto não encontrado.");
                return;
            }

            ItemPedido item = new ItemPedido
            {
                Produto = produto,
                Quantidade = quantidade,
                Preco = preco
            };

            itensPedido.Add(item);
            AtualizarDataGrid();
            AtualizarTotalPedido();
            LimparCamposProduto();
        }

        private decimal BuscarPrecoProduto(string produto)
        {
            if (produto.ToLower() == "caneta") return 2.50m;
            if (produto.ToLower() == "caderno") return 15.00m;
            return 0;
        }

        private void AtualizarDataGrid()
        {
            dataGridViewItens.Rows.Clear();
            foreach (var item in itensPedido)
            {
                dataGridViewItens.Rows.Add(item.Produto, item.Quantidade, item.Total.ToString("C2"));
            }
        }

        private void AtualizarTotalPedido()
        {
            totalPedido = itensPedido.Sum(item => item.Total);
            lblTotal.Text = $"Total do Pedido: {totalPedido.ToString("C2")}";
        }

        private void LimparCamposProduto()
        {
            txtProduto.Clear();
            txtQuantidade.Clear();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridViewItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para remover.");
                return;
            }

            int index = dataGridViewItens.SelectedRows[0].Index;
            if (index >= 0 && index < itensPedido.Count)
            {
                itensPedido.RemoveAt(index);
                AtualizarDataGrid();
                AtualizarTotalPedido();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCPF.Text.Trim()))
            {
                MessageBox.Show("Por favor, informe o CPF do cliente.");
                return;
            }

            if (!itensPedido.Any())
            {
                MessageBox.Show("O pedido está vazio.");
                return;
            }

            try
            {
                string cpf = txtCPF.Text.Trim();
                string caminho = @"C:\Users\joaoe\Downloads\P2COMPLEMENTO\projetop2";
                if (!Directory.Exists(caminho))
                    Directory.CreateDirectory(caminho);

                string arquivoCsv = Path.Combine(caminho, "pedidos.csv");
                bool arquivoExiste = File.Exists(arquivoCsv);

                using (var sw = new StreamWriter(arquivoCsv, true, Encoding.UTF8))
                {
                    if (!arquivoExiste)
                    {
                        // Cabeçalho do CSV
                        sw.WriteLine("CPF Cliente,Nome Cliente,Produto,Quantidade,Preço Unitário,Total Item,Data Pedido");
                    }

                    string nomeCliente = BuscarNomeClientePorCPF(cpf) ?? "Nome Desconhecido";
                    string dataPedido = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    foreach (var item in itensPedido)
                    {
                        string linha = $"{cpf},{nomeCliente},{item.Produto},{item.Quantidade},{item.Preco.ToString("F2")},{item.Total.ToString("F2")},{dataPedido}";
                        sw.WriteLine(linha);
                    }
                }

                MessageBox.Show("Pedido salvo com sucesso no arquivo CSV.");
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o pedido: {ex.Message}");
            }
        }

        private void LimparFormulario()
        {
            txtCPF.Clear();
            lblNome.Text = "Nome do Cliente:";
            itensPedido.Clear();
            AtualizarDataGrid();
            AtualizarTotalPedido();
            LimparCamposProduto();
        }
    }

    public class ItemPedido
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Total => Quantidade * Preco;
    }
}
