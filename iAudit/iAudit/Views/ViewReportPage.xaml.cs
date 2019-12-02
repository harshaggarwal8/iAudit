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
using System.Collections.ObjectModel;
using System.Diagnostics;
using iAudit.Services;
using iAudit.ViewModels;

namespace iAudit.Views
{
    
    public partial class ViewReportPage : ContentPage
    {
        public double Income { get; set; }
        public double Expense { get; set; }
        public double Profit_Loss { get; set; }
        public double Projection { get; set; }
        public string month { get; set; }
        public Year year { get; set; }

        ObservableCollection<Income> Incomes;
        Command LoadIncomesCommand { get; set; }
        ObservableCollection<Expense> Expenses;
        Command LoadExpensesCommand { get; set; }

        public ViewReportPage()
        {
            InitializeComponent();
        }

        public ViewReportPage(Year year, String month)
        {
            InitializeComponent();
            this.year = year;
            this.month = month;

        }
        protected override async void OnAppearing()
        {
            /* Will load items in order to be able to use them when creating the instantiations of the new graphs*/
            Incomes = new ObservableCollection<Income>();
            LoadIncomesCommand = new Command(async () => await ExecuteLoadIncomesCommand());
            Expenses = new ObservableCollection<Expense>();
            LoadExpensesCommand = new Command(async () => await ExecuteLoadExpensesCommand());

            base.OnAppearing();
            /*
             * Null check and  filter out if needed what is necessary in order for report to be accurate
             * Check if correct year and month if they even exist if they do add if they dont match ignore
             * and if they dont exist assumer viewing a report for all year so add
             */

            if (Incomes != null)
            {
                foreach (var income in Incomes)
                {
                    if (year != null)
                    {
                        if (income.Year == year)
                        {
                            if (month != null)
                            {
                                if (income.Month.Equals(month))
                                {
                                    Income += income.Amount;
                                }
                            }
                            else
                            {
                                Income += income.Amount;
                            }

                        }
                    }
                    else
                    {
                        Income += income.Amount;
                    }
                }
            }

            foreach (var expense in Expenses)
            {
                if (year != null)
                {
                    if (expense.Year == year)
                    {
                        if (month != null)
                        {
                            if (expense.Month.Equals(month))
                            {
                                Expense += expense.Amount;
                            }
                        }
                        else
                        {
                            Expense += expense.Amount;
                        }

                    }
                }
                else
                {
                    Expense += expense.Amount;
                }
            }

            /* calculate the amounts for the following graphs
             * will be overwritten for the rest
             * */
            string amountIncome = Income.ToString();
            string amountExpense = Expense.ToString();
            Profit_Loss = Income - Expense;
            string amountLeft = Profit_Loss.ToString();

            // bar graph will only show the difference between income and expense and resulting profit or loss
            var entries = new[]
            {

                new Microcharts.Entry(1000)
                {
                    Label = "INCOME",
                    ValueLabel = amountIncome,
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(4020)
                {
                    Label = "EXPENSE",
                    ValueLabel = amountExpense,
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "PROFIT/LOSS",
                    ValueLabel = amountLeft,
                    Color = SKColor.Parse("#0084b4")
                }
            };

            
            var chart = new BarChart() { Entries = entries };
            this.chartView.Chart = chart;

            /* this line graph will now show the increase decrease
             * throughout the entire year, monthly */
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
                },
                new Microcharts.Entry(-100)
                {
                    Label = "April",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "May",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "June",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "July",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "August",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "September",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "October",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "November",
                    ValueLabel = "9000",
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "December",
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

            var point = new PointChart() { Entries = entries2 };
            this.pointView.Chart = point;

            var gauge = new RadialGaugeChart() { Entries = entries2 };
            this.gaugeView.Chart = gauge;

            var radar = new RadarChart() { Entries = entries2 };
            this.radarView.Chart = radar;

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

        /* next two commands will load income and expense collection by calling on view model which has access to
         * DataStore which can then retrieve all information necessary to fill in data to the collections held in this
         * class and that will be needed in order to make calculations and fill graphs/ tables */
        async Task ExecuteLoadIncomesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                IncomeViewModel incomeModel = new IncomeViewModel();
                Incomes.Clear();
                var incomes = (System.Collections.ObjectModel.ObservableCollection<iAudit.Models.Income>)await incomeModel.DataStore.GetIncomeAsync(true);


                foreach (var income in incomes)
                {
                    Incomes.Add(income);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadExpensesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ExpenseViewModel expenseModel = new ExpenseViewModel();
                Expenses.Clear();
                var expenses = (System.Collections.ObjectModel.ObservableCollection<iAudit.Models.Expense>)await expenseModel.DataStore.GetExpenseAsync(true);


                foreach (var expense in expenses)
                {
                    Expenses.Add(expense);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
