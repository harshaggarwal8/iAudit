using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using iAudit.Helper;
using iAudit.Models;
using iAudit.Views;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
//This file serves as the connection to the Firebase
namespace iAudit.Helper
{
    public class FirebaseHelper
    {
        //Connection to Firebase Client
        FirebaseClient firebase = new FirebaseClient("https://iaudit-e62d6.firebaseio.com");
        //INFO FOR USERS
            //Add a new user from registration page
        public async Task NewUser(string email, string password, string firstName, string lastName)
        {
            await firebase
                .Child("User")
                .PostAsync(new User() { FirstName = firstName, LastName = lastName, Email = email, Password = password });
        }
            //Get list of all users
        public async Task<List<User>> GetAllUser()
        {
            return (await firebase
              .Child("User")
              .OnceAsync<User>()).Select(user => new User
              {
                  FirstName = user.Object.FirstName,
                  LastName = user.Object.LastName,
                  Email = user.Object.Email,
                  Password = user.Object.Password,
              }).ToList();
        }
            //Get user's info
        public async Task<User> GetUser(string email, string password)
        {
            var allUsers = await GetAllUser();
            await firebase
              .Child("User")
              .OnceAsync<User>();
            return allUsers.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
        }
        //EXPENSES
            //LIST OF ALL EXPENSES
        public async Task<List<Expense>> GetAllExpense()
        {
            return (await firebase
              .Child("Expense")
              .OnceAsync<Expense>()).Select(expense => new Expense
              {
                  //Id = expense.Object.Id,
                  ExpenseName = expense.Object.ExpenseName,
                  Notes = expense.Object.Notes,
                  Amount = expense.Object.Amount,
                  Year = expense.Object.Year,
                  Month = expense.Object.Month,
                  Day = expense.Object.Day,
                  Category = expense.Object.Category,
                  //Date = expense.Object.Date
              }).ToList();
        }
        //ADD A NEW EXPENSE TO THE DATABASE
        public async Task AddExpense(string expenseName, string notes, double amount, int year, string month, int day, string category)
        {

            await firebase
              .Child("Expense")
              .PostAsync(new Expense() { ExpenseName = expenseName, Notes = notes, Amount = amount, Year = year, Month = month, Day = day, Category = category });
        }
        //GET AN EXPENSE
        public async Task<Expense> GetExpense(string expenseName)
        {
            var allExpenses = await GetAllExpense();
            await firebase
              .Child("Expense")
              .OnceAsync<Expense>();
            return allExpenses.Where(a => a.ExpenseName == expenseName).FirstOrDefault();
        }
        //UPDATE AN EXPENSE
        public async Task UpdateExpense(string expenseName, string notes, double amount, int year, string month, int day, string category)
        {
            var toUpdateExpense = (await firebase
              .Child("Expenses")
              .OnceAsync<Expense>()).Where(a => a.Object.ExpenseName == expenseName).FirstOrDefault();

            await firebase
              .Child("Expenses")
              .Child(toUpdateExpense.Key)
              .PutAsync(new Expense() { ExpenseName = expenseName, Notes = notes, Amount = amount, Year = year, Month = month, Day = day, Category = category });
        }

        public async Task DeleteExpense(string expenseName)
        {
            var toDeleteExpense = (await firebase
              .Child("Expenses")
              .OnceAsync<Expense>()).Where(a => a.Object.ExpenseName == expenseName).FirstOrDefault();
            await firebase.Child("Expenses").Child(toDeleteExpense.Key).DeleteAsync();
        }
        public async Task<Expense> GetExpenseYear(int year)
        {
            var allExpenses = await GetAllExpense();
            await firebase
              .Child("Expense")
              .OnceAsync<Expense>();
            return allExpenses.Where(a => a.Year == year).FirstOrDefault();
        }

        //For Income
        public async Task<List<Income>> GetAllIncome()
        {
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
              .PostAsync(new Income() { IncomeName = incomeName, Notes = notes, Amount = amount, Year = year, Month = month, Day = day, Category = category });
        }

        public async Task<Income> GetIncome(string incomeName)
        {
            var allIncomes = await GetAllIncome();
            await firebase
              .Child("Income")
              .OnceAsync<Income>();
            return allIncomes.Where(a => a.IncomeName == incomeName).FirstOrDefault();
        }
        public async Task<Income> GetIncomeYear(int year)
        {
            var allIncomes = await GetAllIncome();
            await firebase
              .Child("Income")
              .OnceAsync<Income>();
            return allIncomes.Where(a => a.Year == year).FirstOrDefault();
        }

        public async Task UpdateIncome(string incomeName, string notes, double amount, int year, string month, string category, int day)
        {
            var toUpdateIncome = (await firebase
              .Child("Income")
              .OnceAsync<Income>()).Where(a => a.Object.IncomeName == incomeName).FirstOrDefault();

            await firebase
              .Child("Income")
              .Child(toUpdateIncome.Key)
              .PutAsync(new Income() { IncomeName = incomeName, Notes = notes, Amount = amount, Year = year, Month = month, Day = day, Category = category });
        }

        public async Task DeleteIncome(string incomeName)
        {
            var toDeleteIncome = (await firebase
              .Child("Income")
              .OnceAsync<Income>()).Where(a => a.Object.IncomeName == incomeName).FirstOrDefault();
            await firebase.Child("Income").Child(toDeleteIncome.Key).DeleteAsync();
        }
    }
}