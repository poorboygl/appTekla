namespace appTekla
{
    partial class Form1
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
            this.btnExcerise = new System.Windows.Forms.Button();
            this.btnExcerise2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExcerise
            // 
            this.btnExcerise.Location = new System.Drawing.Point(44, 40);
            this.btnExcerise.Name = "btnExcerise";
            this.btnExcerise.Size = new System.Drawing.Size(75, 23);
            this.btnExcerise.TabIndex = 0;
            this.btnExcerise.Text = "Excerise 1";
            this.btnExcerise.UseVisualStyleBackColor = true;
            this.btnExcerise.Click += new System.EventHandler(this.btnExcerise_Click);
            // 
            // btnExcerise2
            // 
            this.btnExcerise2.Location = new System.Drawing.Point(136, 40);
            this.btnExcerise2.Name = "btnExcerise2";
            this.btnExcerise2.Size = new System.Drawing.Size(75, 23);
            this.btnExcerise2.TabIndex = 1;
            this.btnExcerise2.Text = "Excerise 2";
            this.btnExcerise2.UseVisualStyleBackColor = true;
            this.btnExcerise2.Click += new System.EventHandler(this.btnExcerise2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExcerise2);
            this.Controls.Add(this.btnExcerise);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcerise;
        private System.Windows.Forms.Button btnExcerise2;
    }
}

