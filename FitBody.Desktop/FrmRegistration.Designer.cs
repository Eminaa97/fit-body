namespace FitBody.Desktop
{
    partial class FrmRegistration
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
            this.txtLastname = new MetroFramework.Controls.MetroTextBox();
            this.txtFirstname = new MetroFramework.Controls.MetroTextBox();
            this.txtInfo = new MetroFramework.Controls.MetroTextBox();
            this.txtConfirmPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.txtBirthdate = new System.Windows.Forms.DateTimePicker();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtMobile = new MetroFramework.Controls.MetroTextBox();
            this.txtWeight = new MetroFramework.Controls.MetroTextBox();
            this.txtHeight = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnBrowse = new MetroFramework.Controls.MetroButton();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnRegister = new MetroFramework.Controls.MetroButton();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.chckPermission = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(156, 93);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.PromptText = "Lastname";
            this.txtLastname.Size = new System.Drawing.Size(172, 23);
            this.txtLastname.TabIndex = 1;
            this.txtLastname.Text = "Lastname";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(156, 64);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.PromptText = "Firstname";
            this.txtFirstname.Size = new System.Drawing.Size(172, 23);
            this.txtFirstname.TabIndex = 0;
            this.txtFirstname.Text = "Firstname";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(34, 367);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.PromptText = "Info";
            this.txtInfo.Size = new System.Drawing.Size(294, 77);
            this.txtInfo.TabIndex = 10;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(181, 210);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.PromptText = "Confirm password";
            this.txtConfirmPassword.Size = new System.Drawing.Size(147, 23);
            this.txtConfirmPassword.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(34, 210);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PromptText = "Password";
            this.txtPassword.Size = new System.Drawing.Size(141, 23);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(156, 151);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PromptText = "Username";
            this.txtUsername.Size = new System.Drawing.Size(172, 23);
            this.txtUsername.TabIndex = 3;
            // 
            // txtBirthdate
            // 
            this.txtBirthdate.Location = new System.Drawing.Point(156, 243);
            this.txtBirthdate.Name = "txtBirthdate";
            this.txtBirthdate.Size = new System.Drawing.Size(172, 20);
            this.txtBirthdate.TabIndex = 6;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(62, 244);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(67, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Birth date";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(156, 272);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.PromptText = "Mobile";
            this.txtMobile.Size = new System.Drawing.Size(116, 23);
            this.txtMobile.TabIndex = 7;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(156, 306);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PromptText = "Weight";
            this.txtWeight.Size = new System.Drawing.Size(116, 23);
            this.txtWeight.TabIndex = 8;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(156, 338);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.PromptText = "Height";
            this.txtHeight.Size = new System.Drawing.Size(116, 23);
            this.txtHeight.TabIndex = 9;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(76, 276);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(50, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Mobile";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(82, 342);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(47, 19);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Height";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(79, 310);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(50, 19);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Weight";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(46, 180);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(83, 24);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(34, 64);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(109, 110);
            this.picAvatar.TabIndex = 17;
            this.picAvatar.TabStop = false;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(172, 482);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 11;
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(156, 122);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PromptText = "Email";
            this.txtEmail.Size = new System.Drawing.Size(172, 23);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "Email";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(253, 482);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chckPermission
            // 
            this.chckPermission.AutoSize = true;
            this.chckPermission.Location = new System.Drawing.Point(269, 450);
            this.chckPermission.Name = "chckPermission";
            this.chckPermission.Size = new System.Drawing.Size(59, 17);
            this.chckPermission.TabIndex = 18;
            this.chckPermission.Text = "Trainer";
            this.chckPermission.UseVisualStyleBackColor = true;
            // 
            // FrmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 540);
            this.Controls.Add(this.chckPermission);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtBirthdate);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.txtLastname);
            this.Name = "FrmRegistration";
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtLastname;
        private MetroFramework.Controls.MetroTextBox txtFirstname;
        private MetroFramework.Controls.MetroTextBox txtInfo;
        private MetroFramework.Controls.MetroTextBox txtConfirmPassword;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private System.Windows.Forms.DateTimePicker txtBirthdate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtMobile;
        private MetroFramework.Controls.MetroTextBox txtWeight;
        private MetroFramework.Controls.MetroTextBox txtHeight;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton btnBrowse;
        private System.Windows.Forms.PictureBox picAvatar;
        private MetroFramework.Controls.MetroButton btnRegister;
        private MetroFramework.Controls.MetroTextBox txtEmail;
        private MetroFramework.Controls.MetroButton btnCancel;
        private System.Windows.Forms.CheckBox chckPermission;
    }
}