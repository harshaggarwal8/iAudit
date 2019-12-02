using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;

namespace iAudit.Views
{
    
    public partial class ViewReportPage : ContentPage
    {
        public double Income { get; set; }
        public double Expense { get; set; }
        public double Profit_Loss { get; set; }
        public double Projection{ get; set; }

        public ViewReportPage()
        {
            InitializeComponent();
        }

        public ViewReportPage(Year year, String month)
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var entries = new[]
            {
                new Microcharts.Entry(1000)
                {
                    Label = "January",
                    ValueLabel = "3000",
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(4020)
                {
                    Label = "February",
                    ValueLabel = "7000",
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                }
            };

            var chart = new BarChart() { Entries = entries };
            /*
            var chart = new LineChart() { Entries = entries };
            var chart1 = new BarChart() { Entries = entries };
            var chart2 = new PointChart() { Entries = entries };
            var chart3 = new DonutChart() { Entries = entries };
            var chart4 = new RadialGaugeChart() { Entries = entries };
            var chart5 = new RadarChart() { Entries = entries };
            */
            this.chartView.Chart = chart;

            var entries1 = new[]
            {
                new Microcharts.Entry(1000)
                {
                    Label = "January",
                    ValueLabel = "3000",
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(4020)
                {
                    Label = "February",
                    ValueLabel = "7000",
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                }
            };

            var line = new LineChart() { Entries = entries1 };

            this.lineView.Chart = line;

            var entries2 = new[]
            {
                new Microcharts.Entry(1000)
                {
                    Label = "Repairs",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#104250")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(4020)
                {
                    Label = "Machinery",
                    ValueLabel = "1500",
                    Color = SKColor.Parse("#F7A9B9")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "Inventory",
                    ValueLabel = "1000",
                    Color = SKColor.Parse("#0184b4")
                }
            };

            var donut = new DonutChart() { Entries = entries2 };

            this.donutView.Chart = donut;

            Income = 19000;
            Expense = 1200;
            Profit_Loss = Income - Expense;
            Projection = Profit_Loss / Income * 100;

        }
        async void EMAIL_Clicked(object sender, EventArgs e) //When user wants to get an email of the report
        {

            //Send email body --
            List<string> recipient = new List<string>();
            recipient.Add("harsh.aggarwal@mavs.uta.edu"); //Right now, hardcoding my email for recieving the data
            recipient.Add("officialharshagg8@gmail.com");
            await SendEmail("iAudit Report", "Here's your report-", recipient);
            
        }
        public ViewReportPage(Year year)
        {
            InitializeComponent();
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
