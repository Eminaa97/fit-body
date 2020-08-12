using FitBody.Common.Contracts;
using FitBody.Desktop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmPosts : Form
    {
        private ApiService _postService = new ApiService("posts");
        private ApiService _categoryService = new ApiService("categories");
        private ApiService _subcategoryService = new ApiService("subcategories");

        private IList<SubcategoryDto> _subcategoryDtos = new List<SubcategoryDto>();
        private IList<CategoryDto> _categoryDtos = new List<CategoryDto>();


        public FrmPosts()
        {
            InitializeComponent();
        }

        private async void FrmPosts_Load(object sender, System.EventArgs e)
        {
            if (ApiService.Permission == 0)
            {
                btnAdd.Visible = false;
            }
            btnEdit.Visible = false;
            WindowState = FormWindowState.Maximized;

            _categoryDtos = await _categoryService.Get<IList<CategoryDto>>(null);
            _subcategoryDtos = await _subcategoryService.Get<IList<SubcategoryDto>>(null);

            _categoryDtos.Insert(0, new CategoryDto
            {
                Id = 0,
                Title = "Select a category"
            });
            _subcategoryDtos.Insert(0, new SubcategoryDto
            {
                Id = 0,
                Title = "Select a subcategory"
            });

            boxCategory.DataSource = _categoryDtos;
            boxSubcategory.DataSource = _subcategoryDtos;

            await LoadPosts();

        }

        private async void btnFilter_Click(object sender, System.EventArgs e)
        {
            await LoadPosts();
        }

        private async Task LoadPosts()
        {
            var selectedSubcategory = boxSubcategory.SelectedItem as SubcategoryDto;
            var selectedCategory = boxCategory.SelectedItem as CategoryDto;

            var postSearchRequest = new PostSearchRequest
            {
                Title = txtTitle.Text,
                SubcategoryId = selectedSubcategory != null ? selectedSubcategory.Id : 0,
                CategoryId = selectedCategory.Id
            };

            var data = (await _postService.Get<List<PostDto>>(postSearchRequest, "search"))
                .Select(a => new PostDataGrid
                {
                    Id = a.Id,
                    Title = a.Title,
                    DateCreated = a.DateCreated,
                    Subcategory = a.Subcategoryname,
                    User = a.Username,
                    UserId = a.UserId
                }).ToList();

            dataGridView1.DataSource = data;
        }

        private void boxCategory_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            // change list of subcategory items based on selected category id
            var selected = boxCategory.SelectedItem as CategoryDto;
            var subC = _subcategoryDtos.Where(a => a.CategoryId == selected.Id).ToList();
            boxSubcategory.DataSource = subC;
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var index = dataGridView1.SelectedCells[0].RowIndex;
                var post = dataGridView1.Rows[index].DataBoundItem as PostDataGrid;

                FrmEditPost frm = new FrmEditPost(post.Id);
                frm.Show();
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)

            {
                var index = dataGridView1.SelectedCells[0].RowIndex;
                var post = dataGridView1.Rows[index].DataBoundItem as PostDataGrid;

                FrmEditPost frm = new FrmEditPost(null);
                frm.FormClosing += editFrm_FormClosing;
                frm.Show();
            }

        }

        private async void editFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await LoadPosts();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var index = dataGridView1.SelectedCells[0].RowIndex;
                var post = dataGridView1.Rows[index].DataBoundItem as PostDataGrid;

                FrmPostDetails frm = new FrmPostDetails(post.Id);
                frm.FormClosing += editFrm_FormClosing;
                frm.Show();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var index = dataGridView1.SelectedCells[0].RowIndex;
                var post = dataGridView1.Rows[index].DataBoundItem as PostDataGrid;

                if (post.UserId != ApiService.UserId)
                {
                    btnEdit.Visible = false;
                }
                else
                {
                    btnEdit.Visible = true;
                }

                if (ApiService.Permission == 2)
                {
                    btnEdit.Visible = true;
                }

                FrmPostDetails frm = new FrmPostDetails(post.Id);
                frm.FormClosing += editFrm_FormClosing;
                frm.Show();
            }
        }
    }
}
