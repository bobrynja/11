using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        class wDate
        {
            private DateTime data;

            public wDate(string dt)
            {
                string[] n = dt.Split('.');
                data = new DateTime(Convert.ToInt32(n[2]), Convert.ToInt32(n[1]), Convert.ToInt32(n[0]));
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

                int month = data.Month + 1;
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

            
            public DateTime Data
            {
                set { data = value; }
                get { return data; }
            }

            
            public string IsLeap
            {
                get
                {
                    Boolean dt = DateTime.IsLeapYear(data.Year);
                    string res = "Нет";
                    if (dt) res = "Да";
                    return res;
                }
            }

        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                wDate date = new wDate(textBox1.Text);
                textBox2.Text = "Информация:" + Environment.NewLine;
                textBox2.Text += "Дата предыдущего дня: " + date.priviousDay() + Environment.NewLine;

                textBox2.Text += "Дата следующего дня: " + date.nextDay() + Environment.NewLine;
                textBox2.Text += "Количество дней до конца месяца: " + date.remainDays() + Environment.NewLine;
                textBox2.Text += "Текущая дата: " + date.Data.ToShortDateString() + Environment.NewLine;
                textBox2.Text += "Является ли год выскокосным? " + date.IsLeap + Environment.NewLine;
            }
            catch {MessageBox.Show("Некорректный ввод данных!!!"); }
        }

        
    }
}
