using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaAssignment1
{
    internal class Book
    {
        private string title;
        private string author;
        private long isbn;
        private double price;
        private static int numberofbooks=0;
        public Book(string title,string author, long isbn, double price) 
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.price = price;
            numberofbooks++;
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title=title;
        } 
        public long GetIsbn() 
        { 
            return isbn;
        }
        public void SetAuthor(string author) 
        {
            this.author = author;
        }
        public string GetAuthor() 
        {
            return author;
        }
        public void SetIsbn(long isbn) 
        {
            this.isbn = isbn;
        }
        public double GetPrice() { return price;}
        public void SetPrice(double price) { this.price = price; }
        public override bool Equals(Object obj)
        {
            Book book;
            if (obj == null || !(obj is Book))
                return false;
            else
                book= (Book)obj;
                return this.isbn==book.isbn;
        }
        public override string ToString()
        {
            return "Title: "+title+"\nAuthor: "+author+"\nISBN: "+isbn+"\nPrice: "+price;
        }
        public int findNumberOfCreatedBooks() { return (numberofbooks - 1); }
    }
}
