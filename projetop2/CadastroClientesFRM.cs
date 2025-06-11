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
    public partial class CadastroClientesFRM : Form
    {
        private const string arquivoUsuarios = @"C:\Users\joaoe\Downloads\P2COMPLEMENTO\projetop2\Usuarios.csv";
        public CadastroClientesFRM()
        {
            InitializeComponent();
            ConfigurarDataGrid();
            CarregarUsuarios();
        }

        private void ConfigurarDataGrid()
        {
            dataGridUsuarios.Columns.Add("Usuario", "Usuário");
            dataGridUsuarios.Columns.Add("Senha", "Senha");
            dataGridUsuarios.AllowUserToAddRows = false;
            dataGridUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridUsuarios.MultiSelect = false;
        }

        private void CarregarUsuarios()
        {
            if (File.Exists(arquivoUsuarios))
            {
                var linhas = File.ReadAllLines(arquivoUsuarios);
                dataGridUsuarios.Rows.Clear();
                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Usuário e senha são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsuarioJaExiste(usuario))
            {
                MessageBox.Show("Usuário já existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            File.AppendAllLines(arquivoUsuarios, new[] { $"{usuario};{senha}" });
            MessageBox.Show("Usuário adicionado com sucesso!");
            CarregarUsuarios();
        }

        private bool UsuarioJaExiste(string usuario)
        {
            foreach (DataGridViewRow row in dataGridUsuarios.Rows)
            {
                if (row.Cells["Usuario"].Value.ToString().Equals(usuario, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um usuário para excluir!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string usuarioSelecionado = dataGridUsuarios.SelectedRows[0].Cells["Usuario"].Value.ToString();

            if (usuarioSelecionado == "ADMIN")
            {
                MessageBox.Show("Não é possível excluir o usuário ADMIN!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var linhas = File.ReadAllLines(arquivoUsuarios).ToList();
            linhas.RemoveAll(l => l.Split(';')[0] == usuarioSelecionado);
            File.WriteAllLines(arquivoUsuarios, linhas);

            MessageBox.Show("Usuário excluído com sucesso!");
            CarregarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um usuário para atualizar a senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string usuarioSelecionado = dataGridUsuarios.SelectedRows[0].Cells["Usuario"].Value.ToString();
            string novaSenha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(novaSenha))
            {
                MessageBox.Show("A nova senha é obrigatória!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var linhas = File.ReadAllLines(arquivoUsuarios).ToList();
            for (int i = 0; i < linhas.Count; i++)
            {
                var dados = linhas[i].Split(';');
                if (dados[0] == usuarioSelecionado)
                {
                    linhas[i] = $"{usuarioSelecionado};{novaSenha}";
                }
            }

            File.WriteAllLines(arquivoUsuarios, linhas);
            MessageBox.Show("Senha atualizada com sucesso!");
            CarregarUsuarios();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            {
                try
                {
                   
                    dataGridUsuarios.Rows.Clear();

                    if (!File.Exists(arquivoUsuarios))
                    {
                        MessageBox.Show("O arquivo de usuários não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var linhas = File.ReadAllLines(arquivoUsuarios);

                    foreach (var linha in linhas)
                    {
                        var dados = linha.Split(';'); 
                        if (dados.Length >= 2)
                        {
                            dataGridUsuarios.Rows.Add(dados[0], dados[1]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao tentar exibir os usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
