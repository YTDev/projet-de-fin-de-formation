namespace ProjetFF
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnlH = new System.Windows.Forms.Panel();
            this.btnC = new System.Windows.Forms.PictureBox();
            this.btnM = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdA = new System.Windows.Forms.RadioButton();
            this.rdU = new System.Windows.Forms.RadioButton();
            this.lblE = new System.Windows.Forms.Label();
            this.pnlH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlH
            // 
            this.pnlH.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pnlH.Controls.Add(this.btnC);
            this.pnlH.Controls.Add(this.btnM);
            this.pnlH.Controls.Add(this.pictureBox1);
            this.pnlH.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlH.Location = new System.Drawing.Point(0, 0);
            this.pnlH.Name = "pnlH";
            this.pnlH.Size = new System.Drawing.Size(300, 190);
            this.pnlH.TabIndex = 0;
            this.pnlH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlH_MouseDown);
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.Transparent;
            this.btnC.Image = ((System.Drawing.Image)(resources.GetObject("btnC.Image")));
            this.btnC.Location = new System.Drawing.Point(273, 3);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(24, 22);
            this.btnC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnC.TabIndex = 15;
            this.btnC.TabStop = false;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnM
            // 
            this.btnM.BackColor = System.Drawing.Color.Transparent;
            this.btnM.Image = ((System.Drawing.Image)(resources.GetObject("btnM.Image")));
            this.btnM.Location = new System.Drawing.Point(243, 3);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(24, 22);
            this.btnM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnM.TabIndex = 3;
            this.btnM.TabStop = false;
            this.btnM.Click += new System.EventHandler(this.btnM_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(50, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 1);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(50, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pseudo:";
            // 
            // txtP
            // 
            this.txtP.BackColor = System.Drawing.SystemColors.Control;
            this.txtP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtP.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP.Location = new System.Drawing.Point(50, 211);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(200, 19);
            this.txtP.TabIndex = 5;
            // 
            // txtM
            // 
            this.txtM.BackColor = System.Drawing.SystemColors.Control;
            this.txtM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtM.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtM.Location = new System.Drawing.Point(50, 274);
            this.txtM.Name = "txtM";
            this.txtM.PasswordChar = '*';
            this.txtM.Size = new System.Drawing.Size(200, 19);
            this.txtM.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(50, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mot de passe:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(50, 299);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 1);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 1);
            this.panel5.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SkyBlue;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLogin.Location = new System.Drawing.Point(90, 401);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(117, 37);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "S\'identifier";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnL_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(50, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Type:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(50, 365);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 1);
            this.panel6.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 1);
            this.panel7.TabIndex = 2;
            // 
            // rdA
            // 
            this.rdA.AutoSize = true;
            this.rdA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdA.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdA.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rdA.Location = new System.Drawing.Point(53, 344);
            this.rdA.Name = "rdA";
            this.rdA.Size = new System.Drawing.Size(60, 19);
            this.rdA.TabIndex = 12;
            this.rdA.TabStop = true;
            this.rdA.Text = "Admin";
            this.rdA.UseVisualStyleBackColor = true;
            // 
            // rdU
            // 
            this.rdU.AutoSize = true;
            this.rdU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdU.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdU.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rdU.Location = new System.Drawing.Point(138, 344);
            this.rdU.Name = "rdU";
            this.rdU.Size = new System.Drawing.Size(81, 19);
            this.rdU.TabIndex = 13;
            this.rdU.TabStop = true;
            this.rdU.Text = "Utilisateur";
            this.rdU.UseVisualStyleBackColor = true;
            // 
            // lblE
            // 
            this.lblE.AutoSize = true;
            this.lblE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblE.ForeColor = System.Drawing.Color.Red;
            this.lblE.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblE.Location = new System.Drawing.Point(12, 378);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(41, 15);
            this.lblE.TabIndex = 14;
            this.lblE.Text = "Erreur";
            this.lblE.Visible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.Controls.Add(this.lblE);
            this.Controls.Add(this.rdU);
            this.Controls.Add(this.rdA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.pnlH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlH;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rdA;
        private System.Windows.Forms.RadioButton rdU;
        private System.Windows.Forms.Label lblE;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnC;
        private System.Windows.Forms.PictureBox btnM;
    }
}

