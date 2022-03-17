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
    public partial class Entry_Page : ContentPage
    {
        Label lbl;
        Editor editor;
        public Entry_Page()
        {
            lbl = new Label
            {
                Text = "Pealkiri",
                TextColor = Color.Black
                
            };
            editor = new Editor
            {
                Placeholder = "Sisesta mingi text siia",
                PlaceholderColor=Color.Black,
                TextColor = Color.Black,
                BackgroundColor = Color.Yellow,
                Keyboard = Keyboard.Email //dlja klaviatury, pozvoljaet usovershenstvovat' klaviaturu i dobavit' @
            };
            editor.TextChanged += Editor_TextChanged;
            StackLayout st = new StackLayout { Children = { editor, lbl } };
            Content = st;
            BackgroundColor = Color.LightCoral;
        }

        int i = 0;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            editor.TextChanged += Editor_TextChanged;
            char k = e.NewTextValue?.LastOrDefault() ?? ' ';
            if(k=='T')
            {
                i++;
                lbl.Text = k.ToString() + ": " + i + " korda oli sisestatud";
            }
            editor.TextChanged += Editor_TextChanged;
        }
    }
}