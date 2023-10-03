using System;

namespace Project{
    class Program{
        public void AddItem(){
            Menu2();
            int choice=Convert.ToInt32(Console.ReadLine());
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
            Menu2();
            int choice=Convert.ToInt32(Console.ReadLine());
            // if(choice==1) Book.AddItem();
            // else if(choice==2) CD.AddItem();
            // else if(choice==3) DVD.AddItem();
            // else{
            //     Console.WriteLine("Invalid Input!");
            //     return;
            // }
            Console.WriteLine("Successfully Added Item!\n");
        }
        public void DeleteItem(){
            Menu2();
            int choice=Convert.ToInt32(Console.ReadLine());
            // if(choice==1) Book.DeleteItem();
            // else if(choice==2) CD.AddItem();
            // else if(choice==3) DVD.AddItem();
            // else{
            //     Console.WriteLine("Invalid Input!");
            //     return;
            // }
            Console.WriteLine("Successfully Deleted Item!\n");
        }
        public void SearchItem(){
            Menu2();
            int choice=Convert.ToInt32(Console.ReadLine());
            // if(choice==1) Book.AddItem();
            // else if(choice==2) CD.AddItem();
            // else if(choice==3) DVD.AddItem();
            // else{
            //     Console.WriteLine("Invalid Input!");
            //     return;
            // }
        }
        public void ShowItems(){
            Menu2();
            int choice=Convert.ToInt32(Console.ReadLine());
            if(choice==1) Book.ShowItems();
            else if(choice==2) CD.ShowItems();
            else if(choice==3) DVD.ShowItems();
            else{
                Console.WriteLine("Invalid Input!");
                return;
            }
        }
        public static void Menu1(){
            Console.WriteLine();
            Console.WriteLine("Choose:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Update Item");
            Console.WriteLine("3. Delete Item");
            Console.WriteLine("4. Search Item");
            Console.WriteLine("5. Show Item");
            Console.WriteLine("6. Exit");
        }
        public static void Menu2(){
            Console.WriteLine();
            Console.WriteLine("Choose:");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. CD");
            Console.WriteLine("3. DVD");
        }

        static void Main(string[] args){
            Console.Clear();
            Program Obj=new Program();
            int choice;
            while(true){
                Menu1();
                choice=Convert.ToInt32(Console.ReadLine());
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