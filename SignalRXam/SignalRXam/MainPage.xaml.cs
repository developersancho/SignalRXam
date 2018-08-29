using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SignalRXam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void JoinChat(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text))
                App.Current.MainPage = new ChatPage(txtUsername.Text);
        }
    }
}
