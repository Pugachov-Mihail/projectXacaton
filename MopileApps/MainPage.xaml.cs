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
            //
            MainServer viewModel = new MainServer();
            viewModel.LoadData();
            this.BindingContext = viewModel;

            
        }
    }
}
