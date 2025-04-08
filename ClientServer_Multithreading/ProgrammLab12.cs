using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Создать два потока, каждый из которых выводит числа от 1 до 100. Второй поток должен быть так синхронизирован с первым, чтобы он начинал вывод своих чисел только после завершения вывода первым
Запустить потоки на параллельное выполнение
Убедится что числа второго потока выводятся только после первого
Провести эксперимент: поменять порядок запуска потоков, поставив между запусками задержку в 1с

Три варианта:
    - с использованием Join, используйте функции PrintNumbersFirstJoin и PrintNumbersSecondJoin
    - c использованием Monitor, используйте функции PrintNumbersFirstMonitor и PrintNumbersSecondMonitor
    - c использованием AutoResetEvent, используйте функции PrintNumbersFirstAutoResetEvent и PrintNumbersSecondAutoResetEvent

*/

namespace MultiThread01
{
    class ProgrammLab12
    {
        static Thread? thread1;
        static object locker = new object();
        static bool firstCompleted = false;
        static AutoResetEvent firstThreadCompleted = new AutoResetEvent(false);

        static void MainLab12()
        {
            Console.WriteLine("Основной поток начал работу");

            // Первый эксперимент - без задержки
            Console.WriteLine("\nЭксперимент 1: Без задержки между запусками");
            firstCompleted = false;
            firstThreadCompleted.Reset();
            thread1 = new Thread(PrintNumbersFirstAutoResetEvent);
            Thread thread2 = new Thread(PrintNumbersSecondAutoResetEvent);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            // Второй эксперимент - с задержкой
            Console.WriteLine("\nЭксперимент 2: С задержкой 1с между запусками");
            firstCompleted = false;
            firstThreadCompleted.Reset();
            thread1 = new Thread(PrintNumbersFirstAutoResetEvent);
            thread2 = new Thread(PrintNumbersSecondAutoResetEvent);

            thread2.Start();
            Thread.Sleep(1000); // Задержка 1 секунда
            thread1.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("\nОсновной поток завершил работу");
        }

        static void PrintNumbersFirstJoin()
        {
            Console.WriteLine("Поток 1 начал работу");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Поток 1: {i}");
            }
            Console.WriteLine("Поток 1 завершил работу");
        }

        static void PrintNumbersSecondJoin()
        {
            Console.WriteLine("Поток 2 ожидает завершения потока 1...");
            thread1.Join();
            Console.WriteLine("Поток 2 начал работу");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Поток 2: {i}");
            }
            Console.WriteLine("Поток 2 завершил работу");

            
        }

        static void PrintNumbersFirstMonitor()
        {
            lock (locker)
            {
                Console.WriteLine("Поток 1 начал работу");
                for (int i = 1; i <= 100; i++)
                {
                    Console.WriteLine($"Поток 1: {i}");
                }
                Console.WriteLine("Поток 1 завершил работу");

                firstCompleted = true;
                Monitor.Pulse(locker);
            }
        }

        static void PrintNumbersSecondMonitor()
        {
            lock (locker)
            {
                Console.WriteLine("Поток 2 ожидает завершения потока 1...");
                while (!firstCompleted)
                {
                    Monitor.Wait(locker);
                }

                Console.WriteLine("Поток 2 начал работу");
                for (int i = 1; i <= 100; i++)
                {
                    Console.WriteLine($"Поток 2: {i}");
                }
                Console.WriteLine("Поток 2 завершил работу");
            }
        }


        static void PrintNumbersFirstAutoResetEvent()
        {
            Console.WriteLine("Поток 1 начал работу");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Поток 1: {i}");
            }
            Console.WriteLine("Поток 1 завершил работу");

            firstThreadCompleted.Set();

        }

        static void PrintNumbersSecondAutoResetEvent()
        {
            Console.WriteLine("Поток 2 ожидает завершения потока 1...");
            firstThreadCompleted.WaitOne();

            Console.WriteLine("Поток 2 начал работу");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Поток 2: {i}");
            }
            Console.WriteLine("Поток 2 завершил работу");


        }


    }
}
