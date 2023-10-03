using System;

namespace Project{
    class Media{
        private string title;
        private int publish_year, id;
        public string Title{
            get=>title;
            set{
                if(value.Length!=0) title=value;
                else Console.WriteLine("Title cannot be empty!");
            }
        }
        public int Public_Year{
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
        public static int InputYearForItem(){
            Again:
            int publish_year=0;
            try{
                Console.WriteLine("Insert the Publish Year:");
                publish_year=Convert.ToInt32(Console.ReadLine());
                if(publish_year<1000) throw new Exception("Cannot be less 1000");
            }catch(Exception err){
                System.Console.WriteLine($"Error: {err.Message}");
                goto Again;
            }
            return publish_year;
        } 


    }
}