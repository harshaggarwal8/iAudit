﻿using System;
using System.Collections.Generic;
using iAudit.Models;
using Xamarin.Forms;

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

        public ViewReportPage(Year year)
        {
            InitializeComponent();
        }
    }
}
