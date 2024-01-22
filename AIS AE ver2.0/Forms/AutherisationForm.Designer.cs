namespace AIS_AE_ver2._0
{
    partial class AutherisationForm
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
            this.AutherisationGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DecanatInfoLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordTestBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.HelloLabel2 = new System.Windows.Forms.Label();
            this.HelloLabel = new System.Windows.Forms.Label();
            this.AutherisationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutherisationGroupBox
            // 
            this.AutherisationGroupBox.Controls.Add(this.label1);
            this.AutherisationGroupBox.Controls.Add(this.DecanatInfoLabel);
            this.AutherisationGroupBox.Controls.Add(this.LoginButton);
            this.AutherisationGroupBox.Controls.Add(this.PasswordTestBox);
            this.AutherisationGroupBox.Controls.Add(this.LoginTextBox);
            this.AutherisationGroupBox.Controls.Add(this.PasswordLabel);
            this.AutherisationGroupBox.Controls.Add(this.LoginLabel);
            this.AutherisationGroupBox.Controls.Add(this.HelloLabel2);
            this.AutherisationGroupBox.Controls.Add(this.HelloLabel);
            this.AutherisationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AutherisationGroupBox.Name = "AutherisationGroupBox";
            this.AutherisationGroupBox.Size = new System.Drawing.Size(591, 295);
            this.AutherisationGroupBox.TabIndex = 0;
            this.AutherisationGroupBox.TabStop = false;
            this.AutherisationGroupBox.Text = "Вхід";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(210, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Авторизація через \"ДіЯ\"";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // DecanatInfoLabel
            // 
            this.DecanatInfoLabel.AutoSize = true;
            this.DecanatInfoLabel.ForeColor = System.Drawing.Color.Red;
            this.DecanatInfoLabel.Location = new System.Drawing.Point(6, 264);
            this.DecanatInfoLabel.Name = "DecanatInfoLabel";
            this.DecanatInfoLabel.Size = new System.Drawing.Size(553, 16);
            this.DecanatInfoLabel.TabIndex = 7;
            this.DecanatInfoLabel.Text = " Увага!  Якщо ви не можете зайти чи не маєте облікового запису - пишіть у деканат" +
    "!";
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginButton.Location = new System.Drawing.Point(115, 195);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(349, 37);
            this.LoginButton.TabIndex = 6;
            this.LoginButton.Text = "Вхід";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordTestBox
            // 
            this.PasswordTestBox.Location = new System.Drawing.Point(169, 155);
            this.PasswordTestBox.Name = "PasswordTestBox";
            this.PasswordTestBox.Size = new System.Drawing.Size(276, 22);
            this.PasswordTestBox.TabIndex = 5;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(169, 116);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(276, 22);
            this.LoginTextBox.TabIndex = 4;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(89, 155);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(59, 16);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Пароль:";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(89, 116);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(44, 16);
            this.LoginLabel.TabIndex = 2;
            this.LoginLabel.Text = "Логін:";
            // 
            // HelloLabel2
            // 
            this.HelloLabel2.AutoSize = true;
            this.HelloLabel2.Font = new System.Drawing.Font("Segoe UI Historic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelloLabel2.Location = new System.Drawing.Point(188, 58);
            this.HelloLabel2.Name = "HelloLabel2";
            this.HelloLabel2.Size = new System.Drawing.Size(174, 23);
            this.HelloLabel2.TabIndex = 1;
            this.HelloLabel2.Text = "Увійдіть в систему!";
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelloLabel.Location = new System.Drawing.Point(41, 27);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(529, 31);
            this.HelloLabel.TabIndex = 0;
            this.HelloLabel.Text = "Вас вітає система \"Електронний журнал\"!";
            // 
            // AutherisationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 319);
            this.Controls.Add(this.AutherisationGroupBox);
            this.Name = "AutherisationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вхід в систему";
            this.AutherisationGroupBox.ResumeLayout(false);
            this.AutherisationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AutherisationGroupBox;
        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox PasswordTestBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label HelloLabel2;
        private System.Windows.Forms.Label DecanatInfoLabel;
        private System.Windows.Forms.Label label1;
    }
}

