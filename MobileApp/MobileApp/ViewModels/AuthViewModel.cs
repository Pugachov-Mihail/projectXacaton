using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using MobileApp.Models;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    class AuthViewModel
    {
        public AuthViewModel()
        {
            TryAuthCommand = new Command(async () => await AuthCommand());
        }

        async Task AuthCommand()
        {
            bool isSuccessAuth;
            User user;
            try
            {
                var mds = new MockDataStore();
                (isSuccessAuth, user) = await mds.GetUserAsync(Login, Password);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public string Login;
        public string Password;

        public ICommand TryAuthCommand { get; }
    }

}
