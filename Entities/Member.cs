using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entity
{
    internal class Member
    {
        
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            const int MaxBorrowLimit = 3;
            public int CurrentBorrowedCount { get; set; }
      

        public Member(int id, string name, string email)
            {
                Id = id;
                Name = name;
                Email = email;
           
               
            }

        public bool CanBorrow()
        {
            return CurrentBorrowedCount < MaxBorrowLimit;
        }
        public bool Borrow()
        {
            if (CurrentBorrowedCount>=MaxBorrowLimit)
                return false;

            CurrentBorrowedCount++;
            return true;
        }

        public void ReturnItem()
        {
            if(CurrentBorrowedCount>0)
            CurrentBorrowedCount--;
        }
        public string GetInfo()
        {
            return$"Id:{Id},Name:{Name},Email:{Email}";
        }
    }
}
