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
            var chart = new LineChart() { Entries = entries };
            /*
            var chart1 = new BarChart() { Entries = entries };
            var chart2 = new PointChart() { Entries = entries };
            var chart3 = new LineChart() { Entries = entries };
            var chart4 = new DonutChart() { Entries = entries };
            var chart5 = new RadialGaugeChart() { Entries = entries };
            var chart6 = new RadarChart() { Entries = entries };
            var chart7 = new DonutChart() { Entries = entries };
            */
            this.chartView.Chart = chart;
        }
        public ViewReportPage(Year year)
        {
            InitializeComponent();
        }
    }
}
