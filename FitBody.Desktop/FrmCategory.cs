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
    public partial class FrmCategory : Form
    {
        private ApiService _categoryService = new ApiService("categories");
        private IList<CategoryDto> _categoryDtos = new List<CategoryDto>();


        public FrmCategory()
        {
            InitializeComponent();
        }

        private async void FrmCategory_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
           await LoadCategory();
        }
        private async Task LoadCategory()
        {
            _categoryDtos= await _categoryService.Get<List<CategoryDto>>();
            categoriesGrid.DataSource = _categoryDtos;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            CategorySearchRequest request = new CategorySearchRequest
            {
                Title = txtTitle.Text
            };
            var categories = await _categoryService.Post<List<CategoryDto>>(request, "search");
            categoriesGrid.DataSource = categories;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCategory frm = new FrmAddCategory();
            frm.FormClosing += Frm_FormClosing;
            frm.Show();
        }

        private async void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await LoadCategory();
        }
    }
}
