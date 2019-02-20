using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Practice2Linq
{
    class BookDB
    {
        List<Book> books;

        List<Book> Books { get => books; set => books = value; }

        public BookDB()
        {
        }

        public BookDB(List<Book> books)
        {
            this.Books = books;
        }    

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> SortByTitle()
        {
            var selectedItems = from b in books
                                orderby b.Name
                                select b;
            return (List<Book>)selectedItems.ToList<Book>();
        }

        public List<Book> GetBookByLetter(char letter)
        {
            var selectedItems = from b in books
                                where b.Name.ToLower().StartsWith(letter.ToString())
                                select b;
            return (List<Book>)selectedItems.ToList<Book>();
        }

        public List<string> GetAuthorBooks(string author)
        {
            var selectedItems = from b in books
                                where b.Author.ToLower().Contains(author.ToLower())
                                select b.Name;
            return (List<string>)selectedItems.ToList<string>();
        }

        public List<Book> sortByPagesLT(int pages)
        {
            var selectedItems = from b in books
                                where b.Pages < pages
                                select b;
            return (List<Book>)selectedItems.ToList<Book>();
        }

        public Book bookWithMaxPages()
        {
            return books.OrderByDescending(b => b.Pages).First();
        }

        public void PrintBooks(List<Book> books)
        {
            books.ForEach(b => Console.WriteLine(b.ToString()));
        }

        public void Serialize()
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, books);
                }
            }
            catch (IOException)
            {

            }
        }

        public void Deserialize()
        {
            try
            {
                using(Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var booksDeserialized = (List<Book>)bin.Deserialize(stream);
                    books = booksDeserialized;
                }
            } catch (IOException)
            {
            }
        }
    }
}
