using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmHome : Form
    {
        private int childFormNumber = 0;
        private ApiService _reportsService = new ApiService("reports");
        public FrmHome()
        {
            InitializeComponent();
        }


        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsers childForm = new FrmUsers
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }

        private void postsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPosts childForm = new FrmPosts
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            FrmReports childForm = new FrmReports
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }
       
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategory childForm = new FrmCategory
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }

        private void tagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTags childForm = new FrmTags
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }

        private void fitBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFitBlog childForm = new FrmFitBlog
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }

        private void fitForumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFitForum childForm = new FrmFitForum
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }


        private void topicsSuggestedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTopicsSuggested childForm = new FrmTopicsSuggested
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReports childForm = new FrmReports
            {
                Text = "Window " + childFormNumber++,
                MdiParent = this
            };
            childForm.Show();
        }
    }
}
