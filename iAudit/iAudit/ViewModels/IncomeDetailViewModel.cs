using System;
using iAudit.Models;

namespace iAudit.ViewModels
{
    public class IncomeDetailViewModel : BaseViewModel
    {
        public Income Income { get; set; }
        public IncomeDetailViewModel(Income income = null)
        {
            Title = income?.IncomeName;
            Income = income;
        }
    }
}

