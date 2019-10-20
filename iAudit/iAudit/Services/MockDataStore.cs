using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iAudit.Models;

namespace iAudit.Services
{
    public class MockDataStore : IDataStore<Item>, IDataStore<Year>, IDataStore<Income>
    {
        readonly List<Item> items;
        readonly List<Year> years;
        readonly List<Income> incomes;

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
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of October 15th", Date = "10-15-2019", Month = "October" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of October 7th", Date = "10-07-2019", Month = "October" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 2000.23, Category = "Income", Notes = "Week of October 1st", Date = "10-01-2019", Month = "October" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of September 15th", Date = "09-15-2019", Month = "September" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of September 7th", Date = "09-07-2019", Month = "September" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 2000.23, Category = "Income", Notes = "Week of September 1st", Date = "09-01-2019", Month = "September" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of August 15th", Date = "08-15-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of August 7th", Date = "08-07-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 2000.23, Category = "Income", Notes = "Week of August 1st", Date = "08-01-2019", Month = "August" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 1000.25, Category = "Income", Notes = "Week of July 15th", Date = "07-15-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 995.25, Category = "Income", Notes = "Week of July 7th", Date = "07-07-2019", Month = "July" },
                new Income { Id = Guid.NewGuid().ToString(), Title = "WEEK PAY", Amount = 2000.23, Category = "Income", Notes = "Week of July 1st", Date = "07-01-2019", Month = "July" },
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
    }
}