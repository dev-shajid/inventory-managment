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
        public virtual void DisplayInfo(){
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Publish Year: {publish_year}");
        }
        public static void ShowItems(List<T> items){
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

            if(TakeBoolInput("Title")==1){
                string title=InputNameForItem("New Title");
                items[index].Title=title;
            }
            if(TakeBoolInput("Publish Year")==1){
                int publish_year=InputYearForItem("New Publish Year");
                items[index].Publish_Year=publish_year;
            }
            if(items[index] is Book b && TakeBoolInput("Author")==1){
                string author=InputNameForItem("New Author");
                b.Author=author;
            }
            else if(items[index] is CD cd && TakeBoolInput("Artist")==1){
                string artist=InputNameForItem("New Artist");
                cd.Artist=artist;
            }
            else if(items[index] is DVD dvd && TakeBoolInput("Director")==1){
                string director=InputNameForItem("New Director");
                dvd.Director=director;
            }
            
            Console.WriteLine();
            if (items[index] is IMedia obj) obj.DisplayInfo();
            Console.WriteLine("Successfully Updated Item!");
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
        public static int TakeBoolInput(string message=""){
            Again:
            int value=0;
            try{
                Console.WriteLine($"Want to Update {message}? (1/0)");
                value=Convert.ToInt32(Console.ReadLine());
                if(value!=1 && value!=0) throw new Exception("Insert Only 1 or 0");
            }catch(Exception err){
                System.Console.WriteLine($"Error: {err.Message}");
                goto Again;
            }
            return value;
        }
    }
}
