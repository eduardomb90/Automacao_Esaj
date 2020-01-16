namespace RoboEsaj.UI.Forms
{
    partial class FrmEsaj
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDatabaseCons = new System.Windows.Forms.Button();
            this.btnPesquisaJur = new System.Windows.Forms.Button();
            this.dbUserControl1 = new RoboEsaj.UI.UserControls.DbUserControl();
            this.robotUserControl1 = new RoboEsaj.UI.UserControls.RobotUserControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(844, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 42);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.CloseApp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDatabaseCons);
            this.panel1.Controls.Add(this.btnPesquisaJur);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 503);
            this.panel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "ESAJ SP";
            // 
            // btnDatabaseCons
            // 
            this.btnDatabaseCons.FlatAppearance.BorderSize = 0;
            this.btnDatabaseCons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseCons.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatabaseCons.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDatabaseCons.Location = new System.Drawing.Point(8, 230);
            this.btnDatabaseCons.Name = "btnDatabaseCons";
            this.btnDatabaseCons.Size = new System.Drawing.Size(135, 46);
            this.btnDatabaseCons.TabIndex = 1;
            this.btnDatabaseCons.Text = "Consultar Banco de Dados";
            this.btnDatabaseCons.UseVisualStyleBackColor = true;
            this.btnDatabaseCons.Click += new System.EventHandler(this.btnDatabaseCons_Click);
            // 
            // btnPesquisaJur
            // 
            this.btnPesquisaJur.FlatAppearance.BorderSize = 0;
            this.btnPesquisaJur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisaJur.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisaJur.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPesquisaJur.Location = new System.Drawing.Point(8, 147);
            this.btnPesquisaJur.Name = "btnPesquisaJur";
            this.btnPesquisaJur.Size = new System.Drawing.Size(135, 46);
            this.btnPesquisaJur.TabIndex = 0;
            this.btnPesquisaJur.Text = "Pesquisar Jurisprudência";
            this.btnPesquisaJur.UseVisualStyleBackColor = true;
            this.btnPesquisaJur.Click += new System.EventHandler(this.btnPesquisaJur_Click);
            // 
            // dbUserControl1
            // 
            this.dbUserControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dbUserControl1.Location = new System.Drawing.Point(151, 0);
            this.dbUserControl1.Name = "dbUserControl1";
            this.dbUserControl1.Size = new System.Drawing.Size(796, 453);
            this.dbUserControl1.TabIndex = 16;
            // 
            // robotUserControl1
            // 
            this.robotUserControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.robotUserControl1.Location = new System.Drawing.Point(190, 0);
            this.robotUserControl1.Name = "robotUserControl1";
            this.robotUserControl1.Size = new System.Drawing.Size(758, 448);
            this.robotUserControl1.TabIndex = 15;
            // 
            // FrmEsaj
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(955, 503);
            this.Controls.Add(this.dbUserControl1);
            this.Controls.Add(this.robotUserControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmEsaj";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDatabaseCons;
        private System.Windows.Forms.Button btnPesquisaJur;
        private UserControls.RobotUserControl robotUserControl1;
        private UserControls.DbUserControl dbUserControl1;
        private System.Windows.Forms.Label label1;
    }
}

