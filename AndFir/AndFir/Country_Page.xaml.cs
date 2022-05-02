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
    public partial class Country_Page : ContentPage
    {
        public class Countries
        {
            public string Name { get; set; }
            public string Capital { get; set; }
            public int Population { get; set; }
            public string Flag { get; set; }
        }

        Label list_lbl;
        ListView list;
        public List<Countries> country { get; set; }
        public Country_Page()
        {
            country = new List<Countries>
            {
                new Countries{ Name = "France", Capital = "Paris", Population = 62814233, Flag="Flag_of_France.png"},
                new Countries{ Name = "Spain", Capital = "Madrid", Population = 47394223, Flag="Flag_of_Spain.png"},
                new Countries{ Name = "Sweden", Capital = "Stockholm", Population = 10380491, Flag="Flag_of_Sweden.png"},
                new Countries{ Name = "Norway", Capital = "Oslo", Population = 5425270, Flag="Flag_of_Norway.png"},
            };
            list_lbl = new Label
            {
                Text = "Country list",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = country,
                ItemTemplate = new DataTemplate(() =>
                {

                })
            };
            list.ItemSelected += List_ItemSelected;
            this.Content = new StackLayout { Children = { list_lbl, list } };
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                list_lbl.Text = e.SelectedItem.ToString();
        }
    }
}