using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using iAudit.Helper;
using iAudit.Models;
using iAudit.Views;
using iAudit.ViewModels;
using System.IO;
using Xamarin.Essentials;

namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class ExpenseListPage : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://iaudit-e62d6.firebaseio.com");
        int currentYear;
        String currentMonth;
        ExpenseViewModel viewModel;
        public ExpenseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExpenseViewModel();
        }

        public ExpenseListPage(int year, String month)
        {
            InitializeComponent();
            BindingContext = viewModel = new ExpenseViewModel(); 
            currentMonth = month;
            currentYear = year;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var expense = args.SelectedItem as Expense;
            if (expense == null)
                return;

            await Navigation.PushAsync(new ExpenseDetailsPage(expense));

            //Manually deselect item.
            ExpenseListView.SelectedItem = null;
        }

        private async void Expenses_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var expense = e.SelectedItem as Expense;
            if (expense == null)
                return;
            FirebaseHelper firebaseHelper = new FirebaseHelper();
            var expenses = await firebaseHelper.GetAllExpense();
            await firebase
              .Child("Expense/Year")
              .OrderByKey()
              .EqualTo(2019)
              .OnceAsync<Expense>();
            ExpensesYearList.ItemsSource = expenses;
        }

        async void AddExpense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddExpensePage(currentYear, currentMonth)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
          if (viewModel.Expenses.Count == 0) //change after expenses.count
              viewModel.LoadItemsCommand.Execute(null);
        }

        async void EMAIL_Clicked(object sender, EventArgs e) //When user wants to get an email of the report
        {

            //Send email body --
            List<string> recipient = new List<string>();
            recipient.Add("harsh.aggarwal@mavs.uta.edu"); //Right now, hardcoding my email for recieving the data
            recipient.Add("officialharshagg8@gmail.com");
            await SendEmail("iAudit Expense Log", "Here's your expense log-", recipient);

        }


        ////////
        /////////////
        ////////
        /// EMAIL SENDING FUNCTION IN BETA TESTING
        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                /*
                var fn = "Attachment.txt";
                var file = Path.Combine(FileSystem.CacheDirectory, fn);
                File.WriteAllText(file, "Hello World");

                message.Attachments.Add(new EmailAttachment(file)); //adding attachment to the email here
                */
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    }
}

