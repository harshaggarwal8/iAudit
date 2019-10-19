using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iAudit.Models;

namespace iAudit.Services
{
    public class MockDataStore : IDataStore<Item>, IDataStore<Year>
    {
        readonly List<Item> items;
        readonly List<Year> years;

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
    }
}