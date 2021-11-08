using Xamarin.Forms;
using MopileApps.Client;
using System;


namespace MopileApps
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            
            MainServer viewModel = new MainServer();
            this.BindingContext = viewModel;
            Console.Write(viewModel);
        }
    }
}
