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
    public partial class RegisterPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public RegisterPage()
        {
            InitializeComponent();
        }

        async void SUBMIT_Clicked(object sender, EventArgs e)
        {
            if (txtEmail.Text == txtEmailConfirm.Text && txtPassword.Text == txtPasswordConfirm.Text)
            {
                await firebaseHelper.NewUser(txtEmail.Text, txtPassword.Text, txtFirstName.Text, txtLastName.Text);
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                await DisplayAlert("Success", "User Registered Successfuly", "OK");
                var allExpense = await firebaseHelper.GetAllUser();
                await Navigation.PushAsync(new LoginPage());
            }
            else if(!(txtPassword.Text == txtPasswordConfirm.Text) && txtEmail.Text==txtEmailConfirm.Text)
            {
                await DisplayAlert("Error", "Passwords do not match.","OK");
            }
            else if (!(txtEmail.Text == txtEmailConfirm.Text) && txtPassword.Text == txtPasswordConfirm.Text)
            {
                await DisplayAlert("Error", "Emails do not match.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Emails and Passwords do not match.", "OK");
            }

            base.OnBackButtonPressed();
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
