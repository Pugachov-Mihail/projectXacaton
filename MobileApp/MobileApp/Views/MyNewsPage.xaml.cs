using MobileApp.Models;
using MobileApp.ViewModels;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    public partial class MyNewsPage : ContentPage
    {
        MyNewsViewModel _viewModel;

        public MyNewsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MyNewsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}