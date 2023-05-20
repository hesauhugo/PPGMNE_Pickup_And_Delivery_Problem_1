
namespace Aula3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_tempo_resolucao = new System.Windows.Forms.Label();
            this.txt_numero_origens = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_numero_destinos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_numero_transbordos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_semente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(284, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_tempo_resolucao
            // 
            this.lbl_tempo_resolucao.AutoSize = true;
            this.lbl_tempo_resolucao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_tempo_resolucao.Location = new System.Drawing.Point(12, 221);
            this.lbl_tempo_resolucao.Name = "lbl_tempo_resolucao";
            this.lbl_tempo_resolucao.Size = new System.Drawing.Size(210, 21);
            this.lbl_tempo_resolucao.TabIndex = 2;
            this.lbl_tempo_resolucao.Text = "Tempo para resolução (0) ms";
            // 
            // txt_numero_origens
            // 
            this.txt_numero_origens.Location = new System.Drawing.Point(12, 54);
            this.txt_numero_origens.Name = "txt_numero_origens";
            this.txt_numero_origens.Size = new System.Drawing.Size(284, 23);
            this.txt_numero_origens.TabIndex = 1;
            this.txt_numero_origens.TextChanged += new System.EventHandler(this.txt_numero_origens_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nº de Origens ";
            // 
            // txt_numero_destinos
            // 
            this.txt_numero_destinos.Location = new System.Drawing.Point(12, 98);
            this.txt_numero_destinos.Name = "txt_numero_destinos";
            this.txt_numero_destinos.Size = new System.Drawing.Size(284, 23);
            this.txt_numero_destinos.TabIndex = 1;
            this.txt_numero_destinos.TextChanged += new System.EventHandler(this.txt_numero_destinos_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nº de Destinos";
            // 
            // txt_numero_transbordos
            // 
            this.txt_numero_transbordos.Location = new System.Drawing.Point(12, 144);
            this.txt_numero_transbordos.Name = "txt_numero_transbordos";
            this.txt_numero_transbordos.Size = new System.Drawing.Size(284, 23);
            this.txt_numero_transbordos.TabIndex = 1;
            this.txt_numero_transbordos.TextChanged += new System.EventHandler(this.txt_numero_transbordos_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nº de Transbordos";
            // 
            // txt_semente
            // 
            this.txt_semente.Location = new System.Drawing.Point(12, 188);
            this.txt_semente.Name = "txt_semente";
            this.txt_semente.Size = new System.Drawing.Size(284, 23);
            this.txt_semente.TabIndex = 1;
            this.txt_semente.TextChanged += new System.EventHandler(this.txt_semente_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Semente";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 255);
            this.progressBar1.Maximum = 8;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(284, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 284);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_tempo_resolucao);
            this.Controls.Add(this.txt_semente);
            this.Controls.Add(this.txt_numero_transbordos);
            this.Controls.Add(this.txt_numero_destinos);
            this.Controls.Add(this.txt_numero_origens);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Problema Transporte";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_tempo_resolucao;
        private System.Windows.Forms.TextBox txt_numero_origens;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_numero_destinos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_numero_transbordos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_semente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

