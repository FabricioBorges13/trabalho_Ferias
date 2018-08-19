namespace SolidOpsTrabalho.Apresentacao
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBoxEntrada = new System.Windows.Forms.ListBox();
            this.listBoxValido = new System.Windows.Forms.ListBox();
            this.listBoxMorto = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(976, 602);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Arquivos de Entrada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Arquivos Válidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(868, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Arquivos Mortos";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listBoxEntrada
            // 
            this.listBoxEntrada.FormattingEnabled = true;
            this.listBoxEntrada.Location = new System.Drawing.Point(12, 58);
            this.listBoxEntrada.Name = "listBoxEntrada";
            this.listBoxEntrada.Size = new System.Drawing.Size(352, 524);
            this.listBoxEntrada.TabIndex = 7;
            // 
            // listBoxValido
            // 
            this.listBoxValido.FormattingEnabled = true;
            this.listBoxValido.Location = new System.Drawing.Point(367, 56);
            this.listBoxValido.Name = "listBoxValido";
            this.listBoxValido.Size = new System.Drawing.Size(352, 524);
            this.listBoxValido.TabIndex = 8;
            // 
            // listBoxMorto
            // 
            this.listBoxMorto.FormattingEnabled = true;
            this.listBoxMorto.Location = new System.Drawing.Point(725, 56);
            this.listBoxMorto.Name = "listBoxMorto";
            this.listBoxMorto.Size = new System.Drawing.Size(352, 524);
            this.listBoxMorto.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 637);
            this.Controls.Add(this.listBoxMorto);
            this.Controls.Add(this.listBoxValido);
            this.Controls.Add(this.listBoxEntrada);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Analizador de Pastas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBoxEntrada;
        private System.Windows.Forms.ListBox listBoxValido;
        private System.Windows.Forms.ListBox listBoxMorto;
    }
}

