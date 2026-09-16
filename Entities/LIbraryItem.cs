using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Entity
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Book), "book")]
    [JsonDerivedType(typeof(Magazine), "magazine")]
    [JsonDerivedType(typeof(ReferenceBook), "referenceBook")]
    
    internal abstract class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        protected LibraryItem()
        {
            
        }

        protected LibraryItem(int id, string title, string author, int yearPublished)
        {
            Id = id;
            Title = title;
            Author = author;
            YearPublished = yearPublished;
        }

      
        public abstract string GetInfo();
    }
}
