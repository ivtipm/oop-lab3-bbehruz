namespace Chat_Bot
{
    partial class LoginForm
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
            this.Label = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.LoginButton1 = new System.Windows.Forms.Button();
            this.LoginButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Franklin Gothic Heavy", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label.ForeColor = System.Drawing.Color.Gold;
            this.Label.Location = new System.Drawing.Point(86, 72);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(200, 26);
            this.Label.TabIndex = 0;
            this.Label.Text = "Введите своё имя:";
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserName.Location = new System.Drawing.Point(54, 122);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(261, 31);
            this.UserName.TabIndex = 1;
            // 
            // LoginButton1
            // 
            this.LoginButton1.BackColor = System.Drawing.Color.YellowGreen;
            this.LoginButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton1.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginButton1.ForeColor = System.Drawing.Color.Black;
            this.LoginButton1.Location = new System.Drawing.Point(71, 183);
            this.LoginButton1.Name = "LoginButton1";
            this.LoginButton1.Size = new System.Drawing.Size(90, 35);
            this.LoginButton1.TabIndex = 3;
            this.LoginButton1.Text = "Выйти";
            this.LoginButton1.UseVisualStyleBackColor = false;
            this.LoginButton1.Click += new System.EventHandler(this.LoginButton1_Click);
            // 
            // LoginButton2
            // 
            this.LoginButton2.BackColor = System.Drawing.Color.YellowGreen;
            this.LoginButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton2.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginButton2.ForeColor = System.Drawing.Color.Black;
            this.LoginButton2.Location = new System.Drawing.Point(205, 183);
            this.LoginButton2.Name = "LoginButton2";
            this.LoginButton2.Size = new System.Drawing.Size(90, 35);
            this.LoginButton2.TabIndex = 3;
            this.LoginButton2.Text = "Войти";
            this.LoginButton2.UseVisualStyleBackColor = false;
            this.LoginButton2.Click += new System.EventHandler(this.LoginButton2_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Chat_Bot.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.LoginButton2);
            this.Controls.Add(this.LoginButton1);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Label);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Button LoginButton1;
        private System.Windows.Forms.Button LoginButton2;
    }
}