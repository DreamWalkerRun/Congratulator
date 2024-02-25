using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;

namespace DayOfBirth
{
    class BIRTH
    {
        public string Name { get; set; } = string.Empty;  // Имя именинника
        public DateTime DATA { get; set; }  // дата дня рождения

    }

    class Program
    {
        static ConsoleKey choice;
        static int once = 0;
        static int sch;
        static void Main()
        {
            List<BIRTH> ListOfBIRTH = new List<BIRTH>();   // инициализация списка объектов "дней рождений"
            List<BIRTH> ListOfBIRTHSorting = new List<BIRTH>();    // инициализация списка объектов для сортировки
//===================================================================================================================================================
            void All_list_to_the_screen()   //  метод для вывода полей объектов из списка List в памяти
            {
                if (ListOfBIRTH.Count == 0)
                { Console.WriteLine("\n\n  В памяти нет списка дней рождений... \n"); }
                else
                    for (int i = 0; i < ListOfBIRTH.Count; i++)
                    {
                        sch = i + 1;
                        Console.WriteLine("\n день рождения № " + sch +
                                          "\n    Имя: " + ListOfBIRTH[i].Name +
                                          "\n    дата рождения: " + ListOfBIRTH[i].DATA);
                        Console.WriteLine("------------------");
                    }
            }
//===================================================================================================================================================
            void Sorting()                  // метод для вывода ближайших дней рождений 
            {
                if (ListOfBIRTH.Count == 0)
                { Console.WriteLine("\n\n  В памяти нет списка дней рождений.\n"); }
                
                else
                    ListOfBIRTH.Sort((x, y) => x.DATA.CompareTo(y.DATA));
                    
                    Console.WriteLine("\n\n ближайшие три дня рождения:");
                    int j = 0;
                    for (int i = 0; i < ListOfBIRTH.Count; i++)
                    {
                    ListOfBIRTHSorting[i].Name = ListOfBIRTH[i].Name;
                    ListOfBIRTHSorting[i].DATA = ListOfBIRTH[i].DATA;
                    DateTime dt2 = ListOfBIRTHSorting[i].DATA;
                        DateTime dtNow = DateTime.Now;
                        ListOfBIRTHSorting[i].DATA = new DateTime(dtNow.Year,dt2.Month,dt2.Day);
                        
                        if (ListOfBIRTHSorting[i].DATA>=dtNow & j<3)
                        {
                            
                            Console.WriteLine("\n    Имя: " + ListOfBIRTHSorting[i].Name +
                                              "\n    дата рождения: " + ListOfBIRTHSorting[i].DATA.Day + "." + ListOfBIRTHSorting[i].DATA.Month);

                            Console.WriteLine("------------------");
                            j++;
                        }
                }
            }

            do
            {
                do
                {
                    if (once == 0)               // вывод меню
                    {
                        Console.WriteLine("\n      Привет! я программа Congratulator =) " +
                                          "\n        я умею запоминать дни рождения!\n ");
                    }
                    Console.WriteLine("\n Нажми нужную цифру: \n"
                                       + "   1 - посмотреть список дней рождения в памяти\n"
                                       + "   2 - добавить день рождения в список\n"
                                       + "   3 - удалить день рождения из списка\n"
                                       + "   4 - редактировать список дней рождения \n"
                                       + "   5 - сохранить список в файл\n"
                                       + "   6 - загрузить список дней рождения из файла\n"
                                       + "   7 - показать первые три ближайших дня рождения\n"
                                       + " Для выхода из программы нажмите Esc.");
                    if (once == 0)
                    {
                        Console.WriteLine("\n *** для облегчения ввода данных при проверке программы - выберите пункт 6");
                        once++;
                    }

                    choice = Console.ReadKey(true).Key;

                    if (choice == ConsoleKey.D1)        //    Вывод всего списка дней рождения   ******* 1 ******* 
                    {
                        if (ListOfBIRTH.Count != 0) Console.WriteLine("\n\n\n  Вот список всех дней рождения в памяти: \n");

                        All_list_to_the_screen();
                    }


                    else if (choice == ConsoleKey.D2)   //    добавить пункт в список      ******* 2 *******
                    {
                        Console.Clear();
                        Console.Write("\n\n   Введите Имя: ");
                        ListOfBIRTH.Add(new BIRTH() { Name = Console.ReadLine() });

                        Console.Write("   Введите дату рождения в формате дд.мм.гггг (например: 04.05.2005): ");
                        ListOfBIRTH[^1].DATA = DateTime.Parse(Console.ReadLine());
                    }


                    else if (choice == ConsoleKey.D3)   //      удалить пункт из списка    ******* 3 *******
                    {
                        if (ListOfBIRTH.Count == 0)     //проверка корректности ввода номера дня рождения
                        { Console.WriteLine("\n в памяти нет списка, введите его или загрузите из файла.."); }
                        else
                        {
                            Console.WriteLine("\n\n  Вот список всех дней рождения:\n ");
                            All_list_to_the_screen();

                            Console.Write("\n    Какой пункт удалить?: ");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if (index > ListOfBIRTH.Count | index < 0 | index == 0)
                                do
                                {
                                    Console.WriteLine("\n\n  нет такого пункта...сорян\n  попробуйте еще.\n ");
                                    Console.Write("\n    Какой пункт удалить?: ");
                                    index = Convert.ToInt32(Console.ReadLine());
                                }
                                while (index > ListOfBIRTH.Count | index < 0 | index == 0);

                            ListOfBIRTH.RemoveAt(index - 1);
                            Console.Write("\n\n пункт удален...\n");
                        }
                    }

                    else if (choice == ConsoleKey.D4)   //   редактировать список          ******* 4 *******
                    {
                        if (ListOfBIRTH.Count == 0)      //проверка корректности ввода номера дня рождения
                        { Console.WriteLine("\n\n в памяти нет списка, введите его или загрузите из файла.."); }
                        else
                        {
                            Console.WriteLine("\n\n  Вот список всех дней рождения:\n ");
                            All_list_to_the_screen();

                            Console.Write("\n    Какой пункт будете редактировать?: ");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if (index > ListOfBIRTH.Count | index < 0 | index == 0)
                                do
                                {
                                    Console.WriteLine("\n\n  нет такого пункта...");
                                    Console.Write("\n    Какой пункт будете редактировать?: ");
                                    index = Convert.ToInt32(Console.ReadLine());
                                }
                                while (index > ListOfBIRTH.Count | index < 0 | index == 0);

                            Console.Write("\n\n   Введите новое имя именинника №" + index + " : ");
                            ListOfBIRTH.Insert(index, new BIRTH() { Name = Console.ReadLine() });

                            Console.Write("   Введите дату рождения в формате дд.мм.гггг (например: 04.05.2005): ");
                            ListOfBIRTH[index].DATA = DateTime.Parse(Console.ReadLine());

                            ListOfBIRTH.RemoveAt(index - 1);

                            Console.WriteLine("\n\n    Теперь список дней рождения выглядит вот так:\n");
                            All_list_to_the_screen();
                        }
                    }

                    else if (choice == ConsoleKey.D5)   //     сохранить список в файл    ******* 5 *******
                    {
                        using StreamWriter WriteRem = File.CreateText("Birthday List.txt");

                        for (int i = 0; i < ListOfBIRTH.Count; i++)
                        {
                            WriteRem.WriteLine(ListOfBIRTH[i].Name);
                            WriteRem.WriteLine(ListOfBIRTH[i].DATA);
                        }
                        Console.WriteLine("\n\n   Список записан в файл. \n");
                    }

                    
                    else if (choice == ConsoleKey.D6)   //     загрузка списка из файла      ******* 6 *******
                    {
                        try   // проверка возможности открытия файла
                        {
                            StreamReader ReadRem = File.OpenText("Birthday List.txt");
                            Console.WriteLine("\n\n  Список дней рождения, загруженных из файла:\n ");
                            sch = 0;
                            string st;
                            if (ListOfBIRTH.Count != 0) ListOfBIRTH.Clear(); // очистка списка в памяти, если он не пуст
                            while (true) // заполнение списка из файла построчно до конца файла
                            {
                                st = ReadRem.ReadLine();
                                if (st == null & sch == 0)
                                { Console.WriteLine("        Файл пуст..."); Console.ReadLine(); break; }
                                if (st == null) break;

                                string name;
                                DateTime data;
                                
                                name = st;
                                st = ReadRem.ReadLine();
                                
                                data = DateTime.Parse(st);

                                ListOfBIRTH.Add(new BIRTH() { Name = name, DATA = data });
                                ListOfBIRTHSorting.Add(new BIRTH() { Name = name, DATA = data });
                                sch++;
                            }
                            ReadRem.Close();
                            All_list_to_the_screen();
                        }
                        catch (IOException e)   // обработка исключения, вывод сообщения об ошибке
                        {
                            Console.WriteLine("\n   Файл не может быть прочитан\n");
                            Console.WriteLine(e.Message);
                        }
                    }
//===================================================================================================================================================
                    else if (choice == ConsoleKey.D7)   //     сортировать список в памяти    ******* 7 *******
                    {
                        Sorting();
                        
                    }



                    //обработка ввода
                    while (choice != ConsoleKey.Y && choice != ConsoleKey.N && (choice != ConsoleKey.Escape))
                    {
                        Console.Write("\n   Продолжить? Y/N  ");
                        choice = Console.ReadKey().Key;
                        if (choice != ConsoleKey.Y && choice != ConsoleKey.N && (choice != ConsoleKey.Escape))
                            Console.WriteLine("\n\n   Ошибка при вводе (вводите только Y,N или Esc) ");
                    }
                    Console.Clear();
                }
                while (choice == ConsoleKey.Y);

                if (choice == ConsoleKey.N)

                    break;

            }
            while (choice != ConsoleKey.Escape);
            
        }
    }
}