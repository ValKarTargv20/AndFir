using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndFir
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame frame;
        Button new_btn;
        ImageButton back_btn, home_btn;
        Entry line;

        List<string> lehed = new List<string> { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee/", "https://www.google.com" };

        public Picker_Page()
        {
            BackgroundColor = Color.AntiqueWhite;

            picker = new Picker
            {
                Title = "Webilehed",
                TitleColor=Color.Black
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            home_btn = new ImageButton
            {
                Source = "Home.png",
                WidthRequest = 40,
                HeightRequest = 40
            };
            home_btn.Clicked += btn_Clicked;

            back_btn = new ImageButton
            {
                Source = "Next.png",
                WidthRequest = 40,
                HeightRequest = 40
            };
            back_btn.Clicked += btn_Clicked;

            new_btn = new Button
            {
                Text = "#",
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                WidthRequest = 40,
                HeightRequest = 40
            };
            new_btn.Clicked += btn_Clicked;

            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;

            line = new Entry { 
                Placeholder = "Kirjuta webileht",
                PlaceholderColor = Color.Black,
                TextColor = Color.Black,
                WidthRequest = 180,
                HeightRequest = 40
            };
            line.Completed += Line_Completed;

            StackLayout buttons = new StackLayout
            {
                Children = {line, new_btn, back_btn, home_btn},
                Orientation = StackOrientation.Horizontal
            };
            
            frame = new Frame
            {
                Content = buttons,
                BorderColor = Color.Lime,
                BackgroundColor=Color.Yellow,
                CornerRadius = 10,
                HeightRequest = 60,
                WidthRequest = 400,
                VerticalOptions=LayoutOptions.Start,
                //HorizontalOptions=LayoutOptions.CenterAndExpand,
                HasShadow =true
            };
            
            st = new StackLayout { Children = { picker, frame } };
            frame.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            if(sender == home_btn)
            {
                webView.Source = new UrlWebViewSource { Url = lehed[3] };
            }
            else if (sender == back_btn)
            {
                if (webView.CanGoBack)
                {
                    webView.GoBack();
                }
            }
            else if(sender == new_btn)
            {
                lehed.Add("https://www." + line.Text);
                picker.Items.Add("https://www." + line.Text);
            }
            st.Children.Add(webView);
        }

        private void Line_Completed(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = "https://www." + line.Text,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            st.Children.Add(webView);

        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            frame.BackgroundColor = Color.Green;
            webView.Source = new UrlWebViewSource { Url = lehed[3] };
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex]},
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }
    }
}