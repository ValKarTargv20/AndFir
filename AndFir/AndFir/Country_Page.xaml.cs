using System;
using System.Collections.Generic;
using System.Linq;
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
            public string Information { get; set; }
        }

        Label list_lbl, coun_lbl;
        ListView list;
        Image img;
        Button lisa, kustuta, add_to;
        TableView tableView;
        EntryCell name, capital, population, flag, info;
        public List<Countries> country { get; set; }
        public Country_Page()
        {
            country = new List<Countries>
            {
                new Countries{ Name = "France", Capital = "Paris", Population = 62814233, Flag="Flag_of_France.png", Information= "Франция – это страна в Западной Европе, на территории которой находятся средневековые города, альпийские деревни и пляжи Средиземного моря. Париж, столица государства, славится своими домами моды, старейшими художественными музеями, в числе которых Лувр, и достопримечательностями, такими как Эйфелева башня. Франция известна своими винами и изысканной кухней. Наскальная живопись в пещере Ласко, амфитеатр Трех Галлий в Лионе и огромный Версальский дворец свидетельствуют о богатой истории этих мест."},
                new Countries{ Name = "Spain", Capital = "Madrid", Population = 47394223, Flag="Flag_of_Spain.png", Information= "Испания – европейская страна, расположенная на Пиренейском полуострове. Территория Испании разделена на 17 автономных регионов. В столице страны, Мадриде, находятся Королевский дворец и музей Прадо, где хранятся произведения европейских мастеров. В Сеговии можно посетить средневековый замок (Алькасар) и увидеть хорошо сохранившийся римский акведук. Барселона – столица автономного сообщества Каталония. Облик этого города определяют многочисленные причудливо-фантастические творения архитектора Антонио Гауди, среди которых храм Святого Семейства."},
                new Countries{ Name = "Sweden", Capital = "Stockholm", Population = 10380491, Flag="Flag_of_Sweden.png", Information = "Швеция – это государство в Скандинавии, география которого включает тысячи прибрежных островов и внутриматериковых озер, таежные леса и горы, покрытые ледниками. Все крупнейшие города – столица Стокгольм и расположенные на юго-востоке Гётеборг и Мальмё – являются приморскими. Стокгольм занимает 14 островов с более чем 50 мостами. Он известен средневековым районом Гамла-Стан (Старый город), а также королевскими дворцами и музеями, в числе которых музей под открытым небом Скансен."},
                new Countries{ Name = "Norway", Capital = "Oslo", Population = 5425270, Flag="Flag_of_Norway.png", Information="Норве́гия, официальное название — Короле́вство Норве́гия — государство в Северной Европе, располагающееся в западной части Скандинавского полуострова и на огромном количестве прилегающих мелких островов, а также архипелаге Шпицберген, островах Ян-Майен и Медвежий в Северном Ледовитом океане."},
                new Countries{Name = "TestDelete", Capital = "Try1", Population= 1, Flag ="Rose", Information="Test field for testing delete"},
            };

            lisa = new Button { Text = "Add Country" };
            lisa.Clicked += Lisa_Clicked;

            kustuta = new Button { Text = "Delete Country" };
            kustuta.Clicked += Kustuta_Clicked;

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
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Flag");
                    return imageCell;
                })
            };
            coun_lbl = new Label
            {
                TextColor = Color.Black
            };
            img = new Image
            {
                IsVisible = false
            };
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { list_lbl, list, coun_lbl, img, kustuta, lisa } };
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Countries selectedCountry = e.Item as Countries;
            if (selectedCountry != null)
                    await DisplayAlert("Information: ", $"Country: {selectedCountry.Name}, Capital: {selectedCountry.Capital}, Population: {selectedCountry.Population}, Information: {selectedCountry.Information}", "Ok");

        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Countries selectedCountry = list.SelectedItem as Countries;
            if (selectedCountry != null)
            {
                country.Remove(selectedCountry);
                list.SelectedItem = null;
                this.Content = new StackLayout { Children = { list_lbl, list, coun_lbl, img, kustuta, lisa } };
            }
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
            add_to = new Button { Text = "Add Contry" }; add_to.Clicked += Add_to_Clicked;
            name = new EntryCell
            {
                Label = "Name:",
                Placeholder = "Enter name of country",
                Keyboard = Keyboard.Default
            };
            capital = new EntryCell
            {
                Label = "Capital:",
                Placeholder = "Please enter country capital",
                Keyboard = Keyboard.Default
            };
            population = new EntryCell
            {
                Label = "Population:",
                Placeholder = "Enter population",
                Keyboard = Keyboard.Numeric
            };
            flag = new EntryCell
            {
                Label = "Flag:",
                Placeholder = "Add flag of country",
                Keyboard = Keyboard.Default
            };
            info = new EntryCell
            {
                Label = "Information",
                Placeholder = "Addional information for country",
                Keyboard = Keyboard.Text
            };
            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("New Country adding:")
                {
                    new TableSection("New Country:")
                    {
                        name
                    },
                    new TableSection("Country information:")
                    {
                        capital,
                        population,
                        flag,
                        info

                    },

                },

            };
            this.Content = new StackLayout { Children = { tableView, add_to } };

        }

        private async void Add_to_Clicked(object sender, EventArgs e)
        {
            foreach (Countries item in country.ToList())
            {
                if (item.Name != name.Text) {
                        country.Add(new Countries { Name = name.Text, Capital = capital.Text, Population = Convert.ToInt32(population.Text), Flag = "venice.jpg", Information = info.Text });
                        this.Content = new StackLayout { Children = { list_lbl, list, coun_lbl, img, kustuta, lisa } };
                }
                else
                {
                    await DisplayAlert("Attention!", "Please, enter new country!", "Ok");
                }
            }

        }
    }
}