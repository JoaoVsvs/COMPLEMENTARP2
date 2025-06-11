using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace projetop2
{
    public partial class CadastroUsuariosFRM : Form
    {
        private string filePath = "clientes.csv";

        public CadastroUsuariosFRM()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadClientes();
        }

        private void ConfigureDataGridView()
        {
            if (dgvCEP.Columns.Count == 0)
            {
                dgvCEP.ColumnCount = 11;
                dgvCEP.Columns[0].Name = "CPF";
                dgvCEP.Columns[1].Name = "Nome";
                dgvCEP.Columns[2].Name = "Email";
                dgvCEP.Columns[3].Name = "Telefone";
                dgvCEP.Columns[4].Name = "WhatsApp";
                dgvCEP.Columns[5].Name = "CEP";
                dgvCEP.Columns[6].Name = "Logradouro";
                dgvCEP.Columns[7].Name = "Número";
                dgvCEP.Columns[8].Name = "Bairro";
                dgvCEP.Columns[9].Name = "Cidade";
                dgvCEP.Columns[10].Name = "Estado";
            }
        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim();
            if (!Regex.IsMatch(cep, @"^\d{8}$"))
            {
                MessageBox.Show("CEP inválido. Insira 8 dígitos numéricos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var endereco = JsonSerializer.Deserialize<Endereco>(json);

                        if (endereco != null && !endereco.Erro)
                        {
                            txtLOGADOURO.Text = endereco.Logradouro;
                            txtBAIRRO.Text = endereco.Bairro;
                            txtCIDADE.Text = endereco.Localidade;
                            txtESTADO.Text = endereco.Uf;
                        }
                        else
                        {
                            MessageBox.Show("CEP não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar CEP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string cpf = txtCPF.Text.Trim();
            string email = txtEMAIL.Text.Trim();
            string telefone = txtTELEFONE.Text.Trim();
            string whatsapp = txtZAP.Text.Trim();
            string cep = txtCEP.Text.Trim();
            string logradouro = txtLOGADOURO.Text.Trim();
            string numero = txtNUMERO.Text.Trim();
            string bairro = txtBAIRRO.Text.Trim();
            string cidade = txtCIDADE.Text.Trim();
            string estado = txtESTADO.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, preencha os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                MessageBox.Show("CPF inválido. Insira 11 dígitos numéricos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var cliente = new Cliente
                {
                    Nome = nome,
                    CPF = cpf,
                    Email = email,
                    Telefone = telefone,
                    WhatsApp = whatsapp,
                    CEP = cep,
                    Logradouro = logradouro,
                    Numero = numero,
                    Bairro = bairro,
                    Cidade = cidade,
                    Estado = estado
                };

                SaveCliente(cliente);
                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCliente(Cliente cliente)
        {
            var line = $"{cliente.CPF};{cliente.Nome};{cliente.Email};{cliente.Telefone};{cliente.WhatsApp};{cliente.CEP};{cliente.Logradouro};{cliente.Numero};{cliente.Bairro};{cliente.Cidade};{cliente.Estado}";
            File.AppendAllText(filePath, line + Environment.NewLine);
        }

        private void LoadClientes()
        {
            if (!File.Exists(filePath))
                return;

            dgvCEP.Rows.Clear();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var data = line.Split(';');
                if (data.Length == 11)
                {
                    dgvCEP.Rows.Add(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9], data[10]);
                }
            }
        }

        private void ClearForm()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtEMAIL.Clear();
            txtTELEFONE.Clear();
            txtZAP.Clear();
            txtCEP.Clear();
            txtLOGADOURO.Clear();
            txtNUMERO.Clear();
            txtBAIRRO.Clear();
            txtCIDADE.Clear();
            txtESTADO.Clear();
        }

        private void btnExibirTodos_Click(object sender, EventArgs e)
        {
            if (dgvCEP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente na tabela para exibir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvCEP.SelectedRows[0];
            txtCPF.Text = row.Cells["CPF"].Value.ToString();
            txtNome.Text = row.Cells["Nome"].Value.ToString();
            txtEMAIL.Text = row.Cells["Email"].Value.ToString();
            txtTELEFONE.Text = row.Cells["Telefone"].Value.ToString();
            txtZAP.Text = row.Cells["WhatsApp"].Value.ToString();
            txtCEP.Text = row.Cells["CEP"].Value.ToString();
            txtLOGADOURO.Text = row.Cells["Logradouro"].Value.ToString();
            txtNUMERO.Text = row.Cells["Número"].Value.ToString();
            txtBAIRRO.Text = row.Cells["Bairro"].Value.ToString();
            txtCIDADE.Text = row.Cells["Cidade"].Value.ToString();
            txtESTADO.Text = row.Cells["Estado"].Value.ToString();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvCEP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para deletar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvCEP.SelectedRows[0];
            string cpfParaDeletar = row.Cells["CPF"].Value.ToString();

            var lines = new List<string>(File.ReadAllLines(filePath));
            bool achou = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var data = lines[i].Split(';');
                if (data.Length > 0 && data[0] == cpfParaDeletar)
                {
                    lines.RemoveAt(i);
                    achou = true;
                    break;
                }
            }

            if (achou)
            {
                File.WriteAllLines(filePath, lines);
                LoadClientes();
                ClearForm();
                MessageBox.Show("Cliente deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cliente não encontrado no arquivo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            if (dgvCEP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para atualizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cpfOriginal = dgvCEP.SelectedRows[0].Cells["CPF"].Value.ToString();
            var clienteAtualizado = ObterClienteDoFormulario();

            var lines = new List<string>(File.ReadAllLines(filePath));
            bool achou = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var data = lines[i].Split(';');
                if (data.Length > 0 && data[0] == cpfOriginal)
                {
                    lines[i] = $"{clienteAtualizado.CPF};{clienteAtualizado.Nome};{clienteAtualizado.Email};{clienteAtualizado.Telefone};{clienteAtualizado.WhatsApp};{clienteAtualizado.CEP};{clienteAtualizado.Logradouro};{clienteAtualizado.Numero};{clienteAtualizado.Bairro};{clienteAtualizado.Cidade};{clienteAtualizado.Estado}";
                    achou = true;
                    break;
                }
            }

            if (achou)
            {
                File.WriteAllLines(filePath, lines);
                LoadClientes();
                ClearForm();
                MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cliente não encontrado no arquivo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public bool Erro { get; set; }
    }
}
