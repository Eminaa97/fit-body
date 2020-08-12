using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmTags : Form
    {
        private ApiService _tagService = new ApiService("tags");

        public FrmTags()
        {
            InitializeComponent();
        }


        private async void FrmTags_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            await LoadTags();
        }
        private async Task LoadTags ()
        {
            var tags =await _tagService.Get<List<TagDto>>();
            tagsGrid.DataSource = tags;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            TagSearchRequest request = new TagSearchRequest
            {
                Title = txtTitle.Text
            };
            var tags = await _tagService.Post<List<TagDto>>(request, "search");
            tagsGrid.DataSource = tags;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddTag frm = new FrmAddTag();
            frm.FormClosing += Frm_FormClosing;
            frm.Show();
        }

        private async void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await LoadTags();
        }
    }
}
