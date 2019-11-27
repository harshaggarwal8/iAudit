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
    public partial class AddExpensePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public Expense expense{ get; set; }
        
        public AddExpensePage()
        {
            InitializeComponent();

      /*     expense = new Expense
            {
                ExpenseName = "Expense",
                Notes = "No Notes.",
                Date = "MM-DD-YYYY",
                Amount = 000.00,
                Category = "Expense"
            };

            BindingContext = this;
        */}
        
        public AddExpensePage(Year year, String month)
        {
            InitializeComponent();

 /*           expense = new Expense
            {
                ExpenseName = "Expense",
                Notes = "No Notes.",
                Date = "MM-DD-YYYY",
                Year = year,
                Month = month,
                Amount = 000.00,
                Category = "Expense"
            };

            BindingContext = this;*/
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allExpense = await firebaseHelper.GetAllExpense();
            lstExpense.ExpenseSource = allExpense;
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddExpense(txtExpenseName.Text, txtNotes.Text, Convert.toDouble(txtAmount.Text), Convert.ToInt32(txtYear.Text), txtMonth.text, Convert.ToInt32(txtDay.Text), txtCategory.Text);
            txtExpenseName.Text = string.Empty;
            txtNotes.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtMonth.Text = string.Empty;
            txtDay.Text = string.Empty;
            txtCategory.Text = string.Empty;
            await DisplayAlert("Success", "Expense Added Successfully", "OK");
            var allExpense = await firebaseHelper.GetAllExpense();
            lstExpense.ExpenseSource = allExpense;   
         //   MessagingCenter.Send(this, "AddExpense", expense);
           // await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
