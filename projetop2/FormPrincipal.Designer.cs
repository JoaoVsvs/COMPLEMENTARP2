namespace projetop2
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClientes = new Button();
            btnProdutos = new Button();
            btnPedidos = new Button();
            btnClient = new Button();
            SuspendLayout();
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(185, 123);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(117, 48);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Cadastro de Usuário";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.Location = new Point(427, 123);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(117, 48);
            btnProdutos.TabIndex = 1;
            btnProdutos.Text = "Cadastro de Produtos";
            btnProdutos.UseVisualStyleBackColor = true;
            btnProdutos.Click += btnProdutos_Click;
            // 
            // btnPedidos
            // 
            btnPedidos.Location = new Point(185, 220);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(117, 48);
            btnPedidos.TabIndex = 2;
            btnPedidos.Text = "Cadastro de Pedidos";
            btnPedidos.UseVisualStyleBackColor = true;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new Point(427, 220);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(117, 48);
            btnClient.TabIndex = 3;
            btnClient.Text = "Cadastro de Clientes";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnUsers_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClient);
            Controls.Add(btnPedidos);
            Controls.Add(btnProdutos);
            Controls.Add(btnClientes);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnClientes;
        private Button btnProdutos;
        private Button btnPedidos;
        private Button btnClient;
    }
}