using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace projetop2
{
    public partial class CadastroUsuariosFRM : Form
    {
        public CadastroUsuariosFRM()
        {
            InitializeComponent();
            LoadClientes();
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

        }
    }
