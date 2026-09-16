using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entity
{
    internal class ReferenceBook : LibraryItem
    {
        public string ShelfLocation { get; set; }

        public ReferenceBook(int id, string title, string author, int yearPublished, string shelfLocation)
            : base(id, title, author, yearPublished)
        {
            ShelfLocation = shelfLocation;
        }

        public override string GetInfo()
        {
            return $"Reference Book: {Title} by {Author} ({YearPublished}) - Shelf: {ShelfLocation} (In-library use only)";
        }
        
    }
}
