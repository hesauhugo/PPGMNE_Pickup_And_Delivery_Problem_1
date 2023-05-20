
namespace Aula3
{
    partial class Form2
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
            this.btnPDP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPDP
            // 
            this.btnPDP.Location = new System.Drawing.Point(188, 87);
            this.btnPDP.Name = "btnPDP";
            this.btnPDP.Size = new System.Drawing.Size(75, 23);
            this.btnPDP.TabIndex = 0;
            this.btnPDP.Text = "PDP";
            this.btnPDP.UseVisualStyleBackColor = true;
            this.btnPDP.Click += new System.EventHandler(this.btnPDP_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPDP);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPDP;
    }
}