using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iAudit.Models;

namespace iAudit.Services
{
    public class MockDataStore : IDataStore<Item>, IDataStore<Year>, IDataStore<Income>, IDataStore<Expense>
    {
        readonly List<Item> items;
        readonly List<Year> years;
        readonly List<Income> incomes;
        readonly List<Expense> expenses;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            years = new List<Year>()
            {
                new Year { Id = Guid.NewGuid().ToString(), Text = "2019", Description="Current Tax Year" },
                new Year { Id = Guid.NewGuid().ToString(), Text = "2020", Description="No notes" },
                new Year { Id = Guid.NewGuid().ToString(), Text = "2021", Description="No notes" },
                new Year { Id = Guid.NewGuid().ToString(), Text = "2022", Description="No notes" },
                new Year { Id = Guid.NewGuid().ToString(), Text = "2023", Description="No notes" }
            };

            incomes = new List<Income>()
            {
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of January 15th", Date = "01-15-2019", Month = "January" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of October 7th", Date = "10-07-2019", Month = "October" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 2000.23, Category = "Other", Notes = "Week of February 1st", Date = "02-01-2019", Month = "February" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of September 15th", Date = "09-15-2019", Month = "September" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of April 7th", Date = "04-07-2019", Month = "April" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 2000.23, Category = "Other", Notes = "Week of September 1st", Date = "09-01-2019", Month = "September" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of August 15th", Date = "08-15-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of March 7th", Date = "03-07-2019", Month = "March" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 2000.23, Category = "Income", Notes = "Week of August 1st", Date = "08-01-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of July 15th", Date = "07-15-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of June 7th", Date = "06-07-2019", Month = "June" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 2000.23, Category = "Income", Notes = "Week of July 1st", Date = "07-01-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 500.00, Category = "Donation", Notes = "Thanksgiving Donation", Date = "11-28-2019", Month = "November" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 135.00, Category = "Donation", Notes = "Kind Donation", Date = "08-01-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 775.00, Category = "Donation", Notes = "Need TAX Deduction Donation", Date = "07-15-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 300.00, Category = "Donation", Notes = "Family Gift", Date = "07-07-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), IncomeName = "WEEK PAY", Amount = 100.00, Category = "Donation", Notes = "Donated", Date = "12-01-2019", Month = "December" }
            };

            expenses = new List<Expense>()
            {
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "REPAIR SERVICE", Amount = 200.25, Category = "REPAIR", Notes = "Repaired machinery at Repair INC.", Date = "10-15-2019", Month = "October" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "NEW INVENTORY", Amount = 1200.25, Category = "INVESTMENT", Notes = "Bought new machinery from Machinery INC.", Date = "06-03-2019", Month = "June" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "REPAIR SERVICE", Amount = 200.25, Category = "OTHER", Notes = "Repaired machinery at Repair INC.", Date = "09-15-2019", Month = "September" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "NEW INVENTORY", Amount = 1200.25, Category = "INVESTMENT", Notes = "Bought new machinery from Machinery INC.", Date = "02-13-2019", Month = "February" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "REPAIR SERVICE", Amount = 200.25, Category = "REPAIR", Notes = "Repaired machinery at Repair INC.", Date = "08-15-2019", Month = "August" },
                new Expense { Id = Guid.NewGuid().ToString(), ExpenseName = "NEW INVENTORY", Amount = 1200.25, Category = "INVESTMENT", Notes = "Bought new machinery from Machinery INC.", Date = "04-13-2019", Month = "April" }
            };
        }


        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> AddYearAsync(Year year)
        {
            years.Add(year);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateYearAsync(Year year)
        {
            var oldItem = years.Where((Year arg) => arg.Id == year.Id).FirstOrDefault();
            years.Remove(oldItem);
            years.Add(year);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteYearAsync(string id)
        {
            var oldItem = years.Where((Year arg) => arg.Id == id).FirstOrDefault();
            years.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Year> GetYearsAync(string id)
        {
            return await Task.FromResult(years.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Year>> GetYearAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(years);
        }

        public async Task<bool> AddIncomeAsync(Income income)
        {
            incomes.Add(income);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateIncomeAsync(Income income)
        {
            var oldItem = incomes.Where((Income arg) => arg.Id == income.Id).FirstOrDefault();
            incomes.Remove(oldItem);
            incomes.Add(income);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteIncomeAsync(string id)
        {
            var oldItem = incomes.Where((Income arg) => arg.Id == id).FirstOrDefault();
            incomes.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Income> GetIncomeAsync(string id)
        {
            return await Task.FromResult(incomes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Income>> GetIncomeAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(incomes);
        }

        public async Task<bool> AddExpenseAsync(Expense expense)
        {
            expenses.Add(expense);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateExpenseAsync(Expense expense)
        {
            var oldItem = expenses.Where((Expense arg) => arg.Id == expense.Id).FirstOrDefault();
            expenses.Remove(oldItem);
            expenses.Add(expense);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteExpenseAsync(string id)
        {
            var oldItem = expenses.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            expenses.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Expense> GetExpenseAsync(string id)
        {
            return await Task.FromResult(expenses.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Expense>> GetExpenseAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(expenses);
        }

        public Task<bool> AddItemAsync(Year item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Year item)
        {
            throw new NotImplementedException();
        }

        Task<Year> IDataStore<Year>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Year>> IDataStore<Year>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        public Task<Year> GetYearAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddYearAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateYearAsync(Item item)
        {
            throw new NotImplementedException();
        }

        Task<Item> IDataStore<Item>.GetYearAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(Income item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Income item)
        {
            throw new NotImplementedException();
        }

        Task<Income> IDataStore<Income>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Income>> IDataStore<Income>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        Task<Income> IDataStore<Income>.GetYearAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Year> IDataStore<Year>.GetIncomeAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Item> IDataStore<Item>.GetIncomeAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(Expense item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Expense item)
        {
            throw new NotImplementedException();
        }

        Task<Expense> IDataStore<Expense>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Expense>> IDataStore<Expense>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        Task<Expense> IDataStore<Expense>.GetYearAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Expense> IDataStore<Expense>.GetIncomeAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Item> IDataStore<Item>.GetExpenseAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Year> IDataStore<Year>.GetExpenseAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Income> IDataStore<Income>.GetExpenseAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}