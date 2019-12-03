using System;
using iAudit.Models;

namespace iAudit.ViewModels
{
    public class ExpenseDetailViewModel : BaseViewModel
    {
        // View Model used to bind this view model to whatever expense is being attaches
        public Expense Expense { get; set; }
        public ExpenseDetailViewModel(Expense expense = null)
        {
            Title = expense?.ExpenseName;
            Expense = expense;
        }
    }
}
