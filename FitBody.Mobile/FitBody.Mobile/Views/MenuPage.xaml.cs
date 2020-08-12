using FitBody.Mobile.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace FitBody.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.RecommendedPosts, Title="Recommendations" },
                new HomeMenuItem {Id = MenuItemType.Posts, Title="Posts" },
                new HomeMenuItem {Id = MenuItemType.Users, Title="Users" },
                new HomeMenuItem {Id = MenuItemType.FitBlog, Title="FitBlog" },
                new HomeMenuItem {Id = MenuItemType.FitForum, Title="FitForum" },
                new HomeMenuItem {Id = MenuItemType.EditProfile, Title="Edit Profile" }
            };

            if (ApiService.Permission > 0)
            {
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.TopicsSuggested, Title = "Suggested topics" });
            }

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}