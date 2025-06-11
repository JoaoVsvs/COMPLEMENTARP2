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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CadastroClientesFRM cadastroClientes = new CadastroClientesFRM();
            cadastroClientes.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            CadastroProdutosFRM cadastroProdutos = new CadastroProdutosFRM();
            cadastroProdutos.Show();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            CadastroPedidosFRM cadastroPedidos = new CadastroPedidosFRM();
            cadastroPedidos.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            CadastroUsuariosFRM cadastroUsuarios = new CadastroUsuariosFRM();
            cadastroUsuarios.Show();
        }
    }
}
