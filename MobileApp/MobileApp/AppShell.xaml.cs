using MobileApp.ViewModels;
using MobileApp.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AuthPage), typeof(AuthPage));
            Routing.RegisterRoute(nameof(RegistrPage), typeof(RegistrPage));
            Routing.RegisterRoute(nameof(RedaNewPage), typeof(RedaNewPage));
            Routing.RegisterRoute(nameof(RegistrPage), typeof(RegistrPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AuthPage");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://open-broker.ru/dos/");
        }

        public string FName => "bkfwe";
    }
}
