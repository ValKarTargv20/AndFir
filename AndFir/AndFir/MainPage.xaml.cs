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
        public MainPage()
        {
            Button box_btn = new Button
            {
                Text = "Boxview",
                BackgroundColor = Color.Aquamarine
            };

            Button entry_btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.Red
            };
            entry_btn.Clicked += Entry_btn_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { box_btn, entry_btn }
            };
            st.BackgroundColor = Color.Black;
            Content = st;
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entry_Page());
        }

        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Box_Page());
        }
    }
}
