using System;
using System.Collections.Generic;
using System.Text;
using iAudit.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

//This file serves as the connection to the Firebase

namespace iAuditTest.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://iaudit-e62d6.firebaseio.com");

        public async Task<List<Expense>> GetAllExpense()
        {

            return (await firebase
              .Child("Expense")
              .OnceAsync<Expense>()).Select(expense => new Expense
              {
                      //Id = expense.Object.Id,
                      ExpenseName = expense.Object.IncomeName,
                      Notes = expense.Object.Notes,
                      Amount = expense.Object.Amount,
                      Year = expense.Object.Year,
                      Month = expense.Object.Month,
                      Day = expense.Object.Day,
                      Category = expense.Object.Category,
                      //Date = expense.Object.Date
              }).ToList();
        }

        public async Task AddExpense( string expenseName, string notes, double amount, int year, string month, int day, string category)
        {

            await firebase
              .Child("Expense")
              .PostAsync(new Expense() {ExpenseName = expenseName, Notes = notes, Amount = amount, Year = year, Month = month, Day = day, Category = category });
        }

        public async Task<Expense> GetExpense(string expenseName)
        {
            var allExpenses = await GetAllExpenses();
            await firebase
              .Child("Expense")
              .OnceAsync<Expense>();
            return allExpenses.Where(a => a.ExpenseName == expenseName).FirstOrDefault();
        }

        public async Task UpdateExpense(string expenseName, string notes, double amount, int year, string month, int day, string category)
        {
            var toUpdateExpense = (await firebase
              .Child("Expenses")
              .OnceAsync<Expense>()).Where(a => a.Object.ExpenseName == expenseName).FirstOrDefault();

            await firebase
              .Child("Expenses")
              .Child(toUpdateExpense.Key)
              .PutAsync(new Expense() {ExpenseName = expenseName, Notes = notes, Amount = amount, Year = year, Month = month, Day = day, Category = category });
        }

        public async Task DeleteExpense(string expenseName)
        {
            var toDeleteExpense = (await firebase
              .Child("Expenses")
              .OnceAsync<Expense>()).Where(a => a.Object.ExpenseName == expenseName).FirstOrDefault();
            await firebase.Child("Expenses").Child(toDeleteExpense.Key).DeleteAsync();

//For Income
            public async Task<List<Income>> GetAllIncome(){
                return (await firebase
                  .Child("Income")
                  .OnceAsync<Income>()).Select(income => new Income
                  {
                     // Id = income.Object.Id,
                      IncomeName = income.Object.IncomeName,
                      Notes = income.Object.Notes,
                      Amount = income.Object.Amount,
                      Year = income.Object.Year,
                      Month = income.Object.Month,
                      Day = income.Object.Day,
                      Category = income.Object.Category
                  }).ToList();
            }

            public async Task AddIncome(string incomeName, string notes, double amount, int year, string month, int day, string category)
            {

                await firebase
                  .Child("Income")
                  .PostAsync(new Income() {IncomeName = incomeName, Notes = notes, Amount = amount, Year = year, Month = month, Day = day, Category = category });
            }

            public async Task<Income> GetIncome(string incomeName)
            {
                var allIncomes = await GetAllIncomes();
                await firebase
                  .Child("Income")
                  .OnceAsync<Income>();
                return allIncomes.Where(a => a.IncomeName == incomeName).FirstOrDefault();
            }

            public async Task UpdateIncome(string incomeName, string notes, double amount, int year, string month, string category, string date)
            {
                var toUpdateIncome = (await firebase
                  .Child("Income")
                  .OnceAsync<Income>()).Where(a => a.Object.IncomeName == incomeName).FirstOrDefault();

                await firebase
                  .Child("Income")
                  .Child(toUpdateIncome.Key)
                  .PutAsync(new Income() {IncomeName = incomeName, Notes = notes, Amount = amount, Year = year, Month = month, Day = day, Category = category});
            }

            public async Task DeleteIncome(string incomeName)
            {
                var toDeleteIncome = (await firebase
                  .Child("Income")
                  .OnceAsync<Income>()).Where(a => a.Object.IncomeName == incomeName).FirstOrDefault();
                await firebase.Child("Income").Child(toDeleteIncome.Key).DeleteAsync();
                
//For Item
                return (await firebase
                  .Child("Items")
                  .OnceAsync<Item>()).Select(item => new Item
                  {
                      ItemId = item.Object.ItemId,
                      Text = item.Object.Text,
                      Description = item.Object.Description,
                  }).ToList();
            }

            public async Task AddExpense(string itemId, string text, string description)
            {

                await firebase
                  .Child("Items")
                  .PostAsync(new Item() { ItemId = itemId, Text = text, Description = description});
            }

            public async Task<Item> GetItem(string itemId)
            {
                var allItems = await GetAllItems();
                await firebase
                  .Child("Items")
                  .OnceAsync<Item>();
                return allItems.Where(a => a.ItemId == itemId).FirstOrDefault();
            }

            public async Task UpdateItem(string itemId, string text, string description, int amount)
            {
                var toUpdateItem = (await firebase
                  .Child("Items")
                  .OnceAsync<Item>()).Where(a => a.Object.ItemId == itemId).FirstOrDefault();

                await firebase
                  .Child("Items")
                  .Child(toUpdateItem.Key)
                  .PutAsync(new Item() { ItemId = itemId, Text = text, Description = description, Amount = amount });
            }

            public async Task DeleteItem(string itemId)
            {
                var toDeleteItem = (await firebase
                  .Child("Items")
                  .OnceAsync<Item>()).Where(a => a.Object.ItemId == itemId).FirstOrDefault();
                await firebase.Child("Items").Child(toDeleteItem.Key).DeleteAsync();


//For Year

                return (await firebase
                  .Child("Year")
                  .OnceAsync<Year>()).Select(year => new Year
                  {
                      Id = year.Object.Id,
                      Text = year.Object.Text,
                      Description = year.Object.Description
                  }).ToList();
            }

            public async Task AddYear(string id, string text, string description)
            {

                await firebase
                  .Child("Year")
                  .PostAsync(new Year() { Id = id, Text = text, Description = description});
            }

            public async Task<Year> GetYear(string Id)
            {
                var allYear = await GetAllYear();
                await firebase
                  .Child("Year")
                  .OnceAsync<Year>();
                return allYear.Where(a => a.Id == id).FirstOrDefault();
            }

            public async Task UpdateYear(string id, string text, string description)
            {
                var toUpdateItem = (await firebase
                  .Child("Year")
                  .OnceAsync<Year>()).Where(a => a.Object.Id == id).FirstOrDefault();

                await firebase
                  .Child("Year")
                  .Child(toUpdateYear.Key)
                  .PutAsync(new Year() { Id = id, Text = text, Description = description});
            }

            public async Task DeleteYear(string id)
            {
                var toDeleteItem = (await firebase
                  .Child("Year")
                  .OnceAsync<Year>()).Where(a => a.Object.Id == id).FirstOrDefault();
                await firebase.Child("Year").Child(toDeleteYear.Key).DeleteAsync();

        }
    }