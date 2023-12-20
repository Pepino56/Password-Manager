namespace PasswordManager
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_about = new System.Windows.Forms.Button();
            this.btn_newLog = new System.Windows.Forms.Button();
            this.txt_Passwd = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_logIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_about
            // 
            this.btn_about.BackColor = System.Drawing.Color.Transparent;
            this.btn_about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_about.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_about.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_about.Location = new System.Drawing.Point(498, 339);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(102, 24);
            this.btn_about.TabIndex = 15;
            this.btn_about.Text = "O autorovi";
            this.btn_about.UseVisualStyleBackColor = false;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            this.btn_about.MouseEnter += new System.EventHandler(this.btn_about_MouseEnter);
            this.btn_about.MouseLeave += new System.EventHandler(this.btn_about_MouseLeave);
            // 
            // btn_newLog
            // 
            this.btn_newLog.BackColor = System.Drawing.Color.Transparent;
            this.btn_newLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_newLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newLog.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_newLog.Location = new System.Drawing.Point(437, 221);
            this.btn_newLog.Name = "btn_newLog";
            this.btn_newLog.Size = new System.Drawing.Size(63, 30);
            this.btn_newLog.TabIndex = 14;
            this.btn_newLog.Text = "New";
            this.btn_newLog.UseVisualStyleBackColor = false;
            this.btn_newLog.Click += new System.EventHandler(this.btn_newLog_Click);
            this.btn_newLog.MouseEnter += new System.EventHandler(this.btn_newLog_MouseEnter);
            this.btn_newLog.MouseLeave += new System.EventHandler(this.btn_newLog_MouseLeave);
            // 
            // txt_Passwd
            // 
            this.txt_Passwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(106)))));
            this.txt_Passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Passwd.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Passwd.Location = new System.Drawing.Point(368, 98);
            this.txt_Passwd.Name = "txt_Passwd";
            this.txt_Passwd.PasswordChar = '*';
            this.txt_Passwd.Size = new System.Drawing.Size(218, 26);
            this.txt_Passwd.TabIndex = 13;
            // 
            // txt_UserName
            // 
            this.txt_UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(106)))));
            this.txt_UserName.CausesValidation = false;
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_UserName.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_UserName.Location = new System.Drawing.Point(368, 34);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(218, 26);
            this.txt_UserName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(364, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(364, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "User Name";
            // 
            // btn_logIn
            // 
            this.btn_logIn.BackColor = System.Drawing.Color.Transparent;
            this.btn_logIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logIn.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_logIn.Location = new System.Drawing.Point(395, 137);
            this.btn_logIn.Name = "btn_logIn";
            this.btn_logIn.Size = new System.Drawing.Size(145, 65);
            this.btn_logIn.TabIndex = 9;
            this.btn_logIn.Text = "Log In";
            this.btn_logIn.UseVisualStyleBackColor = false;
            this.btn_logIn.Click += new System.EventHandler(this.btn_logIn_Click);
            this.btn_logIn.MouseEnter += new System.EventHandler(this.btn_logIn_MouseEnter);
            this.btn_logIn.MouseLeave += new System.EventHandler(this.btn_logIn_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::PasswordManager.Properties.Resources.digital_circle_circuit_blue_background_futuristic_technology;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(614, 375);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.btn_newLog);
            this.Controls.Add(this.txt_Passwd);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_logIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(630, 414);
            this.MinimumSize = new System.Drawing.Size(630, 414);
            this.Name = "Form1";
            this.Text = "Password Manager - Log In";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Button btn_newLog;
        private System.Windows.Forms.TextBox txt_Passwd;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_logIn;
    }
}

