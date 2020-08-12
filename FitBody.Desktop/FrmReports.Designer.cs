namespace FitBody.Desktop
{
    partial class FrmReports
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
            this.btnPosts = new System.Windows.Forms.Button();
            this.postsDataGrid = new System.Windows.Forms.DataGridView();
            this.usersDataGrid = new System.Windows.Forms.DataGridView();
            this.btnUsers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.postsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPosts
            // 
            this.btnPosts.Location = new System.Drawing.Point(467, 364);
            this.btnPosts.Name = "btnPosts";
            this.btnPosts.Size = new System.Drawing.Size(89, 23);
            this.btnPosts.TabIndex = 9;
            this.btnPosts.Text = "Export to Excel";
            this.btnPosts.UseVisualStyleBackColor = true;
            this.btnPosts.Click += new System.EventHandler(this.btnPosts_Click_1);
            // 
            // postsDataGrid
            // 
            this.postsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.postsDataGrid.Location = new System.Drawing.Point(36, 218);
            this.postsDataGrid.Name = "postsDataGrid";
            this.postsDataGrid.Size = new System.Drawing.Size(520, 140);
            this.postsDataGrid.TabIndex = 8;
            // 
            // usersDataGrid
            // 
            this.usersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGrid.Location = new System.Drawing.Point(36, 29);
            this.usersDataGrid.Name = "usersDataGrid";
            this.usersDataGrid.Size = new System.Drawing.Size(520, 140);
            this.usersDataGrid.StandardTab = true;
            this.usersDataGrid.TabIndex = 7;
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(460, 175);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(96, 23);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "Export to Excel";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click_1);
            // 
            // FrmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 417);
            this.Controls.Add(this.btnPosts);
            this.Controls.Add(this.postsDataGrid);
            this.Controls.Add(this.usersDataGrid);
            this.Controls.Add(this.btnUsers);
            this.Name = "FrmReports";
            this.Text = "FrmReports";
            this.Load += new System.EventHandler(this.FrmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPosts;
        private System.Windows.Forms.DataGridView postsDataGrid;
        private System.Windows.Forms.DataGridView usersDataGrid;
        private System.Windows.Forms.Button btnUsers;
    }
}