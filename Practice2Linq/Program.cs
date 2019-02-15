using System;
using System.Collections.Generic;

namespace Practice2Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Book one = new Book("War and Peace I", "Lev Tolstoy", 2015, 308);
            Book two = new Book("1984", "George Orwell", 2010, 331);
            Book three = new Book("Dune", "Frank Herbert", 2016, 450);
            Book four = new Book("The Hobbit", "John Tolkien", 2008, 331);
            Book five = new Book("The Silmarillion", "John Tolkien", 2015, 357);
            Book six = new Book("The Hobbit and The Lord of the Rings", "John Tolkien", 2014, 1504);

            List <Book> bookList = new List<Book>{ one, two, three, four, five, six };

            BookDB db = new BookDB(bookList);

            Console.WriteLine("Get all books by Tolkien");
            List<string> names = db.GetAuthorBooks("Tolkien");
            names.ForEach(n => Console.Write($"{n} \n"));

            Console.WriteLine("\nMax pages: " + db.bookWithMaxPages().ToString());
            Console.WriteLine("\nBy letter T: ");
            db.PrintBooks(db.GetBookByLetter('t'));
            Console.WriteLine("\nPages LT: ");
            db.PrintBooks(db.sortByPagesLT(350));
            Console.WriteLine("\nSort by title: ");
            db.PrintBooks(db.SortByTitle());

            Console.ReadLine();
        }
    }
}
