using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignalRXam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        string _username;
        IList<SignalRUser> model = new ObservableCollection<SignalRUser>();
        SignalRClient client = new SignalRClient();


        public ChatPage(string username)
        {
            InitializeComponent();
            _username = username;
            client.Connect(_username);
            client.ConnectionError += Client_ConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;
            this.BindingContext = model;
        }

        private void Client_OnMessageReceived(SignalRUser user)
        {
            model.Add(user);
        }

        private void Client_ConnectionError()
        {
            DisplayAlert("Connection", "Error", "Ok");
        }

        void SendMessage(object sender, EventArgs e)
        {
            client.SendMessage(_username, txtMessage.Text);
            txtMessage.Text = "";
            txtMessage.Focus();
        }

    }
}