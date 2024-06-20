using System;
using System.Threading;

namespace CountDown {
    class Program {

        static void Main (string[] args) {
                
            //Start(8); - quando estamos testando
            Menu();
        }

        static void Menu() {

            Console.Clear();
            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto => 1m = 1 minuto");
            Console.WriteLine("0 = Sair!");
            Console.WriteLine("Quanto vamos contar?");

            string? data = Console.ReadLine()?.ToLower(); //atencao aos nulos
            if (string.IsNullOrEmpty(data)) return; //tratamento para o warning
            char type = char.Parse(data.Substring(data.Length - 1, 1));
            int time = int.Parse(data.Substring(0, data.Length -1));
            int multiplier = 1;

            if(type == 'm' ){
                multiplier = 60;
            }
            //condicao para sair quando for nulo
            if(time == 0) {
                System.Environment.Exit(0);
            }

            PreStart(time * multiplier); //por conta do formato da aplicacao 
        }

        static void PreStart(int time) { //EFEITO ANTES DO INICIO

            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);

        }

        static void Start(int time) { 

            int CurrentTime = 0;
            //int time //time = 10;

            while (CurrentTime != time)
            {
                Console.Clear();
                CurrentTime++; 
                Console.WriteLine(CurrentTime);
                Thread.Sleep(1000);
            } 

            Console.Clear();
            Console.WriteLine("StopWatch finalizado.");
            Thread.Sleep(2500);
            Menu();
        }
    }
}

//Current time = tempo inicial
//CurrentTime++; //incrementa pra um dia conseguirmos sair do loop
//esperar 1 segundo = thread
//Thread.Sleep(1000); o tempo que eu vou dormir em milissegundos (1s)