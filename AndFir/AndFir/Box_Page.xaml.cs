using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndFir
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Box_Page : ContentPage
    {
        BoxView box;
        Random rdn;
        public Box_Page()
        {
            box = new BoxView
            {
                Color = Color.FromRgb(12, 128, 8),
                CornerRadius = 20, //sglazhivanie uglov
                WidthRequest = 100, //shirina ekrana
                HeightRequest = 200, //vysota ekrana
                HorizontalOptions = LayoutOptions.CenterAndExpand, //zapolnenije po gorizontale
                VerticalOptions = LayoutOptions.FillAndExpand //zapolnenije po verticale
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);

            StackLayout st = new StackLayout { Children = { box } };
            Content = st;

        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            rdn = new Random();
            box.Color = Color.FromRgb(rdn.Next(0, 255), rdn.Next(0, 255), rdn.Next(0, 255));
            box.Rotation += 25;
            try
            {
                Vibration.Vibrate();
                var dur = TimeSpan.FromSeconds(0.3);
                Vibration.Vibrate(dur);
            }
            catch
            {
                throw;
            }
        }
    }
}