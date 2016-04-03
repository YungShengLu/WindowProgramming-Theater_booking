namespace F74039025_HW1 {
    partial class Form_login {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent() {
            this.panel_login_1 = new System.Windows.Forms.Panel();
            this.groupBox_login = new System.Windows.Forms.GroupBox();
            this.label_login_message = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_login_password = new System.Windows.Forms.TextBox();
            this.textBox_login_user = new System.Windows.Forms.TextBox();
            this.label_login_password = new System.Windows.Forms.Label();
            this.label_login_user = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_login_title_1 = new System.Windows.Forms.Label();
            this.panel_login_1.SuspendLayout();
            this.groupBox_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_login_1
            // 
            this.panel_login_1.Controls.Add(this.groupBox_login);
            this.panel_login_1.Controls.Add(this.label1);
            this.panel_login_1.Controls.Add(this.label_login_title_1);
            this.panel_login_1.Location = new System.Drawing.Point(23, 28);
            this.panel_login_1.Name = "panel_login_1";
            this.panel_login_1.Size = new System.Drawing.Size(539, 339);
            this.panel_login_1.TabIndex = 0;
            // 
            // groupBox_login
            // 
            this.groupBox_login.Controls.Add(this.label_login_message);
            this.groupBox_login.Controls.Add(this.button_login);
            this.groupBox_login.Controls.Add(this.textBox_login_password);
            this.groupBox_login.Controls.Add(this.textBox_login_user);
            this.groupBox_login.Controls.Add(this.label_login_password);
            this.groupBox_login.Controls.Add(this.label_login_user);
            this.groupBox_login.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_login.Location = new System.Drawing.Point(39, 106);
            this.groupBox_login.Name = "groupBox_login";
            this.groupBox_login.Size = new System.Drawing.Size(462, 214);
            this.groupBox_login.TabIndex = 2;
            this.groupBox_login.TabStop = false;
            this.groupBox_login.Text = "會員登入 Membership Login";
            // 
            // label_login_message
            // 
            this.label_login_message.AutoSize = true;
            this.label_login_message.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_login_message.Location = new System.Drawing.Point(50, 134);
            this.label_login_message.Name = "label_login_message";
            this.label_login_message.Size = new System.Drawing.Size(0, 17);
            this.label_login_message.TabIndex = 5;
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_login.Location = new System.Drawing.Point(50, 163);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(362, 34);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "登    入";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_login_password
            // 
            this.textBox_login_password.Location = new System.Drawing.Point(138, 91);
            this.textBox_login_password.Name = "textBox_login_password";
            this.textBox_login_password.PasswordChar = '●';
            this.textBox_login_password.Size = new System.Drawing.Size(274, 29);
            this.textBox_login_password.TabIndex = 3;
            this.textBox_login_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_login_password_KeyPress);
            // 
            // textBox_login_user
            // 
            this.textBox_login_user.Location = new System.Drawing.Point(138, 44);
            this.textBox_login_user.Name = "textBox_login_user";
            this.textBox_login_user.Size = new System.Drawing.Size(274, 29);
            this.textBox_login_user.TabIndex = 2;
            this.textBox_login_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_login_user_KeyPress);
            // 
            // label_login_password
            // 
            this.label_login_password.AutoSize = true;
            this.label_login_password.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_login_password.Location = new System.Drawing.Point(46, 91);
            this.label_login_password.Name = "label_login_password";
            this.label_login_password.Size = new System.Drawing.Size(86, 24);
            this.label_login_password.TabIndex = 1;
            this.label_login_password.Text = "會員密碼";
            // 
            // label_login_user
            // 
            this.label_login_user.AutoSize = true;
            this.label_login_user.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_login_user.Location = new System.Drawing.Point(46, 44);
            this.label_login_user.Name = "label_login_user";
            this.label_login_user.Size = new System.Drawing.Size(86, 24);
            this.label_login_user.TabIndex = 0;
            this.label_login_user.Text = "會員帳戶";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(112, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "電 影 訂 票 系 統";
            // 
            // label_login_title_1
            // 
            this.label_login_title_1.AutoSize = true;
            this.label_login_title_1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_login_title_1.ForeColor = System.Drawing.Color.Maroon;
            this.label_login_title_1.Location = new System.Drawing.Point(200, 14);
            this.label_login_title_1.Name = "label_login_title_1";
            this.label_login_title_1.Size = new System.Drawing.Size(132, 27);
            this.label_login_title_1.TabIndex = 0;
            this.label_login_title_1.Text = "T.H.E.A.T.E.R";
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 379);
            this.Controls.Add(this.panel_login_1);
            this.MaximumSize = new System.Drawing.Size(601, 418);
            this.MinimumSize = new System.Drawing.Size(601, 418);
            this.Name = "Form_login";
            this.Text = "Theater Booking";
            this.panel_login_1.ResumeLayout(false);
            this.panel_login_1.PerformLayout();
            this.groupBox_login.ResumeLayout(false);
            this.groupBox_login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_login_1;
        private System.Windows.Forms.GroupBox groupBox_login;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox textBox_login_password;
        private System.Windows.Forms.TextBox textBox_login_user;
        private System.Windows.Forms.Label label_login_password;
        private System.Windows.Forms.Label label_login_user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_login_title_1;
        private System.Windows.Forms.Label label_login_message;
    }
}

