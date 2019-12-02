using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class AddIncomePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        private int currentYear;
        private string currentMonth;

        public Income income { get; set; }
        
        public AddIncomePage()
        {
            InitializeComponent();
        }

        public AddIncomePage(int currentYear, string currentMonth)
        {
            this.currentYear = currentYear;
            this.currentMonth = currentMonth;
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allIncome = await firebaseHelper.GetAllIncome();
           //lstIncome.IncomeSource = allIncome;
        } 

        async void Add_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddIncome(txtIncomeName.Text, txtNotes.Text, Convert.ToDouble(txtAmount.Text), Convert.ToInt32(txtYear.Text), txtMonth.Text, Convert.ToInt32(txtDay.Text), txtCategory.Text);
            txtIncomeName.Text = string.Empty;
            txtNotes.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtMonth.Text = string.Empty;
            txtDay.Text = string.Empty;
            txtCategory.Text = string.Empty;
            await DisplayAlert("Success", "Income Added Successfully", "OK");
            var allItems = await firebaseHelper.GetAllIncome();
          //  lstIncome.IncomeSource = allIncome;            
           // MessagingCenter.Send(this, "AddIncome", income);
            await Navigation.PushAsync(new AddIncomePage());
          //  await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}