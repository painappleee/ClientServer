using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer_Multithreading
{
        class ProgrammLab03
        {
            // Общие переменные для работы потоков
            private static double GeneralValue = 0.5; // Начальное значение
            private static bool IsRunning = true; // Флаг для управления работой потоков
            private const int MaxIter = 10; // Максимальное количество итераций
            private static int IterCount = 0; // Счетчик итераций

            // События для синхронизации потоков
            private static AutoResetEvent CosEvent = new AutoResetEvent(true);
            private static AutoResetEvent ArcosEvent = new AutoResetEvent(false);

            static void MainLab13()
            {
                Console.WriteLine($"Начальное значение: {GeneralValue}");
                Console.WriteLine($"Максимальное количество итераций: {MaxIter}");
                // Создаем и запускаем потоки
                Thread CosThread = new Thread(CalculateCosine);
                Thread ArccosThread = new Thread(CalculateArccosine);

                CosThread.Start();
                ArccosThread.Start();

                CosThread.Join();
                ArccosThread.Join();

                Console.WriteLine("Программа завершена.");
            }

            static void CalculateCosine()
            {
                try
                {
                    while (IsRunning && IterCount < MaxIter)
                    {
                        CosEvent.WaitOne(); 

                        if (!IsRunning || IterCount >= MaxIter)
                        {
                            IsRunning = false;
                            ArcosEvent.Set(); 
                        }

                        GeneralValue = Math.Cos(GeneralValue);
                        IterCount++;
                        Console.WriteLine($"Поток косинуса [{IterCount}/{MaxIter}]: новое значение = {GeneralValue:F6}");


                        ArcosEvent.Set(); 
                        Thread.Sleep(300); 
                    }
                }
                catch (ThreadInterruptedException)
                {
                    Console.WriteLine("Поток косинуса прерван");
                }
            }

            static void CalculateArccosine()
            {
                try
                {
                    while (IsRunning && IterCount < MaxIter)
                    {
                        ArcosEvent.WaitOne(); 

                        if (!IsRunning || IterCount >= MaxIter)
                        {
                            IsRunning = false;
                            CosEvent.Set(); 
                            break;
                        }

                        

                        GeneralValue = Math.Acos(GeneralValue);
                        IterCount++;
                        Console.WriteLine($"Поток арккосинуса [{IterCount}/{MaxIter}]: новое значение = {GeneralValue:F6}");

                        CosEvent.Set();
                        Thread.Sleep(300);
                    }
                }
                catch (ThreadInterruptedException)
                {
                    Console.WriteLine("Поток арккосинуса прерван");
                }
            }
        }
}
 
