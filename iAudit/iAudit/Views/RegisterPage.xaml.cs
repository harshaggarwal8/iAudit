using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iAudit.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void SUBMIT_Clicked(object sender, EventArgs e)
        {
            base.OnBackButtonPressed();
        //      return true;
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
