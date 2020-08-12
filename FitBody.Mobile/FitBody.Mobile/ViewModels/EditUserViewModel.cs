using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitBody.Mobile.ViewModels
{
    public class EditUserViewModel : BaseViewModel
    {
        private ApiService _userService = new ApiService("users");
        private UserUpdateRequest _user;
        public ICommand InitCommand { get; set; }

        #region Properties
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value);
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                SetProperty(ref _lastName, value);
            }
        }

        private string _height;
        public string Height
        {
            get => _height;
            set
            {
                SetProperty(ref _height, value);
            }
        }

        private string _weight;
        public string Weight
        {
            get => _weight;
            set
            {
                SetProperty(ref _weight, value);
            }
        }

        private string _info;
        public string Info
        {
            get => _info;
            set
            {
                SetProperty(ref _info, value);
            }
        }

        private string _mobile;
        public string Mobile
        {
            get => _mobile;
            set
            {
                SetProperty(ref _mobile, value);
            }
        }

        private string _image;
        public string Image
        {
            get => _image;
            set
            {
                SetProperty(ref _image, value);
            }
        }

        public int Permission { get; set; }

        #endregion

        public EditUserViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public async Task Init()
        {
            var user = await _userService.Get<UserDto>(null, $"{ApiService.LoggedInUserId}");
            Username = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Height = user.Height.ToString();
            Weight = user.Weight.ToString();
            Info = user.Info;
            Mobile = user.Mobile;
            Image = user.Image;
            Permission = user.Permission;
        }

        public async Task Save()
        {
            _user = new UserUpdateRequest()
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Height = float.Parse(Height),
                Image = Image,
                Info = Info,
                Mobile = Mobile,
                Permission = Permission,
                UserName = Username,
                Weight = float.Parse(Weight)
            };

            await _userService.Update<UserDto>(ApiService.LoggedInUserId, _user);
        }
    }
}
