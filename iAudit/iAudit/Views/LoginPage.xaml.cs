using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;
using iAudit.ViewModels;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        UserViewModel viewModel;
        public LoginPage(UserViewModel viewModel)
        {
            //var image = new Image { };
            //image.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("logo.png") : ImageSource.FromFile("logo.png");
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public LoginPage()
        {
            InitializeComponent();
        }

        async void LOGIN_Clicked(object sender, EventArgs e)
        {

            //if accepted go here
            await Navigation.PushAsync(new YearsPage());

            //else make them fix
        }

        async void REGISTER_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}



