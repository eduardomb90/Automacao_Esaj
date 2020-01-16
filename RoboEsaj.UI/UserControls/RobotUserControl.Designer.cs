namespace RoboEsaj.UI.UserControls
{
    partial class RobotUserControl
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
            this.cbVara = new System.Windows.Forms.ComboBox();
            this.lblPesquisa = new System.Windows.Forms.Label();
            this.lblVara = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.txbPesquisa = new System.Windows.Forms.TextBox();
            this.btnOu = new System.Windows.Forms.Button();
            this.btnAspas = new System.Windows.Forms.Button();
            this.btnNao = new System.Windows.Forms.Button();
            this.btnAster = new System.Windows.Forms.Button();
            this.btnInterroga = new System.Windows.Forms.Button();
            this.lblAssunto = new System.Windows.Forms.Label();
            this.lblMagistrado = new System.Windows.Forms.Label();
            this.txtMagistrado = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.lblDataExemp = new System.Windows.Forms.Label();
            this.txtDataInicial = new System.Windows.Forms.TextBox();
            this.txtDataFinal = new System.Windows.Forms.TextBox();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbVara
            // 
            this.cbVara.AutoCompleteCustomSource.AddRange(new string[] {
            "SÃO PAULO"});
            this.cbVara.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbVara.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbVara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVara.FormattingEnabled = true;
            this.cbVara.Items.AddRange(new object[] {
            "SÃO PAULO",
            "Foro Regional I - Santana",
            "Foro Regional II - Santo Amaro",
            "Foro Regional III - Jabaquara",
            "Foro Regional IV - Lapa",
            "Foro Regional V - São Miguel Paulista",
            "Foro Regional VI - Penha de França",
            "Foro Regional VII - Itaquera",
            "Foro Regional VIII - Tatuapé",
            "Foro Regional IX - Vila Prudente",
            "Foro Regional X - Ipiranga",
            "Foro Regional XI - Pinheiros",
            "Foro Distrital de Parelheiros",
            "Foro das Execuções Fiscais Estaduais",
            "Foro Especial da Infância e Juventude",
            "Foro Central Juizados Especiais Cíveis",
            "Foro Regional XII - Nossa Senhora do Ó",
            "Setor de Cartas Precatórias Cíveis - Cap",
            "São Paulo/DEECRIM UR1",
            "Foro Central Criminal Barra Funda",
            "Foro Central - Fazenda Pública/Acidentes",
            "Foro das Execuções Fiscais Municipais",
            "Foro Central Cível",
            "Foro Regional XV - Butantã"});
            this.cbVara.Location = new System.Drawing.Point(176, 268);
            this.cbVara.Name = "cbVara";
            this.cbVara.Size = new System.Drawing.Size(362, 21);
            this.cbVara.TabIndex = 5;
            this.cbVara.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbVara_KeyDown);
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPesquisa.Location = new System.Drawing.Point(59, 58);
            this.lblPesquisa.Name = "lblPesquisa";
            this.lblPesquisa.Size = new System.Drawing.Size(103, 16);
            this.lblPesquisa.TabIndex = 13;
            this.lblPesquisa.Text = "Pesquisa Livre:";
            // 
            // lblVara
            // 
            this.lblVara.AutoSize = true;
            this.lblVara.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVara.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblVara.Location = new System.Drawing.Point(23, 269);
            this.lblVara.Name = "lblVara";
            this.lblVara.Size = new System.Drawing.Size(139, 16);
            this.lblVara.TabIndex = 14;
            this.lblVara.Text = "Varas de São Paulo:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(3, 328);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(89, 35);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnE
            // 
            this.btnE.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE.Location = new System.Drawing.Point(176, 84);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(38, 23);
            this.btnE.TabIndex = 15;
            this.btnE.Text = "E";
            this.btnE.UseVisualStyleBackColor = true;
            this.btnE.Click += new System.EventHandler(this.btnE_Click);
            // 
            // txbPesquisa
            // 
            this.txbPesquisa.Location = new System.Drawing.Point(176, 58);
            this.txbPesquisa.Name = "txbPesquisa";
            this.txbPesquisa.Size = new System.Drawing.Size(462, 20);
            this.txbPesquisa.TabIndex = 0;
            this.txbPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPesquisa_KeyDown);
            // 
            // btnOu
            // 
            this.btnOu.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOu.Location = new System.Drawing.Point(220, 84);
            this.btnOu.Name = "btnOu";
            this.btnOu.Size = new System.Drawing.Size(38, 23);
            this.btnOu.TabIndex = 16;
            this.btnOu.Text = "OU";
            this.btnOu.UseVisualStyleBackColor = true;
            this.btnOu.Click += new System.EventHandler(this.btnOu_Click);
            // 
            // btnAspas
            // 
            this.btnAspas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAspas.Location = new System.Drawing.Point(408, 84);
            this.btnAspas.Name = "btnAspas";
            this.btnAspas.Size = new System.Drawing.Size(38, 23);
            this.btnAspas.TabIndex = 20;
            this.btnAspas.Text = "\" \"";
            this.btnAspas.UseVisualStyleBackColor = true;
            this.btnAspas.Click += new System.EventHandler(this.btnAspas_Click);
            // 
            // btnNao
            // 
            this.btnNao.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNao.Location = new System.Drawing.Point(264, 84);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(50, 23);
            this.btnNao.TabIndex = 17;
            this.btnNao.Text = "NÃO";
            this.btnNao.UseVisualStyleBackColor = true;
            this.btnNao.Click += new System.EventHandler(this.btnNao_Click);
            // 
            // btnAster
            // 
            this.btnAster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAster.Location = new System.Drawing.Point(364, 84);
            this.btnAster.Name = "btnAster";
            this.btnAster.Size = new System.Drawing.Size(38, 23);
            this.btnAster.TabIndex = 19;
            this.btnAster.Text = "*";
            this.btnAster.UseVisualStyleBackColor = true;
            this.btnAster.Click += new System.EventHandler(this.btnAster_Click);
            // 
            // btnInterroga
            // 
            this.btnInterroga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterroga.Location = new System.Drawing.Point(320, 84);
            this.btnInterroga.Name = "btnInterroga";
            this.btnInterroga.Size = new System.Drawing.Size(38, 23);
            this.btnInterroga.TabIndex = 18;
            this.btnInterroga.Text = "?";
            this.btnInterroga.UseVisualStyleBackColor = true;
            this.btnInterroga.Click += new System.EventHandler(this.btnInterroga_Click);
            // 
            // lblAssunto
            // 
            this.lblAssunto.AutoSize = true;
            this.lblAssunto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssunto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAssunto.Location = new System.Drawing.Point(100, 143);
            this.lblAssunto.Name = "lblAssunto";
            this.lblAssunto.Size = new System.Drawing.Size(62, 16);
            this.lblAssunto.TabIndex = 14;
            this.lblAssunto.Text = "Assunto:";
            // 
            // lblMagistrado
            // 
            this.lblMagistrado.AutoSize = true;
            this.lblMagistrado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMagistrado.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMagistrado.Location = new System.Drawing.Point(75, 190);
            this.lblMagistrado.Name = "lblMagistrado";
            this.lblMagistrado.Size = new System.Drawing.Size(87, 16);
            this.lblMagistrado.TabIndex = 14;
            this.lblMagistrado.Text = "Magistrado:";
            // 
            // txtMagistrado
            // 
            this.txtMagistrado.Location = new System.Drawing.Point(176, 186);
            this.txtMagistrado.Name = "txtMagistrado";
            this.txtMagistrado.Size = new System.Drawing.Size(362, 20);
            this.txtMagistrado.TabIndex = 2;
            this.txtMagistrado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMagistrado_KeyDown);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblData.Location = new System.Drawing.Point(119, 231);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(43, 16);
            this.lblData.TabIndex = 14;
            this.lblData.Text = "Data:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAte.Location = new System.Drawing.Point(320, 228);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(27, 16);
            this.lblAte.TabIndex = 14;
            this.lblAte.Text = "até";
            // 
            // lblDataExemp
            // 
            this.lblDataExemp.AutoSize = true;
            this.lblDataExemp.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataExemp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDataExemp.Location = new System.Drawing.Point(497, 229);
            this.lblDataExemp.Name = "lblDataExemp";
            this.lblDataExemp.Size = new System.Drawing.Size(94, 16);
            this.lblDataExemp.TabIndex = 14;
            this.lblDataExemp.Text = "(dd/mm/aaaa)";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(176, 226);
            this.txtDataInicial.MaxLength = 10;
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(138, 20);
            this.txtDataInicial.TabIndex = 3;
            this.txtDataInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataInicial_KeyDown);
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(353, 226);
            this.txtDataFinal.MaxLength = 10;
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(138, 20);
            this.txtDataFinal.TabIndex = 4;
            this.txtDataFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataFinal_KeyDown);
            // 
            // txtAssunto
            // 
            this.txtAssunto.Location = new System.Drawing.Point(176, 143);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(362, 20);
            this.txtAssunto.TabIndex = 1;
            this.txtAssunto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAssunto_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(544, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "nome completo";
            // 
            // RobotUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.txtDataFinal);
            this.Controls.Add(this.txtDataInicial);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.txtMagistrado);
            this.Controls.Add(this.cbVara);
            this.Controls.Add(this.lblPesquisa);
            this.Controls.Add(this.lblMagistrado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDataExemp);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblAssunto);
            this.Controls.Add(this.lblVara);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnE);
            this.Controls.Add(this.txbPesquisa);
            this.Controls.Add(this.btnOu);
            this.Controls.Add(this.btnAspas);
            this.Controls.Add(this.btnNao);
            this.Controls.Add(this.btnAster);
            this.Controls.Add(this.btnInterroga);
            this.Name = "RobotUserControl";
            this.Size = new System.Drawing.Size(696, 368);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbVara;
        private System.Windows.Forms.Label lblPesquisa;
        private System.Windows.Forms.Label lblVara;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnE;
        private System.Windows.Forms.TextBox txbPesquisa;
        private System.Windows.Forms.Button btnOu;
        private System.Windows.Forms.Button btnAspas;
        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.Button btnAster;
        private System.Windows.Forms.Button btnInterroga;
        private System.Windows.Forms.Label lblAssunto;
        private System.Windows.Forms.Label lblMagistrado;
        private System.Windows.Forms.TextBox txtMagistrado;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Label lblDataExemp;
        private System.Windows.Forms.TextBox txtDataInicial;
        private System.Windows.Forms.TextBox txtDataFinal;
        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.Label label1;
    }
}
