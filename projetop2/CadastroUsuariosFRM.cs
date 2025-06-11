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

namespace projetop2
{
    public partial class CadastroUsuariosFRM : Form
    {
        public CadastroUsuariosFRM()
        {
            InitializeComponent();
        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim().Replace("-", "");
            if (cep.Length != 8)

            {
                MessageBox.Show("Digite um CEP válido com 8 números.");
                return;
            }

            try
            {
                using HttpClient client = new HttpClient();
                string url = $"https://viacep.com.br/ws/{cep}/json/";

                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var endereco = JsonSerializer.Deserialize<ViaCepResponse>(json);

                if (endereco != null && endereco.Erro != true)
                {
                    txtLOGADOURO.Text = endereco.Logradouro;
                    txtBAIRRO.Text = endereco.Bairro;
                    txtCIDADE.Text = endereco.Localidade;
                    txtESTADO.Text = endereco.Uf;
                }
                else
                {
                    MessageBox.Show("CEP não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar o CEP: " + ex.Message);
            }
        }
        public class ViaCepResponse
        {
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            public string Uf { get; set; }
            public bool Erro { get; set; }
        }
    }
}
