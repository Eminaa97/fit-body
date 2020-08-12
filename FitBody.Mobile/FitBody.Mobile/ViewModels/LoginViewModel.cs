using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using FitBody.Mobile.Views;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitBody.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ApiService _usersService = new ApiService("users");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                try
                {
                    IsBusy = true;
                    var authentication = await _usersService.Post<AuthenticatedUser>(new UserLoginRequest
                    {
                        UserName = Username,
                        Password = Password
                    }, "login");

                    if (authentication != null)
                    {
                        ApiService.Token = authentication.Token;
                        ApiService.Permission = authentication.Permission;
                        ApiService.LoggedInUserId = authentication.Id;

                        SignalR.HubConnection = new HubConnectionBuilder()
                            .WithUrl($"{ApiService.Url}/notifications", options =>
                            {
                                options.AccessTokenProvider = () => Task.FromResult(ApiService.Token);
                            })
                            .Build();

                        SignalR.HubConnection.On<string, string>("ReceiveNotification", (userFollowers, creator) =>
                        {
                            var followers = JsonConvert.DeserializeObject<IList<int>>(userFollowers);

                            if (followers.Any(x => x == ApiService.LoggedInUserId))
                            {
                                Application.Current.MainPage.DisplayAlert("Alert", $"User {creator} added a new post", "OK");
                            }

                        });

                        Application.Current.MainPage = new MainPage();
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Error", "Login failed, please check your username and password", "OK");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            });

            RegistrationCommand = new Command(async () =>
            {
                try
                {
                    Application.Current.MainPage = new RegistrationPage();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            });
        }

        private string _password;
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
            }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }
    }
}
