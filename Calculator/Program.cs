
using System;

namespace Calculator
{
    class Program {

        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu() {
            Console.Clear();

            Console.WriteLine("What do you want to calculate today?");
            Console.WriteLine("1 - Sum");
            Console.WriteLine("2 - Subtration");
            Console.WriteLine("3 - Division");
            Console.WriteLine("4 - Multiplication");
            Console.WriteLine("5 - Exit");

            Console.WriteLine();
            Console.WriteLine("Choose your option:");

            short res = short.Parse(Console.ReadLine());

            switch (res) {
                case 1: Sum(); break;
                case 2: Subtration(); break;
                case 3: Division(); break;
                case 4: Multiplication(); break;
                case 5: System.Environment.Exit(0); break;
                default: Menu(); break;      
            }
        }
        static void Sum() {

            Console.Clear(); 

            Console.WriteLine("First Value: ");  
            float v1 = float.Parse(Console.ReadLine());  
            Console.WriteLine($"You first value is: {v1}");

            Console.WriteLine("Second Value: ");  
            float v2 = float.Parse(Console.ReadLine());  
            Console.WriteLine($"You second value is: {v2}");  
   
            Console.WriteLine();

            float resultado = v1 + v2;
            Console.WriteLine($"You result is: {resultado}");
            
            Console.ReadKey();
            Menu();
        }

        static void Subtration ()
        {
            Console.Clear(); 

            Console.WriteLine("First Value: ");  
            float v1 = float.Parse(Console.ReadLine());  
            Console.WriteLine($"You first value is: {v1}");

            Console.WriteLine("Second Value: ");  
            float v2 = float.Parse(Console.ReadLine());  
            Console.WriteLine($"You second value is: {v2}");  
   
            Console.WriteLine();

            float resultado = v1 - v2;
            Console.WriteLine($"You result is:{resultado}");
            
            Console.ReadKey();
            Menu();
        }

            static void Division () {

            Console.Clear(); 

            Console.WriteLine("First Value: ");  
            float v1 = float.Parse(Console.ReadLine());  
            Console.WriteLine($"You first value is: {v1}");

            Console.WriteLine("Second Value: ");  
            float v2 = float.Parse(Console.ReadLine());  
            Console.WriteLine($"You second value is: {v2}");  
   
            Console.WriteLine();

            float resultado = v1 / v2;
            Console.WriteLine($"You result is: {resultado}");
            
            Console.ReadKey();
            Menu();
        }
    

    static void Multiplication ()
     {
            Console.Clear(); 

            Console.WriteLine("First Value: ");  
            float v1 = float.Parse(Console.ReadLine());  
            Console.WriteLine($"You first value is:{v1}");

            Console.WriteLine("Second Value: ");  
            float v2 = float.Parse(Console.ReadLine());  
            Console.WriteLine($"You second value is:{v2}");  
   
            Console.WriteLine();

            float resultado = v1 * v2;
            Console.WriteLine($"You result is:{resultado}");
            
            Console.ReadKey();
            Menu();
        }
    }
}

