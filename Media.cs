using System;

namespace Project{
    public interface IMedia
    {
        int ID{get;}
        string Title{get; set;}
        int Publish_Year{get; set;}
        void DisplayInfo();
    }

    partial class Media<T> where T:IMedia{
        private string title;
        private int publish_year, id;
        public string Title{
            get=>title;
            set{
                if(value.Length!=0) title=value;
                else Console.WriteLine("Title cannot be empty!");
            }
        }
        public int Publish_Year{
            get =>publish_year;
            set=>publish_year = value;
        }
        public int ID{
            get =>id;
            private set{}
        }
        public Media(string title, int publish_year, int id){
            this.title=title;
            this.publish_year=publish_year;
            this.id=id;
        }
    }


    // Partial Class for Action handling
    partial class Media<T>{  
        public virtual void DisplayInfo(){
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Publish Year: {publish_year}");
        }
        public static void ShowItems(List<T> items){
            if(items.Count()==0){
                Console.WriteLine("No Items is Found!");
                return;
            }
            Console.WriteLine("---------------------");
            foreach(var item in items){
                Console.WriteLine();
                if (item is IMedia displayable) displayable.DisplayInfo();
            }
            Console.WriteLine();
            Console.WriteLine("---------------------");
        }
        public static void UpdateItem(List<T> items){
            Console.WriteLine();

            int index = InputIDForItem(items);
            if(index==-1) return;

            if(TakeBoolInput("Want to Update Title")){
                string title=InputNameForItem("New Title");
                items[index].Title=title;
            }
            if(TakeBoolInput("Want to Update Publish Year")){
                int publish_year=InputYearForItem("New Publish Year");
                items[index].Publish_Year=publish_year;
            }
            if(items[index] is Book b && TakeBoolInput("Want to Update Author")){
                string author=InputNameForItem("New Author");
                b.Author=author;
            }
            else if(items[index] is CD cd && TakeBoolInput("Want to Update Artist")){
                string artist=InputNameForItem("New Artist");
                cd.Artist=artist;
            }
            else if(items[index] is DVD dvd && TakeBoolInput("Want to Update Director")){
                string director=InputNameForItem("New Director");
                dvd.Director=director;
            }
            
            Console.WriteLine();
            if (items[index] is IMedia obj) obj.DisplayInfo();
            Console.WriteLine("Successfully Updated Item!");
        }
        public static void DeleteItem(List<T> items){
            Console.WriteLine();
            int choice=InputCriterion();
            if(choice==1){
                int index = InputIDForItem(items);
                if(index==-1) return;
                items.RemoveAt(index);
            }
            else if(choice==2){
                string title=InputNameForItem("Title");
                var lists=items.Where(x=>x.Title.Contains(title));
                if(lists.Count()>0){
                    string all="";
                    if(lists.Count()>1) all=" all";
                    if(TakeBoolInput($"{lists.Count()} items is found, do you want to delete{all}")){
                        items.RemoveAll(x=>x.Title.Contains(title));
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
            else if(choice==3){
                if(typeof(T)==typeof(Book) && items is List<Book> books){
                    Book.DeleteItemByAuthor();
                }
                else if(typeof(T)==typeof(CD)){
                    // Book.DeleteItemByAuthor();
                }
                else if(typeof(T)==typeof(DVD)){
                    // Book.DeleteItemByAuthor();
                }
                return;
            }
            else return;
            
            Console.WriteLine();
            ShowItems(items);
            Console.WriteLine("\nSuccessfully Deleted Item!");
        }
        public static void SearchItem(List<T> items){
            Console.WriteLine();
            int choice=InputCriterion(4);
            List<T> lists=new List<T>();
            if(choice==1){
                int index = InputIDForItem(items);
                if(index==-1) return;
                Console.WriteLine();
                items[index].DisplayInfo();
                Console.WriteLine();
                return;
            }
            else if(choice==2){
                lists=SearchItemByTitle(items).ToList();
            }
            else if(choice==3){
                if(typeof(T)==typeof(Book)){
                    Book.SearchItemByAuthor();
                }
                else if(typeof(T)==typeof(CD)){
                    Book.SearchItemByAuthor();
                }
                else if(typeof(T)==typeof(DVD)){
                    Book.SearchItemByAuthor();
                }
                return;
            }
            else if(choice==4){
                lists=SearchItemByPublishYear(items).ToList();
            }
            ShowItems(lists);
        }
    }


    // Partial Class for Input with error handling
    partial class Media<T>{
        public static string InputNameForItem(string type){
            Again:
            string? name=null;
            try{
                Console.WriteLine($"Insert the {type}:");
                name=Console.ReadLine();
                if(name!.Count()<3) throw new Exception("Should have atleast 3 characters");
            }
            catch(Exception err){
                Console.WriteLine($"Error: {err.Message}");
                goto Again;
            }
            return name!;
        }
        public static int InputYearForItem(string message="Publish Year"){
            Again:
            int publish_year=0;
            try{
                Console.WriteLine($"Insert the {message}:");
                publish_year=Convert.ToInt32(Console.ReadLine());
                if(publish_year<1000) throw new Exception("Cannot be less 1000");
            }catch(Exception err){
                System.Console.WriteLine($"Error: {err.Message}");
                goto Again;
            }
            return publish_year;
        } 
        public static int InputIDForItem(List<T> items, string message="ID"){
            // Again:
            int value=-1, index=-1;
            try{
                Console.WriteLine($"Insert the {message}:");
                value=Convert.ToInt32(Console.ReadLine());
                index=items.FindIndex(x=>x.ID==value);
                if(index==-1) throw new Exception("Do not exist!");
            }catch(Exception err){
                Console.WriteLine($"Error: {err.Message}\n");
                return -1;
                // goto Again;
            }
            return index;
        } 
        public static bool TakeBoolInput(string message=""){
            Again:
            int value=0;
            try{
                Console.WriteLine($"{message}? (1/0)");
                value=Convert.ToInt32(Console.ReadLine());
                if(value!=1 && value!=0) throw new Exception("Insert Only 1 or 0");
            }catch(Exception err){
                System.Console.WriteLine($"Error: {err.Message}");
                goto Again;
            }
            return value==1?true:false;
        }
        public static int InputCriterion(int item=3){
            int value;
            try{      
                Console.WriteLine("Based On:");
                Console.WriteLine("1. ID");
                Console.WriteLine("2. Title");
                if(typeof(T)==typeof(Book)) Console.WriteLine("3. Author");
                else if(typeof(T)==typeof(CD)) Console.WriteLine("3. Artist");
                else if(typeof(T)==typeof(DVD)) Console.WriteLine("3. DVD");
                if(item==4) Console.WriteLine("4. Publish Year");
                
                value=Convert.ToInt32(Console.ReadLine());
                if(value<1 || value>item) throw new Exception("Invalid Input!");
            }catch(Exception err){
                Console.WriteLine($"Error: {err.Message}");
                return 0;
            }
            return value;
        }
        public static List<Book> BookAuthorSearchList(List<T> items){
            string title=InputNameForItem("Title");
            IEnumerable<T> l=items;
            if(typeof(T)==typeof(Book) && items is List<Book> b) return b.Where(x=>x.Author==title).ToList();
            return null;
        }
        public static IEnumerable<T> SearchItemByTitle(List<T> items){
            string title=InputNameForItem("Title");
            return items.Where(x=>x.Title.Contains(title));
        }
        public static IEnumerable<T> SearchItemByPublishYear(List<T> items){
            int year=InputYearForItem("Publish Year");
            return items.Where(x=>x.Publish_Year==year);
        }



    }
}
