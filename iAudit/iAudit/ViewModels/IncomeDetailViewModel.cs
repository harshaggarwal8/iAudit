using System;
using iAudit.Models;

namespace iAudit.ViewModels
{
    public class IncomeDetailViewModel : BaseViewModel
    {
        public Income Income { get; set; }
        // View Model used to bind this view model to whatever income is being attached
        public IncomeDetailViewModel(Income income = null)
        {
            Title = income?.IncomeName;
            Income = income;
        }
    }
}

