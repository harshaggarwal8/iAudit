using System;

using Xamarin.Forms;

namespace iAudit.Models
{
    public class Expense 
    {
        //expense view model, used when instantiating new models
        public string Id { get; set; }
        public string ExpenseName { get; set; }
        public string Notes { get; set; }
        public double Amount { get; set; }
        public Year Year { get; set; }
        public string Month { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        // public image Picture { get; set; }

    }
}

