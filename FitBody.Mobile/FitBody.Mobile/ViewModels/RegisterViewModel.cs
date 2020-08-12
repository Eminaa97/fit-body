using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using FitBody.Mobile.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitBody.Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private ApiService _usersService = new ApiService("users");

        public RegisterViewModel()
        {
            Submit = new Command(async () => await Register());
        }

        string _username = string.Empty;
        public string UserName
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }


        string _firstname = string.Empty;
        public string FirstName
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }

        string _lastname = string.Empty;
        public string LastName
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        string _confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { SetProperty(ref _confirmPassword, value); }
        }

        DateTime _birthdate = DateTime.UtcNow;
        public DateTime BirthDate
        {
            get { return _birthdate; }
            set { SetProperty(ref _birthdate, value); }
        }

        string _mobile = string.Empty;
        public string Mobile
        {
            get { return _mobile; }
            set { SetProperty(ref _mobile, value); }
        }

        string _info = string.Empty;
        public string Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }

        float _height = 0.0f;
        public float Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value); }
        }

        float _weight = 0.0f;
        public float Weight
        {
            get { return _weight; }
            set { SetProperty(ref _weight, value); }
        }
        public ICommand Submit { get; set; }

        async Task Register()
        {
            try
            {
                if (ConfirmPassword != Password)
                {
                    throw new Exception("Passwords do not match.");
                }

                var request = new UserInsertRequest()
                {
                    Email = Email,
                    FirstName = FirstName,
                    Password = Password,
                    LastName = LastName,
                    UserName = UserName,
                    BirthDate = BirthDate,
                    Height = Height,
                    Info = Info,
                    Mobile = Mobile,
                    Weight = Weight,
                    ConfirmPassword = ConfirmPassword
                };

                await _usersService.Post<UserDto>(request, "register");

                Application.Current.MainPage = new LoginPage();
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid information passed", "OK");
            }
        }
    }
}
