using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entity
{
   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    namespace LibraryManagementSystem.Entity
    {
        internal class Library
        {
            public List<LibraryItem> Items { get; set; }
            public List<Member> Members { get; set; }
            public List<Loan> Loans { get; set; }

            public Library()
            {
                Items = new List<LibraryItem>();
                Members = new List<Member>();
                Loans = new List<Loan>();
            }

            public string BorrowItem(LoanableItem item, Member member)
            {
                if (!item.IsAvailable())
                    return $"{item.Title} is not available.";

                if (!member.CanBorrow())
                    return "The member has reached the maximum borrowing limit.";

                Loan loan = new Loan(item, member);
                Loans.Add(loan);

                item.Borrow();
                member.Borrow();

                return $"{item.Title} borrowed successfully!";
            }

            public string ReturnItem(LoanableItem item, Member member, int loanId)
            {
                Loan? loan = Loans.FirstOrDefault(l =>
                    l.LoanId == loanId &&
                    l.Item == item &&
                    l.Borrower == member);

                if (loan == null)
                    return "Loan not found.";

                if (loan.ReturnDate != null)
                    return "This loan has already been returned.";

                decimal fine = loan.CalcFine();
                if (fine > 0)
                {
                    if (!loan.PayFine())
                        return $"Please pay the outstanding fine of {fine} before returning this item.";
                }

                loan.ReturnDate = DateTime.Now;

                item.ReturnItem();
                member.ReturnItem();

                return $"{item.Title} returned successfully.";
            }

            public string AddItem(LoanableItem item)
            {
                var existingItem = Items
                    .OfType<LoanableItem>()
                    .FirstOrDefault(x =>
                        x.Id == item.Id &&
                        x.GetType() == item.GetType());

                if (existingItem != null)
                {
                    existingItem.TotalCopies += item.TotalCopies;
                    existingItem.AvailableCopies += item.TotalCopies;

                    return $"New copies of {existingItem.Title} added successfully.";
                }

                Items.Add(item);

                return $"{item.Title} added successfully.";
            }
            public string RemoveItem(LoanableItem item)
            {
                if (!Items.Contains(item))
                    return "Item not found.";

                if (item.AvailableCopies <= 0)
                    return "Cannot remove item. All copies are currently borrowed.";

                item.TotalCopies--;
                item.AvailableCopies--;

                if (item.TotalCopies == 0)
                    Items.Remove(item);

                return $"{item.Title} removed successfully.";
            }

            public string AddMember(Member member)
            {
                if (Members.Any(m => m.Id == member.Id))
                    return "A member with this Id already exists.";

                Members.Add(member);
                return $"{member.Name} added successfully.";
            }

            public LibraryItem? SearchByTitle(string title)
            {
                return Items.FirstOrDefault(i =>
                    i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            }

            public List<LibraryItem> SearchByAuthor(string author)
            {
                return Items
                    .Where(i => i.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            public List<LoanableItem> GetCurrentlyBorrowedItems()
            {
                return Loans
                    .Where(l => l.ReturnDate == null)
                    .Select(l => l.Item)
                    .ToList();
            }

            public List<Loan> GetOverdueLoans()
            {
                return Loans.Where(l => l.IsOverdue()).ToList();
            }
        }
    }
    
}
