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
            //MainServer viewModel = new MainServer();
            //this.BindingContext = viewModel;
            Label label = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Hello",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 2
            };
            int count = 0;
            tapGesture.Tapped += (s, e) =>
            {
                count++;
                if (count % 2 == 0)
                {
                    label.BackgroundColor = Color.Black;
                    label.TextColor = Color.White;
                }
                else
                {
                    label.BackgroundColor = Color.Red;
                    label.TextColor = Color.Gray;
                }
                label.Text = $"Ты нажал { count } раз ";
            };
            label.GestureRecognizers.Add(tapGesture);
            Content = label;
        }
    }
}
