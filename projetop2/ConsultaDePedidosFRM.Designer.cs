namespace projetop2
{
    partial class ConsultaDePedidosFRM
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
            lblCPF = new Label();
            lblNomeCliente = new Label();
            lblTotalPedido = new Label();
            btnBuscar = new Button();
            listView1 = new ListView();
            listView2 = new ListView();
            SuspendLayout();
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(21, 23);
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(191, 23);
            txtCPF.TabIndex = 0;
            // 
            // lblCPF
            // 
            lblCPF.AutoSize = true;
            lblCPF.Location = new Point(21, 61);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(38, 15);
            lblCPF.TabIndex = 1;
            lblCPF.Text = "label1";
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(21, 90);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(38, 15);
            lblNomeCliente.TabIndex = 2;
            lblNomeCliente.Text = "label2";
            // 
            // lblTotalPedido
            // 
            lblTotalPedido.AutoSize = true;
            lblTotalPedido.Location = new Point(21, 120);
            lblTotalPedido.Name = "lblTotalPedido";
            lblTotalPedido.Size = new Size(38, 15);
            lblTotalPedido.TabIndex = 3;
            lblTotalPedido.Text = "label3";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(21, 151);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(253, 23);
            listView1.Name = "listView1";
            listView1.Size = new Size(236, 138);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            listView2.Location = new Point(527, 23);
            listView2.Name = "listView2";
            listView2.Size = new Size(236, 138);
            listView2.TabIndex = 6;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // ConsultaDePedidosFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(btnBuscar);
            Controls.Add(lblTotalPedido);
            Controls.Add(lblNomeCliente);
            Controls.Add(lblCPF);
            Controls.Add(txtCPF);
            Name = "ConsultaDePedidosFRM";
            Text = "ConsultaDePedidosFRM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCPF;
        private Label lblCPF;
        private Label lblNomeCliente;
        private Label lblTotalPedido;
        private Button btnBuscar;
        private ListView listView1;
        private ListView listView2;
    }
}