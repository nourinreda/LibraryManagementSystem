using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entity
{
    internal class Magazine : LoanableItem
    {
        public int IssueNumber { get; set; }
      

        public Magazine(int id, string title, string author, int yearPublished,
                         int issueNumber, int totalCopies)
            : base(id, title, author, yearPublished,totalCopies)
        {
            IssueNumber = issueNumber;
      
        }

        

       

        public override string GetInfo()
        {
            return $"Magazine: {Title} - Issue #{IssueNumber} ({YearPublished}) - Available: {AvailableCopies}/{TotalCopies}";
        }

        
    }
}
