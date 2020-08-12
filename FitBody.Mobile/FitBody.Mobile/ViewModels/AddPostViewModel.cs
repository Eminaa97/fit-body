using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitBody.Mobile.ViewModels
{
    public class AddPostViewModel : BaseViewModel
    {
        private ApiService _categoryService = new ApiService("categories");
        private ApiService _subcategoryService = new ApiService("subcategories");

        public ObservableCollection<CategoryDto> Categories { get; set; } = new ObservableCollection<CategoryDto>();
        public ObservableCollection<SubcategoryDto> Subcategories { get; set; } = new ObservableCollection<SubcategoryDto>();
        public IList<SubcategoryDto> AllSubcategories { get; set; }

        private CategoryDto _category;
        private SubcategoryDto _subcategory;
        public CategoryDto SelectedCategory
        {
            get
            {
                return _category;
            }
            set
            {
                SetProperty(ref _category, value);
            }
        }
        public SubcategoryDto SelectedSubcategory
        {
            get
            {
                return _subcategory;
            }
            set
            {
                SetProperty(ref _subcategory, value);
            }
        }
        public ICommand InitCommand { get; set; }

        public AddPostViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            var categories = await _categoryService.Get<IList<CategoryDto>>();
            AllSubcategories = await _subcategoryService.Get<IList<SubcategoryDto>>();

            Categories.Clear();
            Subcategories.Clear();

            foreach (var item in categories)
            {
                Categories.Add(item);
            }
            foreach (var item in AllSubcategories)
            {
                Subcategories.Add(item);
            }
        }

        public void FilterSubcategories()
        {
            var categoryId = SelectedCategory.Id;
            var subcategories = AllSubcategories.Where(a => a.CategoryId == categoryId).ToList();
            Subcategories.Clear();

            foreach (var item in subcategories)
            {
                Subcategories.Add(item);
            };
        }
    }
}
