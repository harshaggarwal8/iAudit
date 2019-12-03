using System;
using System.Collections.Generic;
using System.Text;
using iAudit.Views;
using Xamarin.Forms;

namespace iAudit.Models
{
    public class Expense 
    {
        //expense view model, used when instantiating new models
        public string Id { get; set; }
        public string ExpenseName { get; set; }
        public string Notes { get; set; }
        public double Amount { get; set; }
      //  public Year Year { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public int Day { get; set; }
        public string Category { get; set; }
        //public string Date { get; set; }
        // public image Picture { get; set; }
       /* final FirebaseDatabase database = FirebaseDatabase.getInstance();
        DatabaseReference ref = database.getReference("server/saving-data/fireblog/posts");

        // Attach a listener to read the data at our posts reference
        ref.addValueEventListener(new ValueEventListener()
        {
            public override void onDataChange(DataSnapshot dataSnapshot)
            {
                Expense expense = dataSnapshot.getValue(Expense.class);*/
    }
}

