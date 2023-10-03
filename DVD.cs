using System;

namespace Project{
    partial class DVD:Media<DVD>, IShowable{
        static List<DVD> dvds=new List<DVD>{
            new DVD("Faith Of Light" , 2005, "Shajid", 1),
            new DVD("Warrior Of Wind" , 2015, "Saimun", 2),
            new DVD("Memory Of Hope" , 2003, "Mahi", 3),
            new DVD("Python For DSA" , 2005, "Shajid", 4),
            new DVD("Weak Heart" , 2004, "Zarif", 5),
        };

        private string director;
        public string Director{
            get=>director;
            set{
                if(value.Length!=0) Director=value;
                else Console.WriteLine("Director's name cannot be empty!");
            }
        }
        public DVD(string title, int publish_year, string director, int id)
        :base(title, publish_year, id) => Director=director;
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.Write($"Director: {Director}\n");
        }
    }

    partial class DVD{
        public static void AddItem(){
            int id=1;
            if(dvds.Count()!=0) id=dvds.Last().ID+1;
            dvds.Add(new DVD(InputNameForItem("Title"), InputYearForItem(), InputNameForItem("Director's Name"), id));
        }
        public static void UpdateItem(){
            
        }
        public static void DeleteItem(){
            
        }
        public static void SearchItem(){
            
        }
        public static void ShowItems(){
            Media<DVD>.ShowItems(dvds);
        }
    }
}