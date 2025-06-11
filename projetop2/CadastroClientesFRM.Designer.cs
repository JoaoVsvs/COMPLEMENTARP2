namespace projetop2
{
    partial class CadastroClientesFRM
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
            txtUser = new TextBox();
            txtSenha = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnCadastrar = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            btnExibir = new Button();
            dataGridUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).BeginInit();
            SuspendLayout();
            // 
            // txtUser
            // 
            txtUser.Location = new Point(83, 68);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(207, 23);
            txtUser.TabIndex = 0;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(83, 131);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(207, 23);
            txtSenha.TabIndex = 1;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 50);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuário";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 113);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Senha";
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(43, 189);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(75, 36);
            btnCadastrar.TabIndex = 4;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(243, 189);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 36);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(43, 270);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 36);
            btnExcluir.TabIndex = 6;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnExibir
            // 
            btnExibir.Location = new Point(243, 264);
            btnExibir.Name = "btnExibir";
            btnExibir.Size = new Size(75, 48);
            btnExibir.TabIndex = 7;
            btnExibir.Text = "Exibir Todos";
            btnExibir.UseVisualStyleBackColor = true;
            // 
            // dataGridUsuarios
            // 
            dataGridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUsuarios.Location = new Point(368, 50);
            dataGridUsuarios.Name = "dataGridUsuarios";
            dataGridUsuarios.Size = new Size(420, 231);
            dataGridUsuarios.TabIndex = 8;
            // 
            // CadastroClientesFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridUsuarios);
            Controls.Add(btnExibir);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnCadastrar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSenha);
            Controls.Add(txtUser);
            Name = "CadastroClientesFRM";
            Text = "CadastroClientesFRM";
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUser;
        private TextBox txtSenha;
        private Label label1;
        private Label label2;
        private Button btnCadastrar;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnExibir;
        private DataGridView dataGridUsuarios;
    }
}