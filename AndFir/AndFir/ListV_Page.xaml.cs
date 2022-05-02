using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndFir
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    
    public partial class ListV_Page : ContentPage
    {
        public class Telefon
        {
            public string Nimetus { get; set; }
            public string Tootja { get; set; }
            public int Hind { get; set; }
            public string Pilt { get; set; }
        }
        public class Ruhm<K,T> : ObservableCollection<T>
        {
            public K Nimetus { get; private set; }
            public Ruhm(K nimetus, IEnumerable<T> items)
            {
                Nimetus = nimetus;
                foreach (T item in items)
                    Items.Add(item);
            }
        }

        public ObservableCollection<Ruhm<string,Telefon>> telefonideruhmades { get; set; }
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        public ListV_Page()
        {
            lbl_list = new Label
            {
                Text="Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            lisa = new Button { Text = "Lisa telefon" };
            lisa.Clicked += Lisa_Clicked;

            kustuta = new Button { Text = "Kustuta Telefon" };
            kustuta.Clicked += Kustuta_Clicked;

            var telefonid = new List<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy S22 Ultra", Tootja="Samsung", Hind=1349, Pilt="GalaxyS22.jpg"},
                new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G NE", Tootja="Xiaomi", Hind=399, Pilt = "Xiaomi5GNE.jpg"},
                new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G", Tootja="Xiaomi", Hind=399, Pilt = "XiaomiMiLite.jpg"},
                new Telefon {Nimetus="iPhone 13", Tootja="Apple", Hind=1179, Pilt= "iPhone13.png"},
            };
            var ruhmad = telefonid.GroupBy(p => p.Tootja).Select(g => new Ruhm<string, Telefon>(g.Key, g));
            telefonideruhmades = new ObservableCollection<Ruhm<string, Telefon>>(ruhmad);
            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Telefonid ruhmades",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = telefonideruhmades,
                IsGroupingEnabled = true,
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "Nimetus");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { tootja }
                        }
                    };
                }),
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nimetus = new Label { FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimetus");
                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Hind");

                    //ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    //imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    //Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefone firmalt {0}" };
                    //imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    //imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    //return imageCell;

                    /*Label nimetus = new Label { FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimetus");

                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "Tootja");

                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Hind");*/

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0,5),
                            Orientation = StackOrientation.Vertical,
                            Children = {nimetus, hind}
                        }
                    };
                })
            };
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta } };
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if(phone != null)
            {
                telefonideruhmades.Remove(phone);
                list.SelectedItem = null;
            }
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
            telefonideruhmades.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "Ok");
        }
    }
}