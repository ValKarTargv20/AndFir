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

        public Frame_Page()
        {
            lbl = new Label
            {
                Text = "Raami kirjundus",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)), //zadaem razmer s devisa
                HorizontalOptions=LayoutOptions.Center
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
            grid.Children.Add(new BoxView { Color = Color.AliceBlue },0, 0);
            grid.Children.Add(new BoxView { Color = Color.Aquamarine }, 1, 0);
            grid.Children.Add(new BoxView { Color = Color.CadetBlue }, 0, 1);
            grid.Children.Add(new BoxView { Color = Color.DarkOrchid }, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.DarkKhaki }, 0, 2);
            grid.Children.Add(new BoxView { Color = Color.LightGray }, 1, 2);

            frame = new Frame
            {
                Content = grid,
                BorderColor = Color.Azure,
                CornerRadius = 30,
                VerticalOptions=LayoutOptions.FillAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = {lbl, frame}
            };
            Content = st;
        }
    }
}