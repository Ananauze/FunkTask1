using System;
using System.Text;

namespace FunkTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            const string CommandAddDossier = "1";
            const string CommandShowAllDossier = "2";
            const string CommandRemoveDossier = "3";
            const string CommandFindDossier = "4";
            const string CommandUserExit = "5";

            string[] fullNames = new string [0];
            string[] jobTitles = new string[0];
            bool isWorking = true;
            string userInput = "";

            while (isWorking)
            {
                Console.WriteLine("\nДобро пожаловать в кадровую службу! У нас вы можете:");
                Console.WriteLine($"{CommandAddDossier} - Добавить досье в базу");
                Console.WriteLine($"{CommandShowAllDossier} - показать все досье в базе.");
                Console.WriteLine($"{CommandRemoveDossier} - Удалить последнее досье из базы по номеру.");
                Console.WriteLine($"{CommandFindDossier} - Поиск досье по фамилии.");
                Console.WriteLine($"{CommandUserExit} - Выход из приложения.");
                Console.Write("Выберите вариант: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddNewDosser(ref fullNames, ref jobTitles);
                        break;
                    
                    case CommandShowAllDossier:
                        DisplayDossier(fullNames, jobTitles);
                        break;
                    
                    case CommandRemoveDossier:
                        DeleteDosser(ref fullNames, ref jobTitles);
                        break;
                    
                    case CommandFindDossier:
                        SearchDosserInBase(fullNames, jobTitles);
                        break;
                    
                    case CommandUserExit:
                        Console.WriteLine("Не очень то и хотелось с тобой работать, кожаный.");
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddNewDosser(ref string[] names, ref string[] job) 
        {
                Console.Write("Введите фамилию сотрудника: ");
                string fullName = Console.ReadLine();
                Console.Write("Введите должность сотрудника: ");
                string jobTitle = Console.ReadLine();

                names = AddDataToArray(names, fullName);
                job = AddDataToArray(job, jobTitle);
        }

        static string[] AddDataToArray(string[] array, string text)
        {
            string[] temporaryArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temporaryArray[i] = array[i];
            }

            temporaryArray[temporaryArray.Length - 1] = text;
            array = temporaryArray;
            return array;
        }

        static void DisplayDossier(string[] names, string[] jobTitles) 
        {
            Console.Clear();
            Console.WriteLine("Отобразим список доступных досье: ");

            int index = 1;

            for (int i = 0; i < jobTitles.Length; i++) 
            {
                Console.WriteLine($"{index} - Фамилия: {names[i]} - Должность: {jobTitles[i]}.");
                index++;
            }

            Console.ReadKey();
        }

        static void DeleteDosser(ref string[] names, ref string[] positions) 
        {
            Console.WriteLine("Введите номер досье для удаления: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number > 0 && number <= names.Length)
            {
                int index = number - 1;
                names = DeleteDataFromArray(names, index);
                positions = DeleteDataFromArray(positions, index);
                Console.WriteLine($"Досье с номером {index + 1} удалено!");
            }
            else 
            {
                Console.WriteLine("У вас не получится обмануть систему, такой записи нет.");
            }
        }

        static string[] DeleteDataFromArray(string [] array, int index) 
        {
            string[] temporaryArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                temporaryArray[i] = array[i];
            }

            for (int i = index; i < array.Length - 1; i++)
            {
                temporaryArray[i] = array[i + 1];
            }

            array = temporaryArray;
            return array;
        }

        static void SearchDosserInBase(string[] names, string[] positions ) 
        {
            Console.WriteLine("Можем найти сотрудника по фамилии.");
            Console.Write("Введите фамилию для поиска: ");
            string searchSurname = Console.ReadLine();
            char splitSymbol = ' ';

            for (int i = 0; i < names.Length;i++) 
            {
                string[] lastNames = names[i].Split(splitSymbol);

                if (lastNames[i].ToLower() == searchSurname.ToLower())
                {
                    Console.WriteLine($"\nСотрудник найден, Досье {i + 1}, Фамилия {names[i]}, должность {positions[i]}");
                    break;
                }
                else 
                {
                    Console.WriteLine("\nСотрудник не найден :(");
                    break;
                }
            }
        }
    }
}
