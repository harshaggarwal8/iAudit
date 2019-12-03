using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iAudit.Models;

namespace iAudit.Services
{
    public interface IDataStore<T>
    {
        // Holds all calls to DataStore needed in order to retrieve, update, and add data

            //These refer to items
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

            //These refer to years
        Task<bool> AddYearAsync(Year year);
        Task<bool> UpdateYearAsync(Year year);
        Task<bool> DeleteYearAsync(string id);
        Task<T> GetYearAsync(string id);
        Task<IEnumerable<Year>> GetYearAsync(bool forceRefresh = false);

            //These refer to incomes
        Task<bool> AddIncomeAsync(Income income);
        Task<bool> UpdateIncomeAsync(Income income);
        Task<bool> DeleteIncomeAsync(string id);
        Task<T> GetIncomeAsync(string id);
        Task<IEnumerable<Income>> GetIncomeAsync(bool forceRefresh = false);


            //These refer to expenses
        Task<bool> AddExpenseAsync(Expense expense);
        Task<bool> UpdateExpenseAsync(Expense expense);
        Task<bool> DeleteExpenseAsync(string id);
        Task<T> GetExpenseAsync(string id);
        Task<IEnumerable<Expense>> GetExpenseAsync(bool forceRefresh = false);
    }
}
