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
            ConfigurarArquivo();
            ConfigurarDataGridView();
            CarregarProdutosDoArquivo();
        }

        private void ConfigurarArquivo()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    var directory = Path.GetDirectoryName(FilePath);
                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    File.Create(FilePath).Close();
                    MessageBox.Show("Arquivo de produtos criado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao configurar o arquivo: {ex.Message}");
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Preco", "Preço");
            dataGridView1.Columns.Add("Descricao", "Descrição");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            try
            {
                if (File.Exists(FilePath))
                {
                    var linhas = File.ReadAllLines(FilePath);
                    produtos = linhas.Select(linha =>
                    {
                        var campos = linha.Split(';');
                        if (campos.Length == 3)
                        {
                            return new Produto
                            {
                                Nome = campos[0],
                                Preco = decimal.TryParse(campos[1], out var preco) ? preco : 0,
                                Descricao = campos[2]
                            };
                        }

                        return null;
                    }).Where(p => p != null).ToList();

                    AtualizarDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os produtos: {ex.Message}");
            }
        }

        private void SalvarProdutosNoArquivo()
        {
            try
            {
                var linhas = produtos.Select(p => $"{p.Nome};{p.Preco};{p.Descricao}").ToList();
                File.WriteAllLines(FilePath, linhas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os produtos: {ex.Message}");
            }
        }

        private void LimparCampos()
        {
            txtNomeProduto.Clear();
            txtPreco.Clear();
            txtDescricao.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
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

        private void btnListar_Click(object sender, EventArgs e)
        {
            CarregarProdutosDoArquivo();
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}
