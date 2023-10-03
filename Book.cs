using System;

namespace Project{
    partial class Book:Media<Book>,IShowable{
        static List<Book> books=new List<Book>{
            new Book("Faith Of Light" , 2005, "Shajid", 1),
            new Book("Warrior Of Wind" , 2015, "Saimun", 2),
            new Book("Memory Of Hope" , 2003, "Mahi", 3),
            new Book("Python For DSA" , 2005, "Shajid", 4),
            new Book("Weak Heart" , 2004, "Zarif", 5),
        };

        private string author;
        public string Author{
            get=>author;
            set{
                if(value.Length!=0) author=value;
                else Console.WriteLine("Author name cannot be empty!");
            }
        }
        public Book(string title, int publish_year, string author, int id)
        :base(title, publish_year, id) => this.author=author;
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.Write($"Author: {this.author}\n");
        }
    }

    partial class Book{
        public static void AddItem(){
            int id=1;
            if(books.Count()!=0) id=books.Last().ID+1;
            books.Add(new Book(InputNameForItem("Title"), InputYearForItem(), InputNameForItem("Author's Name"), id));
        }
        public static void UpdateItem(){
            
        }
        public static void DeleteItem(){
            
        }
        public static void SearchItem(){
            
        }
        public static void ShowItems(){
            Media<Book>.ShowItems(books);
        }
    }
}