using System;

namespace Project
{
    partial class CD : Media<CD>, IMedia
    {
        static List<CD> cds = new List<CD>{
            new CD("Faith Of Light" , 2005, "Shajid", 1),
            new CD("Warrior Of Wind" , 2015, "Saimun", 2),
            new CD("Memory Of Hope" , 2003, "Mahi", 3),
            new CD("Python For DSA" , 2005, "Shajid", 4),
            new CD("Weak Heart" , 2004, "Zarif", 5),
        };

        private string artist;
        public string Artist
        {
            get => artist;
            set
            {
                if (value.Length != 0) artist = value;
                else Console.WriteLine("Artist's name cannot be empty!");
            }
        }
        public CD(string title, int publish_year, string artist, int id)
        : base(title, publish_year, id) => Artist = artist;
    }

    partial class CD
    {
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.Write($"Artist: {Artist}\n");
        }
        public static void AddItem()
        {
            int id = 1;
            if (cds.Count() != 0) id = cds.Last().ID + 1;
            cds.Add(new CD(InputNameForItem("Title"), InputYearForItem(), InputNameForItem("Artist's Name"), id));
        }
        public static void UpdateItem()
        {
            Media<CD>.UpdateItem(cds);
        }
        public static void DeleteItem()
        {
            Media<CD>.DeleteItem(cds);
        }
        public static void SearchItem()
        {
            Media<CD>.SearchItem(cds);
        }
        public static void ShowItems()
        {
            Media<CD>.ShowItems(cds);
        }
        public static void SearchItemByArtist()
        {
            string value = InputNameForItem("Artist");
            var items = cds.Where(x => x.Artist.Contains(value)).ToList();
            ShowItems(items);
        }
        public static void DeleteItemByArtist()
        {
            string value = InputNameForItem("Artist");
            var lists = cds.Where((CD) => CD.Artist == value);
            if (lists.Count() > 0)
            {
                string all = "";
                if (lists.Count() > 1) all = " all";
                if (TakeBoolInput($"{lists.Count()} items is found, do you want to delete{all}"))
                {
                    cds.RemoveAll(x => x.Artist == value);
                    ShowItems(cds);
                }
                else
                {
                    Console.WriteLine("Ok!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("No items is found!");
                return;
            }
        }

    }
}