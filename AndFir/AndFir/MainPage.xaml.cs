using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndFir
{
    public partial class MainPage : ContentPage
    {
        Button box_btn, entry_btn, date_btn,ss_btn;
        public MainPage()
        {
            box_btn = new Button
            {
                Text = "Boxview",
                BackgroundColor = Color.Red,
                TextColor=Color.Black
            };
            box_btn.Clicked += Start_Pages;

            entry_btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.Orange,
                TextColor = Color.Black
            };
            entry_btn.Clicked += Start_Pages;

            date_btn = new Button
            {
                Text = "Date/Time",
                BackgroundColor = Color.Yellow,
                TextColor = Color.Black
            };
            date_btn.Clicked += Start_Pages;

            ss_btn = new Button
            {
                Text = "Stepper-Slider",
                BackgroundColor = Color.Green,
                TextColor = Color.Black
            };
            ss_btn.Clicked += Start_Pages;

            StackLayout st = new StackLayout
            {
                Children = { box_btn, entry_btn, date_btn, ss_btn }
            };
            st.BackgroundColor = Color.Black;
            Content = st;
        }

        private async void Start_Pages(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (sender == date_btn)
            {
                await Navigation.PushAsync(new Date_Page());
            }
            else if (sender == entry_btn)
            {
                await Navigation.PushAsync(new Entry_Page());
            }
            else if (sender == box_btn)
            {
                await Navigation.PushAsync(new Box_Page());
            }
            else if (sender == ss_btn)
            {
                await Navigation.PushAsync(new Stp_Sl_Page());
            }
        }
    }
}
