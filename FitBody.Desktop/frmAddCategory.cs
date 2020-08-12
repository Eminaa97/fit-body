using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmAddCategory : Form
    {
        private ApiService _categoryService = new ApiService("categories");
        private ApiService _subCategoryService = new ApiService("subcategories");

        private List<SubcategoryInsertModel> _subcategoriesToInsert = new List<SubcategoryInsertModel>();

        public FrmAddCategory()
        {
            InitializeComponent();
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            dataGridSubategories.DataSource = new BindingList<SubcategoryInsertModel>(_subcategoriesToInsert);

            dataGridSubategories.AllowUserToAddRows = true;
            dataGridSubategories.Columns[1].Visible = false;
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryInsertModel category = new CategoryInsertModel
                {
                    Title = txtTitle.Text
                };

                var addedCategory = await _categoryService.Post<CategoryDto>(category);

                var subcategoriesToAdd = new List<SubcategoryInsertModel>();

                for (int i = 0; i < dataGridSubategories.Rows.Count; i++)
                {
                    if (i != dataGridSubategories.Rows.Count - 1)
                    {
                        var row = dataGridSubategories.Rows[i] as DataGridViewRow;
                        var cell = row.Cells[0];

                        subcategoriesToAdd.Add(new SubcategoryInsertModel
                        {
                            Title = cell.Value.ToString(),
                            CategoryId = addedCategory.Id
                        });
                    }
                }

                foreach (var item in subcategoriesToAdd)
                {
                    await _subCategoryService.Post<dynamic>(item);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
