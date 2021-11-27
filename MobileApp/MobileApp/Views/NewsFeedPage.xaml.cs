using System;
using System.Diagnostics;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    public partial class NewsFeedPage : ContentPage
    {
        public NewsFeedPage()
        {
            InitializeComponent();
            
        }

        private void SwipeGestureRecognizer_Swiped_1(object sender, SwipedEventArgs e)
        {
            Debug.WriteLine("ok");
        }
    }
}