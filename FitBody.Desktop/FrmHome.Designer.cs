namespace FitBody.Desktop
{
    partial class FrmHome
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
            this.components = new System.ComponentModel.Container();
            this.StyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitBlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitForumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicsSuggestedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.StyleManager)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StyleManager
            // 
            this.StyleManager.Owner = null;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.postsToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.tagsToolStripMenuItem,
            this.fitBlogToolStripMenuItem,
            this.fitForumToolStripMenuItem,
            this.topicsSuggestedToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(841, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // postsToolStripMenuItem
            // 
            this.postsToolStripMenuItem.Name = "postsToolStripMenuItem";
            this.postsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.postsToolStripMenuItem.Text = "Posts";
            this.postsToolStripMenuItem.Click += new System.EventHandler(this.postsToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // tagsToolStripMenuItem
            // 
            this.tagsToolStripMenuItem.Name = "tagsToolStripMenuItem";
            this.tagsToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.tagsToolStripMenuItem.Text = "Tags";
            this.tagsToolStripMenuItem.Click += new System.EventHandler(this.tagsToolStripMenuItem_Click);
            // 
            // fitBlogToolStripMenuItem
            // 
            this.fitBlogToolStripMenuItem.Name = "fitBlogToolStripMenuItem";
            this.fitBlogToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fitBlogToolStripMenuItem.Text = "FitBlog";
            this.fitBlogToolStripMenuItem.Click += new System.EventHandler(this.fitBlogToolStripMenuItem_Click);
            // 
            // fitForumToolStripMenuItem
            // 
            this.fitForumToolStripMenuItem.Name = "fitForumToolStripMenuItem";
            this.fitForumToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.fitForumToolStripMenuItem.Text = "FitForum";
            this.fitForumToolStripMenuItem.Click += new System.EventHandler(this.fitForumToolStripMenuItem_Click);
            // 
            // topicsSuggestedToolStripMenuItem
            // 
            this.topicsSuggestedToolStripMenuItem.Name = "topicsSuggestedToolStripMenuItem";
            this.topicsSuggestedToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.topicsSuggestedToolStripMenuItem.Text = "Topics suggested";
            this.topicsSuggestedToolStripMenuItem.Click += new System.EventHandler(this.topicsSuggestedToolStripMenuItem_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 434);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmHome";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StyleManager)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager StyleManager;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitBlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitForumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topicsSuggestedToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip;
    }
}