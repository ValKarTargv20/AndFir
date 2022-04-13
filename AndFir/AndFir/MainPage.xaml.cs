using System;
using Xamarin.Forms;

namespace AndFir
{
    public partial class MainPage : ContentPage
    {
        Button box_btn, entry_btn, date_btn,ss_btn, timer_btn, rgb_btn, frame_btn, image_btn, picker_btn, table_btn;
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

            timer_btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.LightBlue,
                TextColor = Color.Black
            };
            timer_btn.Clicked += Start_Pages;

            rgb_btn = new Button
            {
                Text = "RGB",
                BackgroundColor = Color.Blue,
                TextColor = Color.Black
            };
            rgb_btn.Clicked += Start_Pages;

            frame_btn = new Button
            {
                Text = "Frame",
                BackgroundColor = Color.DarkViolet,
                TextColor = Color.Black
            };
            frame_btn.Clicked += Start_Pages;

            image_btn = new Button
            {
                Text = "Images",
                BackgroundColor = Color.Firebrick,
                TextColor = Color.Black
            };
            image_btn.Clicked += Start_Pages;

            picker_btn = new Button
            {
                Text = "Picker",
                BackgroundColor = Color.Coral,
                TextColor = Color.Black
            };
            picker_btn.Clicked += Start_Pages;

            table_btn = new Button
            {
                Text = "Table",
                BackgroundColor = Color.YellowGreen,
                TextColor = Color.Black
            };
            table_btn.Clicked += Start_Pages;

            StackLayout st = new StackLayout
            {
                Children = { box_btn, entry_btn, date_btn, ss_btn, timer_btn, rgb_btn, frame_btn, image_btn, picker_btn,table_btn }
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
            else if (sender == timer_btn)
            {
                await Navigation.PushAsync(new Timer_Page());
            }
            else if (sender == rgb_btn)
            {
                await Navigation.PushAsync(new RGB_Page());
            }
            else if (sender == frame_btn)
            {
                await Navigation.PushAsync(new Frame_Page());
            }
            else if (sender == image_btn)
            {
                await Navigation.PushAsync(new Image_Page());
            }
            else if (sender == picker_btn)
            {
                await Navigation.PushAsync(new Picker_Page());
            }
            else if (sender == table_btn)
            {
                await Navigation.PushAsync(new Table_Page());
            }
        }
    }
}
