using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entity
{
    internal class Loan
    {
        static int loanCount = 0;
        public  int LoanId { get; set; } 
        public LoanableItem Item { get; set; }
        public Member Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        const decimal FinePerDay = 5;
        public bool IsFinePaid { get; private set; }
        public Loan()
        {
            
        }
        public Loan( LoanableItem item, Member borrower, int loanDurationDays = 10)
        {
            LoanId=++loanCount;
            Item = item;
            Borrower = borrower;
            BorrowDate = DateTime.Now;
            DueDate = BorrowDate.AddDays(loanDurationDays);
            ReturnDate = null;
            IsFinePaid = false;
        }
        public bool IsOverdue()
        {
            return ReturnDate == null && DateTime.Now > DueDate;
        }
        public decimal CalcFine()
        {
            DateTime compareDate = ReturnDate ?? DateTime.Now;

            if (compareDate <= DueDate)
                return 0;

            int lateDays = (compareDate - DueDate).Days;
            return lateDays * FinePerDay;
        }
        public bool PayFine()
        {
            decimal Fine = CalcFine();
            if(Fine == 0||IsFinePaid) return false;
            IsFinePaid=true;
            return true;
        }

    }
}
