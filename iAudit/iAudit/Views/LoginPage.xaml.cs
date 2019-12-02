using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using iAudit.Helper;
using iAudit.Models;
using iAudit.Views;
using System.Linq;
using System.Text;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

      /*  UserViewModel viewModel;
        public LoginPage(UserViewModel viewModel)
        {
            //var image = new Image { };
            //image.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("logo.png") : ImageSource.FromFile("logo.png");
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
        */
        public LoginPage()
        {
            InitializeComponent();
        }

        async void LOGIN_Clicked(object sender, EventArgs e)
        {
            //if accepted go here
            var user = await firebaseHelper.GetUser(txtEmail.Text, txtPassword.Text);
            if (user != null)
            {
                await Navigation.PushAsync(new AddExpensePage());
            }
            else
            {//Incorrect info
                await DisplayAlert("Error", "Email or Password is wrong", "OK");
            }
        }

        async void REGISTER_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}



