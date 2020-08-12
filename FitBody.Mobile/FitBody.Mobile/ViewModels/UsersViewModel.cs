using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitBody.Mobile.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private ApiService _usersService = new ApiService("users");
        public ObservableCollection<UserDto> UsersList { get; set; } = new ObservableCollection<UserDto>();
        public ICommand InitCommand { get; set; }

        public UsersViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            try
            {
                UsersList.Clear();
                var users = await _usersService.Get<IList<UserDto>>();

                foreach (var item in users)
                {
                    UsersList.Add(item);
                }

            }
            catch
            {
                throw;
            }
        }
        public async Task Filter(string Username)
        {
            try
            {
                var userSearch = await _usersService.Get<IList<UserDto>>(new UserSearchRequest
                {
                    UserName = Username
                });
                UsersList.Clear();

                foreach (var item in userSearch)
                {
                    UsersList.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
