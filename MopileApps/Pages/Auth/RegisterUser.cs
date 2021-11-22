using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MopileApps.Pages
{
    public class RegisterUser : ContentPage
    {
        public RegisterUser()
        {
            Title = "Регистрация пользователя";
            Button btn = new Button
            {
                Text = "Регистрация",
                HorizontalOptions = LayoutOptions.Center
            };
            btn.Clicked += AuthForm;
            Content = btn;
        }
        private async void AuthForm(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}