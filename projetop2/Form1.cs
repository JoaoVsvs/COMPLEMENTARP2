namespace projetop2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (ValidarUsuario(usuario, senha))
            {
                MessageBox.Show("Login realizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Usuário ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarUsuario(string usuario, string senha)
        {

            string caminhoArquivo = @"C:\Users\joaoe\Downloads\P2COMPLEMENTO\projetop2\user.csv";

            if (!File.Exists(caminhoArquivo))
            {
                MessageBox.Show("Arquivo de credenciais não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var linhas = File.ReadAllLines(caminhoArquivo);
            return linhas.Any(linha =>
            {
                var dados = linha.Split(',');
                return dados[0] == usuario && dados[1] == senha;
            });
        }
    }
}