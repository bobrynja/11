using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        class wDate
        {
            private DateTime data;

            public wDate(string dt)
            {
                string[] n = dt.Split('.');
                data = new DateTime (Convert.ToInt32(n[2]), Convert.ToInt32(n[1]), Convert.ToInt32(n[0]));
            }
            public wDate()
            {
                data = new DateTime(2009, 01, 01);
            }
            public string priviousDay()
            {
                return data.AddDays(-1).ToShortDateString();
            }
            public string nextDay()
            {
                return data.AddDays(1).ToShortDateString();
            }
            public int remainDays()
            {

                int month = data.Month+1;
                int year = data.Year;
                if (month == 13)
                {
                    month = 1;
                    year = data.Year + 1;
                }
                
                DateTime border = new DateTime(year, month, 01);
                border = border.AddDays(-1);
                return border.Day - data.Day;
            }

            //Свойства:•	позволяющее установить или получить значение поле класса (доступно для чтения и записи)
            public DateTime Data
            {
                set { data = value; }
                get { return data; }
            }

            //позволяющее определить год высокосным (доступно только для чтения)
            public string IsLeap
            {
                get {
                    Boolean dt = DateTime.IsLeapYear(data.Year);
                    string res = "Нет";
                    if (dt) res = "Да";
                    return res;
                     }
            }

        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите дату в формает дд.мм.гггг: ");
                wDate date = new wDate(Console.ReadLine());

                Console.WriteLine("Дата предыдущего дня: {0}", date.priviousDay());

                Console.WriteLine("Дата следующего дня: {0}", date.nextDay());
                Console.WriteLine("Количество дней до конца месяца: {0}", date.remainDays());
                Console.WriteLine("Текущая дата: " + date.Data.ToShortDateString());
                Console.Write("Вы хотите изменить дату? ");
                string answer = Console.ReadLine();
                if (answer == "Да" || answer == "да")
                {
                    Console.Write("Введите дату в формате дд.мм.гггг: ");
                    string[] n = Console.ReadLine().Split('.');
                    DateTime newdate = new DateTime(Convert.ToInt32(n[2]), Convert.ToInt32(n[1]), Convert.ToInt32(n[0]));
                    date.Data = newdate;
                }


                Console.WriteLine("Является ли год выскокосным? {0}", date.IsLeap);
            }
            catch { Console.WriteLine("Некорректный ввод данных!!!"); }
                Console.ReadKey();


        }
    }
}
