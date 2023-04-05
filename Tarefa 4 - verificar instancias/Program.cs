using System;
using System.Diagnostics;
using System.IO; /* Biblioteca que escreve os logs */
using System.Threading;

namespace vertask
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string processo = "firefox"; /*Nome do processo*/
                Process[] processos = Process.GetProcessesByName(processo);

                if (processos.Length > 2)
                {
                    Console.WriteLine("ERRO - Existem mais do que duas instâncias do processo {0} em execução. Total de instâncias: {1}", processo, processos.Length);
                    LogVarios(DateTime.Now, processo, processos.Length, false);
                }
                else if (processos.Length < 2)
                {
                    Console.WriteLine("ERRO - Existem menos do que duas instâncias do processo {0} em execução. Total de instâncias: {1}", processo, processos.Length);
                    Log1(DateTime.Now, processo, processos.Length, false);
                }
                else
                {
                    Console.WriteLine("Existem duas instâncias do processo {0} em execução.", processo);
                }
                Thread.Sleep(10000); /*Atualiza a cada 10 segundos*/
                Console.Clear();
            }

        }

        //Logs para caso de haver menos que duas instâncias abertas
        static void Log1(DateTime dataHora, string processo, int numInstancias, bool status)
        {
            string logEntry = $"ERRO - {dataHora.ToString()} - Existem menos do que duas instâncias do processo {processo} em execução. Total de instâncias: {numInstancias}";
            string path = @"C:\Users\Quantinfor\Desktop\logs.txt"; /*Path do ficheiro onde vai escrever*/
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(logEntry);
            }
        }

        //Logs para caso de haver mais que três instâncias abertas
        static void LogVarios(DateTime dataHora, string processo, int numInstancias, bool status)
        {
            string logEntry = $"ERRO - {dataHora.ToString()} - Existem mais do que duas instâncias do processo {processo} em execução. Total de instâncias: {numInstancias}";
            string path = @"C:\Users\Quantinfor\Desktop\logs.txt"; /*Path do ficheiro onde vai escrever*/
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(logEntry);
            }
        }
    }
}