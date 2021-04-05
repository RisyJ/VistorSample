using System;
using System.Collections.Generic;

namespace VistorSample
{   
    public interface LibirayInterface
    {
      void Accept(VistorInterface vistor);
    }
     public interface VistorInterface
    {
        void vistor(Book element);
        void vistor(Article element);
    }
    public class Book:LibirayInterface
    {
        private int page;
        public Book(int pPage)
        {
            page=pPage;
        }
        public void Accept(VistorInterface vistor)
        {
            vistor.vistor(this);
        }
        public int getPage()
        {
            return page;
        }
    }
    public class Article:LibirayInterface
    {
        private int page;
        public Article(int pPage)
        {
            page=pPage;
        }
        public void Accept(VistorInterface vistor)
        {
            vistor.vistor(this);
        }
        public int getPage()
        {
            return page;
        }
    }
    public class Manager:VistorInterface
    {
        int totalPages=0;
        public void vistor(Book book)
        {
            totalPages+=book.getPage();
        }
        public void vistor(Article article){
            totalPages+=article.getPage();
        }
        public void PrintTotalPage()
        {
            Console.WriteLine("the totalpages is "+totalPages);
        }

    }

    public class Client
    {
        List<LibirayInterface> lists=new List<LibirayInterface> ();
        public void AddToList(LibirayInterface element)
        {
            lists.Add(element);
        }
        public void addVistorToList(VistorInterface vistor)
        {
            lists.ForEach(element =>element.Accept(vistor));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Client c = new Client();
            c.AddToList(new Book(10));
            c.AddToList(new Article(30));
            Manager man = new Manager();
            c.addVistorToList(man);
            man.PrintTotalPage();            
          
        }
    }
}
