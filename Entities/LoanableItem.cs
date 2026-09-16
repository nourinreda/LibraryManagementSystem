using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Entity
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Book), "book")]
    [JsonDerivedType(typeof(Magazine), "magazine")]

    internal abstract class LoanableItem : LibraryItem, ILoanable
    {
        
      
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        protected LoanableItem()
        {
            
        }
        protected LoanableItem(int id, string title, string author, int yearPublished, int totalCopies)
            : base(id, title, author, yearPublished)
        {
            TotalCopies = totalCopies;
            AvailableCopies = totalCopies;
        }

        public bool IsAvailable()
        {
            return AvailableCopies > 0;
        }

        public void Borrow()
        {
            if (IsAvailable())
                AvailableCopies--;
        }

        public void ReturnItem()
        {
            if (AvailableCopies < TotalCopies)
                AvailableCopies++;
        }
     
    }
}
