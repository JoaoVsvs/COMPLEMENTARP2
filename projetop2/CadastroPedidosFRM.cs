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
    public partial class CadastroPedidosFRM : Form
    {
        private List<Produto> produtos = new List<Produto>();
        private const string FilePath = "produtos.csv";
        public CadastroPedidosFRM()
        {
            InitializeComponent();
            CarregarProdutosDoArquivo();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtPreco.Text) ||
                    string.IsNullOrWhiteSpace(txtDescricao.Text))
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos.");
                    return;
                }

                if (!decimal.TryParse(txtPreco.Text, out decimal preco))
                {
                    MessageBox.Show("Preço inválido.");
                    return;
                }

                Produto produto = new Produto
                {
                    Nome = txtNome.Text,
                    Preco = preco,
                    Descricao = txtDescricao.Text
                };

                produtos.Add(produto);
                SalvarProdutosNoArquivo();

                AtualizarListaProdutos();
                LimparCampos();
            }
        }
    }
}
