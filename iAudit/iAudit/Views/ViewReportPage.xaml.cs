using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using System.Linq;

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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var entries = new[]
            {
                new Microcharts.Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
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
                    ValueLabel = "200",
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(4020)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
                    Color = SKColor.Parse("#0084b4")
                }
            };

            var line = new LineChart() { Entries = entries1 };

            this.lineView.Chart = line;

            var entries2 = new[]
            {
                new Microcharts.Entry(1000)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#104950")
                    //FillColor = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(4020)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#F7A4B9")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
                    Color = SKColor.Parse("#0084b4")
                }
            };

            var donut = new DonutChart() { Entries = entries2 };

            this.donutView.Chart = donut;

            Income = 19000;
            Expense = 1200;
            Profit_Loss = Income - Expense;
            Projection = Profit_Loss / Income * 100;
            
        }
        public ViewReportPage(Year year)
        {
            InitializeComponent();
        }
    }
}
