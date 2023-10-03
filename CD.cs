using System;

namespace Project{
partial class CD:Media<CD>, IShowable{
    static List<CD> cds=new List<CD>{
        new CD("Faith Of Light" , 2005, "Shajid", 1),
        new CD("Warrior Of Wind" , 2015, "Saimun", 2),
        new CD("Memory Of Hope" , 2003, "Mahi", 3),
        new CD("Python For DSA" , 2005, "Shajid", 4),
        new CD("Weak Heart" , 2004, "Zarif", 5),
    };

    private string artist;
    public string Artist{
        get=>artist;
        set{
            if(value.Length!=0) artist=value;
            else Console.WriteLine("Artist's name cannot be empty!");
        }
    }
    public CD(string title, int publish_year, string artist, int id)
    :base(title, publish_year, id) => Artist=artist;
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.Write($"Author: {Artist}\n");
    }
    }

    partial class CD{
        public static void AddItem(){
            int id=1;
            if(cds.Count()!=0) id=cds.Last().ID+1;
            cds.Add(new CD(InputNameForItem("Title"), InputYearForItem(), InputNameForItem("Artist's Name"), id));
        }
        public static void UpdateItem(){
            
        }
        public static void DeleteItem(){
            
        }
        public static void SearchItem(){
            
        }
        public static void ShowItems(){
            Media<CD>.ShowItems(cds);
        }
    }
}