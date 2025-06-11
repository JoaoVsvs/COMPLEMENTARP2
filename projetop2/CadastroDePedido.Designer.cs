namespace projetop2
{
    partial class CadastroDePedido
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
            txtCPF = new TextBox();
            txtProduto = new TextBox();
            txtQuantidade = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNome = new TextBox();
            lblNome = new Label();
            btnPesquisar = new Button();
            btnAdicionar = new Button();
            btnRemover = new Button();
            dataGridViewItens = new DataGridView();
            lblTotal = new Label();
            btnGravar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItens).BeginInit();
            SuspendLayout();
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(23, 46);
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(177, 23);
            txtCPF.TabIndex = 0;
            // 
            // txtProduto
            // 
            txtProduto.Location = new Point(23, 100);
            txtProduto.Name = "txtProduto";
            txtProduto.Size = new Size(177, 23);
            txtProduto.TabIndex = 1;
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(232, 100);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(177, 23);
            txtQuantidade.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 28);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 3;
            label1.Text = "CPF DO CLIENTE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 82);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 4;
            label2.Text = "PRODUTO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(232, 82);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 5;
            label3.Text = "QUANTIDADE";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(232, 46);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(177, 23);
            txtNome.TabIndex = 6;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(232, 28);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(110, 15);
            lblNome.TabIndex = 7;
            lblNome.Text = "NOME DO CLIENTE";
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(23, 157);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(106, 39);
            btnPesquisar.TabIndex = 8;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(303, 157);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(106, 39);
            btnAdicionar.TabIndex = 9;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(161, 157);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(106, 39);
            btnRemover.TabIndex = 10;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // dataGridViewItens
            // 
            dataGridViewItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItens.Location = new Point(453, 28);
            dataGridViewItens.Name = "dataGridViewItens";
            dataGridViewItens.Size = new Size(335, 206);
            dataGridViewItens.TabIndex = 11;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(453, 255);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(94, 15);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "Total de Pedidos";
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(565, 289);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(120, 52);
            btnGravar.TabIndex = 13;
            btnGravar.Text = "Gravar Pedido";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // CadastroDePedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGravar);
            Controls.Add(lblTotal);
            Controls.Add(dataGridViewItens);
            Controls.Add(btnRemover);
            Controls.Add(btnAdicionar);
            Controls.Add(btnPesquisar);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtQuantidade);
            Controls.Add(txtProduto);
            Controls.Add(txtCPF);
            Name = "CadastroDePedido";
            Text = "CadastroDePedidoFRM";
            ((System.ComponentModel.ISupportInitialize)dataGridViewItens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCPF;
        private TextBox txtProduto;
        private TextBox txtQuantidade;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNome;
        private Label lblNome;
        private Button btnPesquisar;
        private Button btnAdicionar;
        private Button btnRemover;
        private DataGridView dataGridViewItens;
        private Label lblTotal;
        private Button btnGravar;
    }
}