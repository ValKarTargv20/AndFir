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
    public partial class Stp_Sl_Page : ContentPage
    {
        Label lbl;
        Stepper stp;
        Slider sl;

        public Stp_Sl_Page()
        {
            InitializeComponent();
            lbl = new Label
            {
                Text = "Text",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            sl = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                MaximumTrackColor=Color.Red,
                MinimumTrackColor=Color.Green,
                ThumbColor=Color.Purple //chvet begunka
            };
            sl.ValueChanged += Sl_ValueChanged;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 10,
                HorizontalOptions = LayoutOptions.Center
                
            };
            stp.ValueChanged += Stp_ValueChanged;
            BackgroundColor = Color.LightGreen;
            this.Content = new StackLayout { Children = { sl, lbl, stp } };
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Slideri vaartus on {0:F1}", e.NewValue);
            lbl.TextColor = Color.DarkGreen;
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue * 3.6;
        }

        private void Sl_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Slideri vaartus on {0:F1}",e.NewValue);
            lbl.TextColor = Color.DarkGreen;
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue * 3.6;
        }
    }
}