namespace projeto.view.Forms
{
    partial class FormSolucionarChamado
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
            this.dgvChamados = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSoluciona = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxtSoluciona = new System.Windows.Forms.RichTextBox();
            this.txtIdChamado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChamados
            // 
            this.dgvChamados.AllowUserToAddRows = false;
            this.dgvChamados.AllowUserToDeleteRows = false;
            this.dgvChamados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChamados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChamados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvChamados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvChamados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvChamados.Location = new System.Drawing.Point(63, 81);
            this.dgvChamados.Name = "dgvChamados";
            this.dgvChamados.ReadOnly = true;
            this.dgvChamados.Size = new System.Drawing.Size(674, 182);
            this.dgvChamados.TabIndex = 15;
            this.dgvChamados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChamados_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Chamados:";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Location = new System.Drawing.Point(606, 370);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(131, 45);
            this.btnExcluir.TabIndex = 13;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSoluciona
            // 
            this.btnSoluciona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoluciona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoluciona.Location = new System.Drawing.Point(462, 370);
            this.btnSoluciona.Name = "btnSoluciona";
            this.btnSoluciona.Size = new System.Drawing.Size(127, 45);
            this.btnSoluciona.TabIndex = 11;
            this.btnSoluciona.Text = "Salvar Solução";
            this.btnSoluciona.UseVisualStyleBackColor = true;
            this.btnSoluciona.Click += new System.EventHandler(this.btnSoluciona_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Solução:";
            // 
            // rtxtSoluciona
            // 
            this.rtxtSoluciona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtSoluciona.Location = new System.Drawing.Point(124, 298);
            this.rtxtSoluciona.Name = "rtxtSoluciona";
            this.rtxtSoluciona.Size = new System.Drawing.Size(259, 117);
            this.rtxtSoluciona.TabIndex = 26;
            this.rtxtSoluciona.Text = "";
            // 
            // txtIdChamado
            // 
            this.txtIdChamado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdChamado.Location = new System.Drawing.Point(570, 298);
            this.txtIdChamado.Name = "txtIdChamado";
            this.txtIdChamado.ReadOnly = true;
            this.txtIdChamado.Size = new System.Drawing.Size(87, 20);
            this.txtIdChamado.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Código do chamado:";
            // 
            // FormSolucionarChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtxtSoluciona);
            this.Controls.Add(this.txtIdChamado);
            this.Controls.Add(this.dgvChamados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSoluciona);
            this.Name = "FormSolucionarChamado";
            this.Text = "Solucionar Chamado";
            this.Load += new System.EventHandler(this.FormSolucionarChamado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChamados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSoluciona;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxtSoluciona;
        private System.Windows.Forms.TextBox txtIdChamado;
        private System.Windows.Forms.Label label1;
    }
}