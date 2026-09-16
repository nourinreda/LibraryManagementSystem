using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;
using LibraryManagementSystem.Entity.LibraryManagementSystem.Entity;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataStorage dataStorage = new DataStorage();

            Library library = dataStorage.Load();
            

            if (library.Items.Count == 0)
            {
              
                Book book1 = new Book("01", 1, "book1", "author1", 2020, 5);
                Book book2 = new Book("02", 2, "book2", "author2", 2021, 3);
                Book book3 = new Book("03", 3, "book3", "author3", 2022, 7);

              
                Magazine magazine1 = new Magazine(1, "magazine1", "author1", 2015, 1, 6);
                Magazine magazine2 = new Magazine(2, "magazine2", "author2", 2020, 2, 4);
                Magazine magazine3 = new Magazine(3, "magazine3", "author3", 2023, 3, 8);

               
                Member member1 = new Member(1, "member1", "member1@gmail.com");
                Member member2 = new Member(2, "member2", "member2@gmail.com");
                Member member3 = new Member(3, "member3", "member3@gmail.com");

              
                library.AddItem(book1);
                library.AddItem(book2);
                library.AddItem(book3);

                library.AddItem(magazine1);
                library.AddItem(magazine2);
                library.AddItem(magazine3);

                library.AddMember(member1);
                library.AddMember(member2);
                library.AddMember(member3);

                
                dataStorage.Save(library);
            }


            // Display Current Library


            Console.WriteLine("=== Library Items ===");

            foreach (var item in library.Items)
            {
                Console.WriteLine(item.GetInfo());
            }

            Console.WriteLine();

            Console.WriteLine("=== Library Members ===");

            foreach (var member1 in library.Members)
            {
                Console.WriteLine(member1.GetInfo());
            }

            Console.WriteLine();


            
            // Borrow Item
       

            var itemToBorrow = library.Items[0] as LoanableItem;
            var member = library.Members[0];

            Console.WriteLine("=== Borrow Item ===");

            string borrowResult = library.BorrowItem(itemToBorrow!, member);

            Console.WriteLine(borrowResult);

            Console.WriteLine();


           
            var loan = library.Loans.Last();

            Console.WriteLine("=== Loan Details ===");
            Console.WriteLine($"Loan ID: {loan.LoanId}");
            Console.WriteLine($"Item: {loan.Item.Title}");
            Console.WriteLine($"Borrower: {loan.Borrower.Name}");
            Console.WriteLine($"Borrow Date: {loan.BorrowDate}");
            Console.WriteLine($"Due Date: {loan.DueDate}");

            Console.WriteLine();


           
            // Items After Borrow
           

            Console.WriteLine("=== Items After Borrow ===");

            foreach (var item in library.Items)
            {
                Console.WriteLine(item.GetInfo());
            }

            Console.WriteLine();


            // Return Item
            

            Console.WriteLine("=== Return Item ===");

            string returnResult =
                library.ReturnItem(itemToBorrow!, member, loan.LoanId);

            Console.WriteLine(returnResult);

            Console.WriteLine();


           
            // Items After Return
            

            Console.WriteLine("=== Items After Return ===");

            foreach (var item in library.Items)
            {
                Console.WriteLine(item.GetInfo());
            }

            Console.WriteLine();


            
            // Save
          

            dataStorage.Save(library);

            Console.WriteLine("Library data saved successfully.");


        }
    }
}
