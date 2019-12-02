using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iAudit.Models;
using iAudit.Views;
using iAudit.ViewModels;
using System.IO;
using Xamarin.Essentials;


namespace iAudit.Views
{
    [DesignTimeVisible(false)]
    public partial class IncomeListPage : ContentPage
    {
        Year currentYear;
        String currentMonth;
        IncomeViewModel viewModel;

        public IncomeListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new IncomeViewModel();
        }

        public IncomeListPage(Year year, String month)
        {
            InitializeComponent();
            BindingContext = viewModel = new IncomeViewModel();
            currentMonth = month;
            currentYear = year;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var income = args.SelectedItem as Income;
            if (income == null)
                return;

            await Navigation.PushAsync(new IncomeDetailsPage(income));

            // Manually deselect item.
            IncomeListView.SelectedItem = null;
        }

        async void AddIncome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddIncomePage(currentYear, currentMonth)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Incomes.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void EMAIL_Clicked(object sender, EventArgs e) //When user wants to get an email of the report
        {

            //Send email body --
            List<string> recipient = new List<string>();
            recipient.Add("harsh.aggarwal@mavs.uta.edu"); //Right now, hardcoding my email for recieving the data
            recipient.Add("officialharshagg8@gmail.com");
            await SendEmail("iAudit Income Log", "Here's your Income Log-", recipient);

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
