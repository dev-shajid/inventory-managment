using System;

namespace Project{
    partial class Book:Media<Book>, IMedia{
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
    }

    partial class Book{
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.Write($"Author: {this.author}\n");
        }
        public static void AddItem(){
            int id=1;
            if(books.Count()!=0) id=books.Last().ID+1;
            books.Add(new Book(InputNameForItem("Title"), InputYearForItem(), InputNameForItem("Author's Name"), id));
        }
        public static void UpdateItem(){
            Media<Book>.UpdateItem(books);
        }
        public static void DeleteItem(){
            Media<Book>.DeleteItem(books);
        }
        public static void SearchItem(){
            Media<Book>.SearchItem(books);
        }
        public static void ShowItems(){
            Media<Book>.ShowItems(books);
        }
        public static void SearchItemByAuthor(){
            string value=InputNameForItem("Author");
            var items=books.Where(x=>x.Author.Contains(value)).ToList();
            ShowItems(items);
        }
        public static void DeleteItemByAuthor(){
            string value=InputNameForItem("Author");
            var lists = books.Where((book)=>book.Author==value);
            if(lists.Count()>0){
                string all="";
                if(lists.Count()>1) all=" all";
                if(TakeBoolInput($"{lists.Count()} items is found, do you want to delete{all}")){
                    books.RemoveAll(x=>x.Author==value);
                    ShowItems(books);
                }
                else{
                    Console.WriteLine("Ok!");
                    return;
                }
            }
            else{
                Console.WriteLine("No items is found!");
                return;
            }
        }
   
    }
}