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
        public double Jan;
        public double Feb;
        public double Mar;
        public double Apr;
        public double May;
        public double Jun;
        public double Jul;
        public double Aug;
        public double Sep;
        public double Oct;
        public double Nov;
        public double Dec;
        public double pay;
        public double donation;
        public double incomeOther;
        public double repair;
        public double investment;
        public double expenseOther;
        public string month { get; set; }
        public Year year { get; set; }

        ObservableCollection<Income> Incomes;
        ObservableCollection<Expense> Expenses;

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
            CreateIncomes();
            CreateExpenses();

            base.OnAppearing();
            /*
             * Null check and  filter out if needed what is necessary in order for report to be accurate
             * Check if correct year and month if they even exist if they do add if they dont match ignore
             * and if they dont exist assumer viewing a report for all year so add
             */

            foreach (var income in Incomes)
            {
                Income += income.Amount; 
            }

            foreach (var expense in Expenses)
            {
                Expense += expense.Amount;
            }

            /* calculate the amounts for the following graphs
             * will be overwritten for the rest
             * */
            
            Profit_Loss = Income - Expense;
            // bar graph will only show the difference between income and expense and resulting profit or loss
            var entries = new[]
            {
                new Microcharts.Entry((float)Income)
                {
                    Label = "INCOME",
                    ValueLabel = Income.ToString(),
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry((float)Expense)
                {
                    Label = "EXPENSE",
                    ValueLabel = Expense.ToString(),
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry((float)Profit_Loss)
                {
                    Label = "PROFIT/LOSS",
                    ValueLabel = Profit_Loss.ToString(),
                    Color = SKColor.Parse("#0084b4")
                }
            };

            
            var chart = new BarChart() { Entries = entries };
            this.chartView.Chart = chart;

            MonthlyEarnings();
            /* this line graph will now show the increase decrease
             * throughout the entire year, monthly */
            var entries1 = new[]
            {
                new Microcharts.Entry((float)Jan)
                {
                    Label = "January",
                    ValueLabel = Jan.ToString(),
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry((float)Feb)
                {
                    Label = "February",
                    ValueLabel = Feb.ToString(),
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry((float)Mar)
                {
                    Label = "March",
                    ValueLabel = Mar.ToString(),
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry((float)Apr)
                {
                    Label = "April",
                    ValueLabel = Apr.ToString(),
                    Color = SKColor.Parse("#c5002b")
                },
                new Microcharts.Entry((float)May)
                {
                    Label = "May",
                    ValueLabel = May.ToString(),
                    Color = SKColor.Parse("#26004c")
                },
                new Microcharts.Entry((float)Jun)
                {
                    Label = "June",
                    ValueLabel = Jun.ToString(),
                    Color = SKColor.Parse("#6f2de9")
                },
                new Microcharts.Entry((float)Jul)
                {
                    Label = "July",
                    ValueLabel = Jul.ToString(),
                    Color = SKColor.Parse("#c1c5e7")
                },
                new Microcharts.Entry((float)Aug)
                {
                    Label = "August",
                    ValueLabel = Aug.ToString(),
                    Color = SKColor.Parse("#f5805d")
                },
                new Microcharts.Entry((float)Sep)
                {
                    Label = "September",
                    ValueLabel = Sep.ToString(),
                    Color = SKColor.Parse("#876880")
                },
                new Microcharts.Entry((float)Oct)
                {
                    Label = "October",
                    ValueLabel = Oct.ToString(),
                    Color = SKColor.Parse("#eedd9d")
                },
                new Microcharts.Entry((float)Nov)
                {
                    Label = "November",
                    ValueLabel = Nov.ToString(),
                    Color = SKColor.Parse("#37030a")
                },
                new Microcharts.Entry((float)Dec)
                {
                    Label = "December",
                    ValueLabel = Dec.ToString(),
                    Color = SKColor.Parse("#fd9e8a")
                }
            };

            var line = new LineChart() { Entries = entries1 };
            this.lineView.Chart = line;

            IncomeCategory();
            var entries2 = new[]
            {
                new Microcharts.Entry((float)pay)
                {
                    Label = "Pay",
                    ValueLabel = pay.ToString(),
                    Color = SKColor.Parse("#12757d")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry((float)donation)
                {
                    Label = "Donation",
                    ValueLabel = donation.ToString(),
                    Color = SKColor.Parse("#e7f8ff")
                },
                new Microcharts.Entry((float) incomeOther)
                {
                    Label = "Other",
                    ValueLabel = incomeOther.ToString(),
                    Color = SKColor.Parse("#a33141")
                }
            };

            var donut = new DonutChart() { Entries = entries2};
            this.donutView.Chart = donut;




            MonthlySpendings();
            /* this line graph will now show the increase decrease
             * throughout the entire year, monthly */
            var entries4 = new[]
            {
                new Microcharts.Entry((float)Jan)
                {
                    Label = "January",
                    ValueLabel = Jan.ToString(),
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry((float)Feb)
                {
                    Label = "February",
                    ValueLabel = Feb.ToString(),
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry((float)Mar)
                {
                    Label = "March",
                    ValueLabel = Mar.ToString(),
                    Color = SKColor.Parse("#0084b4")
                },
                new Microcharts.Entry((float)Apr)
                {
                    Label = "April",
                    ValueLabel = Apr.ToString(),
                    Color = SKColor.Parse("#c5002b")
                },
                new Microcharts.Entry((float)May)
                {
                    Label = "May",
                    ValueLabel = May.ToString(),
                    Color = SKColor.Parse("#26004c")
                },
                new Microcharts.Entry((float)Jun)
                {
                    Label = "June",
                    ValueLabel = Jun.ToString(),
                    Color = SKColor.Parse("#6f2de9")
                },
                new Microcharts.Entry((float)Jul)
                {
                    Label = "July",
                    ValueLabel = Jul.ToString(),
                    Color = SKColor.Parse("#c1c5e7")
                },
                new Microcharts.Entry((float)Aug)
                {
                    Label = "August",
                    ValueLabel = Aug.ToString(),
                    Color = SKColor.Parse("#f5805d")
                },
                new Microcharts.Entry((float)Sep)
                {
                    Label = "September",
                    ValueLabel = Sep.ToString(),
                    Color = SKColor.Parse("#876880")
                },
                new Microcharts.Entry((float)Oct)
                {
                    Label = "October",
                    ValueLabel = Oct.ToString(),
                    Color = SKColor.Parse("#eedd9d")
                },
                new Microcharts.Entry((float)Nov)
                {
                    Label = "November",
                    ValueLabel = Nov.ToString(),
                    Color = SKColor.Parse("#37030a")
                },
                new Microcharts.Entry((float)Dec)
                {
                    Label = "December",
                    ValueLabel = Dec.ToString(),
                    Color = SKColor.Parse("#fd9e8a")
                }
            };

            var point = new PointChart() { Entries = entries4 };
            this.pointView.Chart = point;

            ExpenseCategory();
            var entries3 = new[]
            {
                new Microcharts.Entry((float)repair)
                {
                    Label = "Repairs",
                    ValueLabel = repair.ToString(),
                    Color = SKColor.Parse("#f5805d")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry((float)investment)
                {
                    Label = "Investment",
                    ValueLabel = investment.ToString(),
                    Color = SKColor.Parse("#d8fce5")
                },
                new Microcharts.Entry((float) expenseOther)
                {
                    Label = "Other",
                    ValueLabel = expenseOther.ToString(),
                    Color = SKColor.Parse("#520ff8")
                }
            };
            var gauge = new RadialGaugeChart() { Entries = entries3 };
            this.gaugeView.Chart = gauge;

            var radar = new RadarChart() { Entries = entries };
            this.radarView.Chart = radar;

            Income = 19000;
            Expense = 1200;
            Profit_Loss = Income - Expense;
            Projection = Profit_Loss / Income * 100;

        }

        private void MonthlySpendings()
        {
            Jan = 0;
            Feb = 0;
            Mar = 0;
            Apr = 0;
            May = 0;
            Jun = 0;
            Jul = 0;
            Aug = 0;
            Sep = 0;
            Oct = 0;
            Nov = 0;
            Dec = 0;
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("January"))
                {
                    Jan += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("February"))
                {
                    Feb += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("March"))
                {
                    Mar += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("April"))
                {
                    Apr += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("May"))
                {
                    May += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("June"))
                {
                    Jun += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("July"))
                {
                    Jul += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("August"))
                {
                    Aug += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("September"))
                {
                    Sep += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("October"))
                {
                    Oct += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("November"))
                {
                    Nov += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Month.Equals("December"))
                {
                    Dec += expense.Amount;
                }
            }
        }

        private void ExpenseCategory()
        {
            foreach (var expense in Expenses)
            {
                if (expense.Category.Equals("REPAIR"))
                {
                    repair += expense.Amount;
                }
            }
            foreach (var expense in Expenses)
            {
                if (expense.Category.Equals("INVESTMENT"))
                {
                    investment += expense.Amount;
                }
            }

            foreach (var expense in Expenses)
            {
                if (expense.Category.Equals("OTHER"))
                {
                    expenseOther += expense.Amount;
                }
            }
        }

        private void IncomeCategory()
        {
            foreach (var income in Incomes)
            {
                if (income.Category.Equals("Income"))
                {
                    pay += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Category.Equals("Donation"))
                {
                    donation += income.Amount;
                }
            }

            foreach (var income in Incomes)
            {
                if (income.Category.Equals("Other"))
                {
                    incomeOther += income.Amount;
                }
            }
        }

        private void MonthlyEarnings()
        {
            foreach (var income in Incomes)
            {
                if(income.Month.Equals("January"))
                {
                    Jan += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("February"))
                {
                    Feb += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("March"))
                {
                    Mar += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("April"))
                {
                    Apr += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("May"))
                {
                    May += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("June"))
                {
                    Jun += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("July"))
                {
                    Jul += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("August"))
                {
                    Aug += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("September"))
                {
                    Sep += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("October"))
                {
                    Oct += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("November"))
                {
                    Nov += income.Amount;
                }
            }
            foreach (var income in Incomes)
            {
                if (income.Month.Equals("December"))
                {
                    Dec += income.Amount;
                }
            }
        }

        private void CreateExpenses()
        {
            Expenses = new ObservableCollection<Expense>()
            {
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "REPAIR SERVICE", Amount = 200.25, Category = "REPAIR", Notes = "Repaired machinery at Repair INC.", Date = "10-15-2019", Month = "October" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "NEW INVENTORY", Amount = 1200.25, Category = "INVESTMENT", Notes = "Bought new machinery from Machinery INC.", Date = "06-03-2019", Month = "June" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "REPAIR SERVICE", Amount = 200.25, Category = "OTHER", Notes = "Repaired machinery at Repair INC.", Date = "09-15-2019", Month = "September" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "NEW INVENTORY", Amount = 1200.25, Category = "INVESTMENT", Notes = "Bought new machinery from Machinery INC.", Date = "02-13-2019", Month = "February" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "REPAIR SERVICE", Amount = 200.25, Category = "REPAIR", Notes = "Repaired machinery at Repair INC.", Date = "08-15-2019", Month = "August" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "NEW INVENTORY", Amount = 1200.25, Category = "INVESTMENT", Notes = "Bought new machinery from Machinery INC.", Date = "04-13-2019", Month = "April" }
            };
        }

        private void CreateIncomes()
        {
            Incomes = new ObservableCollection<Income>()
            {
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of January 15th", Date = "01-15-2019", Month = "January" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of October 7th", Date = "10-07-2019", Month = "October" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 2000.23, Category = "Other", Notes = "Week of February 1st", Date = "02-01-2019", Month = "February" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of September 15th", Date = "09-15-2019", Month = "September" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of April 7th", Date = "04-07-2019", Month = "April" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 2000.23, Category = "Other", Notes = "Week of September 1st", Date = "09-01-2019", Month = "September" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of August 15th", Date = "08-15-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of March 7th", Date = "03-07-2019", Month = "March" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 2000.23, Category = "Income", Notes = "Week of August 1st", Date = "08-01-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of July 15th", Date = "07-15-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of June 7th", Date = "06-07-2019", Month = "June" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 2000.23, Category = "Income", Notes = "Week of July 1st", Date = "07-01-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 500.00, Category = "Donation", Notes = "Thanksgiving Donation", Date = "11-28-2019", Month = "November" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 135.00, Category = "Donation", Notes = "Kind Donation", Date = "08-01-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 775.00, Category = "Donation", Notes = "Need TAX Deduction Donation", Date = "07-15-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 300.00, Category = "Donation", Notes = "Family Gift", Date = "07-07-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 100.00, Category = "Donation", Notes = "Donated", Date = "12-01-2019", Month = "December" },
            };
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
