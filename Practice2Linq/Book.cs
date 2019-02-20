using System;

namespace Practice2Linq
{
    [Serializable()]
    class Book
    {
        private string name;
        private string author;
        private int year;
        private int pages;

        public Book(string name, string author, int year, int pages)
        {
            this.Name = name;
            this.Author = author;
            this.Year = year;
            this.Pages = pages;
        }

        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public int Year { get => year; set => year = value; }
        public int Pages { get => pages; set => pages = value; }

        public override String ToString()
        {
            return $"{Name} by {Author}. Year: {Year}. Pages: {Pages}";
        }
    }
}
