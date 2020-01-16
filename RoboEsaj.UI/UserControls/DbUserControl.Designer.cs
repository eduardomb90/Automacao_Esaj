namespace RoboEsaj.UI.UserControls
{
    partial class DbUserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnDgvExport = new System.Windows.Forms.Button();
            this.dgvEsaj = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReloadDb = new System.Windows.Forms.Button();
            this.lblPesquisarDb = new System.Windows.Forms.Label();
            this.txtPesquisarDb = new System.Windows.Forms.TextBox();
            this.btnPesquisarDb = new System.Windows.Forms.Button();
            this.decisaoModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsaj)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.decisaoModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDgvExport
            // 
            this.btnDgvExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDgvExport.Location = new System.Drawing.Point(11, 8);
            this.btnDgvExport.Name = "btnDgvExport";
            this.btnDgvExport.Size = new System.Drawing.Size(131, 37);
            this.btnDgvExport.TabIndex = 4;
            this.btnDgvExport.Text = "Abrir no Excel";
            this.btnDgvExport.UseVisualStyleBackColor = true;
            this.btnDgvExport.Click += new System.EventHandler(this.btnDgvExport_Click);
            // 
            // dgvEsaj
            // 
            this.dgvEsaj.AutoGenerateColumns = false;
            this.dgvEsaj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEsaj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEsaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsaj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvEsaj.DataSource = this.decisaoModelBindingSource;
            this.dgvEsaj.Location = new System.Drawing.Point(3, 74);
            this.dgvEsaj.Name = "dgvEsaj";
            this.dgvEsaj.ReadOnly = true;
            this.dgvEsaj.Size = new System.Drawing.Size(807, 322);
            this.dgvEsaj.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnReloadDb);
            this.panel1.Controls.Add(this.btnDgvExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 55);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(422, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Limpar banco";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Remove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(148, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save_Excel);
            // 
            // btnReloadDb
            // 
            this.btnReloadDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadDb.Location = new System.Drawing.Point(285, 8);
            this.btnReloadDb.Name = "btnReloadDb";
            this.btnReloadDb.Size = new System.Drawing.Size(131, 37);
            this.btnReloadDb.TabIndex = 4;
            this.btnReloadDb.Text = "Carregar banco";
            this.btnReloadDb.UseVisualStyleBackColor = true;
            this.btnReloadDb.Click += new System.EventHandler(this.Reload_Click);
            // 
            // lblPesquisarDb
            // 
            this.lblPesquisarDb.AutoSize = true;
            this.lblPesquisarDb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisarDb.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPesquisarDb.Location = new System.Drawing.Point(94, 28);
            this.lblPesquisarDb.Name = "lblPesquisarDb";
            this.lblPesquisarDb.Size = new System.Drawing.Size(74, 16);
            this.lblPesquisarDb.TabIndex = 6;
            this.lblPesquisarDb.Text = "Pesquisar:";
            // 
            // txtPesquisarDb
            // 
            this.txtPesquisarDb.Location = new System.Drawing.Point(174, 27);
            this.txtPesquisarDb.Name = "txtPesquisarDb";
            this.txtPesquisarDb.Size = new System.Drawing.Size(475, 20);
            this.txtPesquisarDb.TabIndex = 7;
            // 
            // btnPesquisarDb
            // 
            this.btnPesquisarDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarDb.Location = new System.Drawing.Point(670, 22);
            this.btnPesquisarDb.Name = "btnPesquisarDb";
            this.btnPesquisarDb.Size = new System.Drawing.Size(90, 28);
            this.btnPesquisarDb.TabIndex = 4;
            this.btnPesquisarDb.Text = "Buscar";
            this.btnPesquisarDb.UseVisualStyleBackColor = true;
            this.btnPesquisarDb.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // decisaoModelBindingSource
            // 
            this.decisaoModelBindingSource.DataSource = typeof(RoboEsaj.Database.Models.DecisaoModel);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Processo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Processo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Classe";
            this.dataGridViewTextBoxColumn2.HeaderText = "Classe";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Assunto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Assunto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Magistrado";
            this.dataGridViewTextBoxColumn4.HeaderText = "Magistrado";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Comarca";
            this.dataGridViewTextBoxColumn5.HeaderText = "Comarca";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Foro";
            this.dataGridViewTextBoxColumn6.HeaderText = "Foro";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Vara";
            this.dataGridViewTextBoxColumn7.HeaderText = "Vara";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Data";
            this.dataGridViewTextBoxColumn8.HeaderText = "Data";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Resultado";
            this.dataGridViewTextBoxColumn9.HeaderText = "Resultado";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // DbUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.btnPesquisarDb);
            this.Controls.Add(this.txtPesquisarDb);
            this.Controls.Add(this.lblPesquisarDb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvEsaj);
            this.Name = "DbUserControl";
            this.Size = new System.Drawing.Size(813, 457);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsaj)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.decisaoModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDgvExport;
        private System.Windows.Forms.DataGridView dgvEsaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn processoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assuntoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn magistradoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReloadDb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPesquisarDb;
        private System.Windows.Forms.TextBox txtPesquisarDb;
        private System.Windows.Forms.Button btnPesquisarDb;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.BindingSource decisaoModelBindingSource;
    }
}
