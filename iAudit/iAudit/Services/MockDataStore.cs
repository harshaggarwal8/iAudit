using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iAudit.Models;

namespace iAudit.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "2019", Description="Current tax year" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2020", Description="No notes" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2021", Description="No notes" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2022", Description="No notes" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2023", Description="No notes" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "2024", Description="No notes" }
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
    }
}