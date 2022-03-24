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
    public partial class Frame_Page : ContentPage
    {
        Frame frame;
        Label lbl;
        Grid grid;
        BoxView box;

        public Frame_Page()
        {
            InitializeComponent();
            BackgroundColor = Color.LightPink;
            lbl = new Label
            {
                Text = "Raami kirjundus",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)), //zadaem razmer s devisa
                HorizontalOptions=LayoutOptions.Center
                //
            };
            grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(2,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(2,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                }
            };
            /*zapolnenie setki vruchnuju
            grid.Children.Add(new BoxView { Color = Color.AliceBlue },0, 0);
            grid.Children.Add(new BoxView { Color = Color.Aquamarine }, 1, 0);
            grid.Children.Add(new BoxView { Color = Color.CadetBlue }, 0, 1);
            grid.Children.Add(new BoxView { Color = Color.DarkOrchid }, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.DarkKhaki }, 0, 2);
            grid.Children.Add(new BoxView { Color = Color.LightGray }, 1, 2);*/

            for (int r=0; r< 3; r++)
            {
                for(int c =0; c<2; c++)
                {
                    box = new BoxView { Color = Color.Green };
                    grid.Children.Add(box, c, r);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    box.GestureRecognizers.Add(tap);
                }
            }            

            frame = new Frame
            {
                Content = grid,
                BorderColor = Color.Violet,
                CornerRadius = 30,
                VerticalOptions=LayoutOptions.FillAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = {lbl, frame}
            };
            Content = st;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            var box = (BoxView)sender;
            var r = Grid.GetRow(box); // koordinty klika po setke
            var c = Grid.GetColumn(box);
            box.Color = Color.Black;
        }
    }
}