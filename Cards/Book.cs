using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cards
{
    class Book
    {
        //class variables
        private string title;
        int pages;
        int edition;
        public string author;

        public Book()
        {

        }

        public Book(string Title, int Pages, int Edition, string Author)
        {
            title = Title;
            pages = Pages;
            edition = Edition;
            author = Author;
        }

        public void PrintInfo()
        {
            WriteLine("The Title is {0}\nThe Book has {1} pages\nIt is edition number {2}\nThe Author is {3}", title, pages, edition, author);

        }

        // ======================= getter and setter for title ====================
        public void SetTitle(string newTitle)
        {
            title = newTitle;
        }

        public string GetTitle()
        {
            return title;
        }

        //========================= getter and setter for pages =====================
        protected void SetPages(int newPages)
        {
            pages = newPages;
        }

        protected int GetPages()
        {
            return pages;
        }
    }
}
