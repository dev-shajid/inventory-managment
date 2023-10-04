using System;

namespace Project{
    class Program{
        public void AddItem(){
            int choice=Menu2();
            if(choice==1) Book.AddItem();
            else if(choice==2) CD.AddItem();
            else if(choice==3) DVD.AddItem();
            else{
                Console.WriteLine("Invalid Input!");
                return;
            }
            Console.WriteLine("Successfully Added Item!\n");
        }
        public void UpdateItem(){
            int choice=Menu2();
            if(choice==1) Book.UpdateItem();
            else if(choice==2) CD.UpdateItem();
            else if(choice==3) DVD.UpdateItem();
            else Console.WriteLine("Invalid Input!");
        }
        public void DeleteItem(){
            int choice=Menu2();
            if(choice==1) Book.DeleteItem();
            else if(choice==2) CD.AddItem();
            else if(choice==3) DVD.AddItem();
            else Console.WriteLine("Invalid Input!");
        }
        public void SearchItem(){
            int choice=Menu2();
            if(choice==1) Book.SearchItem();
            else if(choice==2) CD.SearchItem();
            else if(choice==3) DVD.SearchItem();
            else{
                Console.WriteLine("Invalid Input!");
                return;
            }
        }
        public void ShowItems(){
            int choice=Menu2();
            if(choice==1) Book.ShowItems();
            else if(choice==2) CD.ShowItems();
            else if(choice==3) DVD.ShowItems();
            else Console.WriteLine("Invalid Input!");
        }
        public static int Menu1(){
            int choice;
            Again:
            try{
                Console.WriteLine();
                Console.WriteLine("Choose:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Update Item");
                Console.WriteLine("3. Delete Item");
                Console.WriteLine("4. Search Item");
                Console.WriteLine("5. Show Item");
                Console.WriteLine("6. Exit");
                choice=Convert.ToInt32(Console.ReadLine());
            }catch(Exception err){
                System.Console.WriteLine($"Error: {err.Message}");
                goto Again;
            }
            return choice;
        }
        public static int Menu2(){
            int choice;
            Again:
            try{
                Console.WriteLine();
                Console.WriteLine("Choose:");
                Console.WriteLine("1. Book");
                Console.WriteLine("2. CD");
                Console.WriteLine("3. DVD");
                choice=Convert.ToInt32(Console.ReadLine());
            }catch(Exception err){
                System.Console.WriteLine($"Error: {err.Message}");
                goto Again;
            }
            return choice;
        }

        static void Main(string[] args){
            Console.Clear();
            Program Obj=new Program();
            while(true){
                int choice=Menu1();
                if(choice==1) Obj.AddItem();
                else if(choice==2) Obj.UpdateItem(); // Update Item By ID
                else if(choice==3) Obj.DeleteItem(); // Delete Item By ID
                else if(choice==4) Obj.SearchItem(); // Search
                else if(choice==5) Obj.ShowItems(); // Show Lists
                else if(choice==6) break;
                else Console.WriteLine("Invalid Input!");
            }
        }
    }
}