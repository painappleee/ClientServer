using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*
Лабораторная 1.1
- Создать два потока, каждый из которых принимает на вход 2 параметра: начальное и конечное число (диапазон).
- Каждый из потоков должен вывести числа в указанном диапазоне.
- Запустить потоки на параллельное выполнение
- Использовать любой из вариантов передачи параметров
- Использовать любой из вариантов передачи параметров
*/

namespace MultiThread01
{
    class ProgrammLab11
    {
        static void MainLab11()
        {
            Console.WriteLine("Основной поток начал работу");
            
            // Создаем и запускаем потоки с помощью лямбда-выражений
            Thread thread1 = new Thread(new ParameterizedThreadStart(PrintNumbersParametrized));
            object[] parameters = { 5, 15 };
            thread1.Start(parameters);

            Printer printer = new Printer
            {
                startNumber = 10,
                endNumber = 20
            };

            Thread thread2 = new Thread(printer.PrintNumbers);
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Основной поток завершил работу");
        }

        static void PrintNumbersParametrized(object data)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу");

            if (data is object[] parameters) 
            {
                for (int i = (int)parameters[0]; i <= (int)parameters[1]; i++)
                {
                    Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: {i}");
                    Thread.Sleep(100); // Имитация работы
                }
            }

            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} завершил работу");
        }
    }

    class Printer
    {
        public int startNumber { get; set; }
        public int endNumber { get; set; }

        public void PrintNumbers()
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу");

            for (int i = startNumber; i <= endNumber; i++)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: {i}");
                Thread.Sleep(100); // Имитация работы
            }

            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} завершил работу");
        }
    }
}
