namespace projetop2
{
    partial class CadastroPedidosFRM
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
            txtNomeProduto = new TextBox();
            txtPreco = new TextBox();
            txtDescricao = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAdicionar = new Button();
            btnAtualizar = new Button();
            btnExcluir = new Button();
            btnListar = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtNomeProduto
            // 
            txtNomeProduto.Location = new Point(54, 57);
            txtNomeProduto.Name = "txtNomeProduto";
            txtNomeProduto.Size = new Size(241, 23);
            txtNomeProduto.TabIndex = 0;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(54, 111);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(241, 23);
            txtPreco.TabIndex = 1;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(54, 168);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(241, 23);
            txtDescricao.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 39);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 3;
            label1.Text = "Nome do Prouto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 93);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 4;
            label2.Text = "Valor do Produto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 150);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 5;
            label3.Text = "Descrição do Produto";
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(54, 210);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 6;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(220, 210);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(75, 23);
            btnAtualizar.TabIndex = 7;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(54, 266);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 8;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(209, 266);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(108, 23);
            btnListar.TabIndex = 9;
            btnListar.Text = "Listar Produtos";
            btnListar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(344, 30);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(431, 309);
            dataGridView1.TabIndex = 10;
            // 
            // CadastroPedidosFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnListar);
            Controls.Add(btnExcluir);
            Controls.Add(btnAtualizar);
            Controls.Add(btnAdicionar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDescricao);
            Controls.Add(txtPreco);
            Controls.Add(txtNomeProduto);
            Name = "CadastroPedidosFRM";
            Text = "CadastroPedidosFRM";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNomeProduto;
        private TextBox txtPreco;
        private TextBox txtDescricao;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAdicionar;
        private Button btnAtualizar;
        private Button btnExcluir;
        private Button btnListar;
        private DataGridView dataGridView1;
    }
}