using LibraryManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Interfaces
{
    internal interface ILoanable
    {
        bool IsAvailable();
        void Borrow();
        void ReturnItem();
    }
}
