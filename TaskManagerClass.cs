using System;
using System.Diagnostics;

namespace TaskManager
{

	public class TaskManagerClass
	{
		Process[] processes;

		public void Run()
		{
			while(true)
			{
				Console.WriteLine("Welcome to the Task Manager, what do you want?");
				Console.WriteLine("1. Get all processes");
				Console.WriteLine("2. Kill a process");
				Console.WriteLine("3. Start a process");
				Console.Write("4. Run threads\n");

				int taskInput = int.Parse(Console.ReadLine());

				switch (taskInput)
				{
					case 1:
						GetAllProcesses();
						break;
					case 2:
						Console.WriteLine("Enter the process index");
						int index = int.Parse(Console.ReadLine());
						Kill(index);
						break;
					case 3:
						Console.WriteLine("Enter application path or leave it empty to open the mail app");
						string pathInput = Console.ReadLine();
						if (String.IsNullOrEmpty(pathInput))
						{
							Open();
						} else
						{
							Open(pathInput);
						}
						break;
					case 4:
						StartThreads();
						break;
				}
			}
        }

        void GetAllProcesses()
		{
			processes = Process.GetProcesses();

			for(int i = 0; i < processes.Length - 1; i++)
			{
				Console.WriteLine($"{i}. {processes[i].ProcessName}");
			}
		}

		void Kill(int index)
		{
            

            var processToKill = processes[index];

			processToKill.Kill();
		}


        void Open(string pathName = "/System/Applications/Mail.app")
        { 

			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = true;
			startInfo.FileName = pathName;

			Process process = Process.Start(startInfo);
        }

		void StartThreads()
		{
			CreateThread();
			CreateSecondThread();
		}

		void CreateThread()
		{

			Thread thread = new Thread(new ThreadStart(ThreadDelegateMethod));
			thread.Name = "Lynn's thread";
			thread.Start();
		}

        void CreateSecondThread()
        {

            Thread thread = new Thread(new ThreadStart(SecondDelegateMethod));
            thread.Name = "Second thread";
            thread.Start();
        }

        void ThreadDelegateMethod()
		{
			Console.WriteLine($"This is running on Thread: ");
			Console.WriteLine($"Is {Thread.CurrentThread.Name} thread alive? {Thread.CurrentThread.IsAlive}");
            Console.WriteLine($"Is {Thread.CurrentThread.Name} thread background? {Thread.CurrentThread.IsBackground} ");

            for (int i = 0; i <= 10; i++)
			{
				Console.WriteLine(i);
				Thread.Sleep(1000); 
			}


        }

        void SecondDelegateMethod()
        {
            Console.WriteLine($"This is running on Thread: {Thread.CurrentThread.Name}");
            
            for (int i = 10; i <= 20; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000); 
            }
			Console.WriteLine("Background? " + Thread.CurrentThread.IsBackground);
        }


    }
}