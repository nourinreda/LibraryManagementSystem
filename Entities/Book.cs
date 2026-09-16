using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entity
{
    internal class Book: LoanableItem
    {
        public string ISBN { get; set; }
    
        public Book()
        {
            
        }
        public Book(string isbn,int id, string title, string author, int yearPublished,int totalCopies) :base(id, title, author, yearPublished,totalCopies)
        {
            ISBN=isbn;
            
        }

        public override string GetInfo()
        {
            return $"Book: {Title} by {Author} ({YearPublished}) - ISBN: {ISBN} - Available: {AvailableCopies}/{TotalCopies}";
        }
    }
}
