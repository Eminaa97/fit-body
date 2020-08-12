using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FitBody.Mobile.Models;

namespace FitBody.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.RecommendedPosts, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            var Id = (MenuItemType)id;

            if (!MenuPages.ContainsKey(id))
            {
                switch (Id)
                {
                    case MenuItemType.RecommendedPosts:
                        MenuPages.Add(id, new NavigationPage(new RecommendedPostsPage()));
                        break;
                    case MenuItemType.Posts:
                        MenuPages.Add(id, new NavigationPage(new PostsPage()));
                        break;
                    case MenuItemType.Users:
                        MenuPages.Add(id, new NavigationPage(new UsersPage()));
                        break;
                    case MenuItemType.TopicsSuggested:
                        MenuPages.Add(id, new NavigationPage(new TopicsSuggestedPage()));
                        break;
                    case MenuItemType.FitBlog:
                        MenuPages.Add(id, new NavigationPage(new FitBlogPage()));
                        break;
                    case MenuItemType.FitForum:
                        MenuPages.Add(id, new NavigationPage(new FitForumPage()));
                        break;
                    case MenuItemType.EditProfile:
                        MenuPages.Add(id, new NavigationPage(new EditUserPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}