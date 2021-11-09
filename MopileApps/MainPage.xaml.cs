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
            StackLayout stackLayout = new StackLayout();

            Button btn = new Button()
            {
                Text = "Press",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            btn.Clicked += btnPress;
            Label header = new Label();
            this.Content = header;

            FormattedString formattedString = new FormattedString();
            formattedString.Spans.Add(new Span
            {
                Text = "News ",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });
            formattedString.Spans.Add(new Span
            {
                Text = "хорошая",
                FontAttributes = FontAttributes.Bold
            });
            formattedString.Spans.Add(new Span
            {
                Text = " погода!",
                ForegroundColor = Color.Red
            });
            header.FormattedText = formattedString;

            header.VerticalTextAlignment = TextAlignment.Center;
            header.HorizontalTextAlignment = TextAlignment.Center;

            stackLayout.Children.Add(btn);

        }
        private void btnPress(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Нажат";
            button.BackgroundColor = Color.Red;
        }
    }
}
