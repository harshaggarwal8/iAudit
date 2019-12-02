using System;
using iAudit.Models;

namespace iAudit.ViewModels
{
    public class ExpenseDetailViewModel : BaseViewModel
    {
        public Expense Expense { get; set; }
        public ExpenseDetailViewModel(Expense expense = null)
        {
            Title = expense?.ExpenseName;
            Expense = expense;
        }
    }
}
