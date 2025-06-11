using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace projetop2
{
    public partial class CadastroDeProdutosFRM : Form
    {
        private List<Produto> produtos = new List<Produto>();
        private const string FilePath = @"C:\Users\joaoe\Downloads\P2COMPLEMENTO\projetop2\produtos.csv";

        public CadastroDeProdutosFRM()
        {
            InitializeComponent();
            CarregarProdutosDoArquivo();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeProduto.Text) ||
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
                Nome = txtNomeProduto.Text,
                Preco = preco,
                Descricao = txtDescricao.Text
            };

            produtos.Add(produto);
            SalvarProdutosNoArquivo();
            AtualizarDataGrid();
            LimparCampos();
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para atualizar.");
                return;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco))
            {
                MessageBox.Show("Preço inválido.");
                return;
            }

            var index = dataGridView1.SelectedRows[0].Index;
            produtos[index].Nome = txtNomeProduto.Text;
            produtos[index].Preco = preco;
            produtos[index].Descricao = txtDescricao.Text;

            SalvarProdutosNoArquivo();
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var produto in produtos)
            {
                dataGridView1.Rows.Add(produto.Nome, produto.Preco, produto.Descricao);
            }
        }

        private void CarregarProdutosDoArquivo()
        {
            if (File.Exists(FilePath))
            {
                var linhas = File.ReadAllLines(FilePath);
                produtos = linhas.Select(linha =>
                {
                    var campos = linha.Split(';');
                    return new Produto
                    {
                        Nome = campos[0],
                        Preco = decimal.Parse(campos[1]),
                        Descricao = campos[2]
                    };
                }).ToList();

                AtualizarDataGrid();
            }
        }

        private void SalvarProdutosNoArquivo()
        {
            var linhas = produtos.Select(p => $"{p.Nome};{p.Preco};{p.Descricao}").ToList();
            File.WriteAllLines(FilePath, linhas);
        }

        private void LimparCampos()
        {
            txtNomeProduto.Clear();
            txtPreco.Clear();
            txtDescricao.Clear();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um produto para excluir.");
                    return;
                }

                var index = dataGridView1.SelectedRows[0].Index;
                produtos.RemoveAt(index);

                SalvarProdutosNoArquivo();
                AtualizarDataGrid();
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CarregarProdutosDoArquivo();
            AtualizarDataGrid();
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}
