using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MopileApps
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            StackLayout stackLayout = new StackLayout();
            for(int i=1; i<20; i++)
            {
                Label label = new Label
                {
                    Text = "Вывод: " + i,
                    FontSize = 30
                };
                stackLayout.Children.Add(label);
            }
            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            this.Content = scrollView;
        }
    }
}
