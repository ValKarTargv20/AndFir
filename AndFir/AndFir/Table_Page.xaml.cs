using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace AndFir
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Table_Page : ContentPage
    {
        TableView tableView;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection, nuppud;
        Button sms_btn;
        Button call_btn;
        Button email_btn;
        StackLayout st;
        ViewCell vc;
        EntryCell tel, post,te;
        public Table_Page()
        {
            call_btn = new Button { Text = "Helista" }; call_btn.Clicked += Call_btn_Clicked;
            sms_btn = new Button { Text = "Saada sms" }; sms_btn.Clicked += Sms_btn_Clicked;
            email_btn = new Button { Text = "Saada email" }; email_btn.Clicked += Email_btn_Clicked;
            tel = new EntryCell
            {
                Label = "Telefon:",
                Placeholder = "Sissesta tel. number",
                Keyboard = Keyboard.Telephone
            };
            post = new EntryCell
            {
                Label = "Email:",
                Placeholder = "Sissesta email",
                Keyboard = Keyboard.Email
            };
            te = new EntryCell
            {
                Label = "Tekst:",
                Placeholder = "Sissesta oma teskti:",
                Keyboard = Keyboard.Default
            };
            var st = new StackLayout
            {
                Children = { call_btn, sms_btn, email_btn },
                Orientation = StackOrientation.Horizontal
            };
            nuppud = new TableSection
            {
                new ViewCell() { View=st},
            };
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("Fox.jpg"),
                Text = "Foto nimetus",
                Detail = "Foto kirjeldus"
            };
            fotosection = new TableSection();

            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sissestamine")
                {
                    new TableSection("Põhiandmed:")
                    {
                        new EntryCell
                        {
                            Label="Nimi:",
                            Placeholder="Sissesta oma sõbra nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        tel,
                        post,
                        te,
                        sc
                        
                    },
                    fotosection,
                    nuppud
                }

            };
            Content = tableView;
            

        }

        private void Email_btn_Clicked(object sender, System.EventArgs e)
        {
            var email = CrossMessaging.Current.EmailMessenger;
            if (email.CanSendEmail)
            {
                email.SendEmail(post.Text, "Tere!", te.Text);
            }
        }

        private void Sms_btn_Clicked(object sender, System.EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel.Text, te.Text);
            }
        }

        private void Call_btn_Clicked(object sender, System.EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel.Text);
            }
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto:";
                fotosection.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(ic);
                sc.Text = "Näita veel";
            }
        }
    }
}