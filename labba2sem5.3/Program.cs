
using System;
using System.IO;
namespace labba2sem5._3
{
    public class Doctor
    {
        private string _surename;
        private string _profession;

        public string Surename
        {
            get => _surename;
            set => _surename = value;
        }

        public string Profession
        {
            get => _profession;
            set => _profession = value;
        }

        public virtual string UkrainianI(string str)
        {
            char[] ch = str.ToCharArray();

            for (int i = 0; i < ch.Length; ++i)
            {
                if (ch[i] == '?')
                {
                    ch[i] = 'i';
                }
            }

            return new string(ch);
        }

        public Doctor()
        {
            _surename = "Не вказано.";
            _profession = "Не вказано.";
        }

        public Doctor(string surename, string profession)
        {
            Surename = UkrainianI(surename);
            Profession = UkrainianI(profession);
        }

        public virtual string Length()
        {
            return "Довжина прiзвища лiкаря: " + Surename.Length.ToString() + " символи.";
        }
    }
}


namespace labba2sem5._3
{
    class Reception : Doctor
    {
        private string _day;
        private string _shift;
        private int _visitorsCount;

        public string Day
        {
            get => _day;
            set => _day = value;
        }

        public string Shift
        {
            get => _shift;
            set => _shift = value;
        }

        public int VisitorsCount
        {
            get => _visitorsCount;
            set => _visitorsCount = value;
        }

        public Reception()
        {
            Surename = "Не вказано.";
            Profession = "Не вказано.";
            Day = "Не вказано.";
            Shift = "Не вказано.";
            VisitorsCount = 0;
        }
        public Reception(string surename, string profession, string day, string shift, int visitorsCount)
        {
            base.Surename = UkrainianI(surename);
            base.Profession = UkrainianI(profession);
            Day = UkrainianI(day);
            Shift = UkrainianI(shift);
            VisitorsCount = visitorsCount;
        }
    }
}





namespace labba2sem5._3
{
    class Work
    {
        public static void Add()
        {
            StreamWriter file = new StreamWriter(@"C:\Users\Laptop\Desktop\НУЛП\base.txt", true);

            Console.WriteLine("\nВведiть новi данi");

            Console.Write("Прiзище: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("Фах: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("День: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("Змiна: ");

            file.WriteLine(Console.ReadLine());

            Retry:
            Console.Write("Кiлькiсть вiдвiдувачiв: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Кiлькiсть вiдвiдувачiв має бути вказана лише числом!");

                goto Retry;
            }

            file.Close();

            Input.ReadBase();
        }

        public static void Remove()
        {
            Console.WriteLine();

            Output.Write();

            Console.Write("Порядковий номер запису для видалення: ");

            bool[] remove = new bool[Program.doctors.Length];

            for (int i = 0; i < remove.Length; ++i)
            {
                remove[i] = false;
            }

            try
            {
                remove[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter(@"C:\Users\Laptop\Desktop\НУЛП\base.txt");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (!remove[i])
                {
                    file.WriteLine(Program.doctors[i].Surename);
                    file.WriteLine(Program.doctors[i].Profession);
                    file.WriteLine(Program.doctors[i].Day);
                    file.WriteLine(Program.doctors[i].Shift);
                    file.WriteLine(Program.doctors[i].VisitorsCount);
                }
            }

            Console.Write("Видалено.\n");

            file.Close();

            Input.ReadBase();
        }

        public static void Edit()
        {
            Console.WriteLine();

            Output.Write();

            Console.Write("Порядковий номер запису для редагування: ");

            bool[] edit = new bool[Program.doctors.Length];

            for (int i = 0; i < edit.Length; ++i)
            {
                edit[i] = false;
            }

            try
            {
                edit[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter(@"C:\Users\Laptop\Desktop\НУЛП\base.txt");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (edit[i])
                {
                    Console.WriteLine("Введiть новi данi");

                    Console.Write("Прiзище: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("Фах: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("День: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("Змiна: ");

                    file.WriteLine(Console.ReadLine());

                    Retry:
                    Console.Write("Кiлькiсть вiдвiдувачiв: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Кiлькiсть вiдвiдувачiв має бути вказана лише числом!");

                        goto Retry;
                    }
                }
                else
                {
                    file.WriteLine(Program.doctors[i].Surename);
                    file.WriteLine(Program.doctors[i].Profession);
                    file.WriteLine(Program.doctors[i].Day);
                    file.WriteLine(Program.doctors[i].Shift);
                    file.WriteLine(Program.doctors[i].VisitorsCount);
                }
            }

            Console.Write("Змiни внесено.\n");

            file.Close();

            Input.ReadBase();
        }

        public static void InitialiseBase(int n)
        {
            Program.doctors = new Reception[n];
        }

        public static void Sum()
        {
            int sum = 0;

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                sum += Program.doctors[i].VisitorsCount;
            }

            Console.WriteLine("\nЗагальна кiлькiсть вiдвiдувачiв: {0}.", sum);
        }

        public static void Minimum()
        {
            int minIndex = 0;

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (Program.doctors[minIndex].VisitorsCount >= Program.doctors[i].VisitorsCount)
                {
                    minIndex = i;
                }
            }

            Console.WriteLine("Загальна кiлькiсть вiдвiдувачiв:");
            Console.WriteLine(Output.Format, "Прiзище", "Фах", "День", "Змiна", "Кiлькiсть вiдвiдувачiв");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (Program.doctors[minIndex].VisitorsCount == Program.doctors[i].VisitorsCount)
                {
                    Console.WriteLine(Output.Format, Program.doctors[i].Surename, Program.doctors[i].Profession, Program.doctors[i].Day, Program.doctors[i].Shift, Program.doctors[i].VisitorsCount);
                }
            }
        }

        public static void Length()
        {
            Console.WriteLine();

            Output.Write();

            Console.Write("Порядковий номер запису для визначення довжини прiзвища лiкаря: ");

            try
            {
                Console.WriteLine(Program.doctors[int.Parse(Console.ReadLine())].Length());
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
            }
        }
    }
}



namespace labba2sem5._3
{
    class Input
    {
        public static void Read()
        {
            ReadBase();
            ReadKey();
        }

        public static void ReadBase()
        {
            StreamReader file = new StreamReader(@"C:\Users\Laptop\Desktop\НУЛП\base.txt");

            string[] tempStr = file.ReadToEnd().Split("|", StringSplitOptions.RemoveEmptyEntries);

            Program.doctors = new Reception[tempStr.Length / 5];

            for (int i = 0; i + 4 < tempStr.Length; i += 5)
            {
                Program.doctors[i / 5] = new Reception(tempStr[i], tempStr[i + 1], tempStr[i + 2], tempStr[i + 3], Convert.ToInt32(tempStr[i + 4]));
            }

            file.Close();
        }

        private static void ReadKey()
        {

            Start:

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Загальна кiлькiсть вiдвiдувачiв: A");
            Console.WriteLine("Прийом з мiнiмальною кiлькiстю вiдвiдувачiв: M");
            Console.WriteLine("Довжина прiзвища: L");
            Console.WriteLine("Вихiд: Esc");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.OemPlus:
                    Work.Add();
                    goto Start;

                case ConsoleKey.E:
                    Work.Edit();
                    goto Start;

                case ConsoleKey.A:
                    Work.Sum();
                    goto Start;

                case ConsoleKey.M:
                    Work.Minimum();
                    goto Start;

                case ConsoleKey.L:
                    Work.Length();
                    goto Start;

                case ConsoleKey.OemMinus:
                    Work.Remove();
                    goto Start;

                case ConsoleKey.Enter:
                    Output.Write();
                    goto Start;

                case ConsoleKey.Escape:
                    return;

                default:
                    Console.WriteLine();
                    goto Start;
            }
        }
    }
}



namespace labba2sem5._3
{
    class Output
    {
        public const string Format = "{0, -20} {1, -25} {2, -10} {3, -10} {4, -25}";

        public static void Write()
        {
            Console.WriteLine(Format, "Прiзище", "Фах", "День", "Змiна", "Кiлькiсть вiдвiдувачiв");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                Console.WriteLine(Format, Program.doctors[i].Surename, Program.doctors[i].Profession, Program.doctors[i].Day, Program.doctors[i].Shift, Program.doctors[i].VisitorsCount);
            }
        }
    }
}




namespace labba2sem5._3
{
    class Program
    {
        public static Reception[] doctors;

        static void Main(string[] args)
        {
            Input.Read();
        }
    }
}

