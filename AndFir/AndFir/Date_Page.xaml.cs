using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndFir
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Date_Page : ContentPage
    {
        DatePicker dp;
        Label lbl;
        TimePicker tp;
        public Date_Page()
        {
            InitializeComponent();
            lbl = new Label
            {
                Text = "Vali mingi kuupaev voi kellaaeg",
                TextColor=Color.Black,
                BackgroundColor = Color.BurlyWood
            };

            dp = new DatePicker
            {
                Format = "D", //format daty
                MinimumDate = DateTime.Now.AddDays(-5),
                MaximumDate = DateTime.Now.AddDays(15),
                TextColor = Color.Black
            };
            dp.DateSelected += Dp_DateSelected;

            tp = new TimePicker
            {
                Time = new TimeSpan(12, 30, 00),
                TextColor = Color.Black
        };
            tp.PropertyChanged += Tp_PropertyChanged;

            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = {dp,lbl,tp} //chto otobrazhaem
            };
            AbsoluteLayout.SetLayoutBounds(dp, new Rectangle(0.1, 0.1, 200, 100));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.6, 300, 100));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.1, 0.3, 200, 100));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
            BackgroundColor = Color.LightYellow;
        }

        private void Tp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text = "Oli valitud aeg: " + dp.Date.ToString("d") + " " + tp.Time/*+"\n"+"Timer: "*/;
            TimerSec();
            lbl.TextColor = Color.Black;
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            lbl.Text = "Oli valitud paev: " + e.NewDate.ToString("d") + " " + tp.Time;
            lbl.TextColor = Color.Black;
        }

        private async void TimerSec()
        {
            var time = (int)(tp.Time.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds);
            while (time != 0)
            {
                await Task.Delay(1000);
                lbl.Text = time.ToString();
                time = (int)(tp.Time.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds);
                if (time == 0)
                {
                    lbl.BackgroundColor = Color.Red;
                    var dur = TimeSpan.FromSeconds(0.3);
                    Vibration.Vibrate(dur);
                    lbl.Text = "Aeg on läbi";
                    break;
                }
                else if (time < 0)
                {
                    lbl.Text = "Aeg on " + dp.Date.ToString("d") + " " + DateTime.Now.TimeOfDay.ToString();
                }
            }
        }
    }
}