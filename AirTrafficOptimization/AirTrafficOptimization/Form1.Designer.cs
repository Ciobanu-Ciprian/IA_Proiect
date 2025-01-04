namespace AirTrafficOptimization
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
            this.OrasDePlecare = new System.Windows.Forms.TextBox();
            this.OrasDeSosire = new System.Windows.Forms.TextBox();
            this.DurataZborului = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ButtonAddZbor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OrasDePlecare
            // 
            this.OrasDePlecare.Location = new System.Drawing.Point(190, 32);
            this.OrasDePlecare.Name = "OrasDePlecare";
            this.OrasDePlecare.Size = new System.Drawing.Size(100, 22);
            this.OrasDePlecare.TabIndex = 0;
            this.OrasDePlecare.TextChanged += new System.EventHandler(this.OrasDePlecare_TextChanged);
            // 
            // OrasDeSosire
            // 
            this.OrasDeSosire.Location = new System.Drawing.Point(470, 32);
            this.OrasDeSosire.Name = "OrasDeSosire";
            this.OrasDeSosire.Size = new System.Drawing.Size(100, 22);
            this.OrasDeSosire.TabIndex = 1;
            this.OrasDeSosire.TextChanged += new System.EventHandler(this.OrasDeSosire_TextChanged);
            // 
            // DurataZborului
            // 
            this.DurataZborului.Location = new System.Drawing.Point(190, 60);
            this.DurataZborului.Name = "DurataZborului";
            this.DurataZborului.Size = new System.Drawing.Size(100, 22);
            this.DurataZborului.TabIndex = 2;
            this.DurataZborului.TextChanged += new System.EventHandler(this.DurataZborului_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Oras plecare -> Oras sosire | Durata"});
            this.listBox1.Location = new System.Drawing.Point(74, 204);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(284, 164);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ButtonAddZbor
            // 
            this.ButtonAddZbor.Location = new System.Drawing.Point(74, 98);
            this.ButtonAddZbor.Name = "ButtonAddZbor";
            this.ButtonAddZbor.Size = new System.Drawing.Size(129, 23);
            this.ButtonAddZbor.TabIndex = 4;
            this.ButtonAddZbor.Text = "Adauga zbor";
            this.ButtonAddZbor.UseVisualStyleBackColor = true;
            this.ButtonAddZbor.Click += new System.EventHandler(this.ButtonAddZbor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Oras de plecare";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Oras de sosire";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Durata zborului";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Zboruri adaugate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonAddZbor);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.DurataZborului);
            this.Controls.Add(this.OrasDeSosire);
            this.Controls.Add(this.OrasDePlecare);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OrasDePlecare;
        private System.Windows.Forms.TextBox OrasDeSosire;
        private System.Windows.Forms.TextBox DurataZborului;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ButtonAddZbor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}

