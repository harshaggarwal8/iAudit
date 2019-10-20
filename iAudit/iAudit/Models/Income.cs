﻿using System;

using Xamarin.Forms;

namespace iAudit.Models
{
    public class Income 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public double Amount { get; set; }
        public Year Year { get; set; }
        public string Month { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        // public image Picture { get; set; }
    }
}
