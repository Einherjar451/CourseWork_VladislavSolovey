using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;

namespace CourseWork_VladislavSolovey {

    public partial class Form3 : Form {
        private const string DATABASE_NAME = @"C:\dir\VladislaDB.sqlite3";    // Путь к созданию базы данных
        private SQLiteConnection connect;                               // Переменная соединения          
        private SQLiteDataReader reader;                                // Переменная Считывание данных с таблицы
        private SQLiteCommand command;                                  // Переменная команд к бд

        public Form3() {
            InitializeComponent();
        }
        public void dbProcess() {
            connect = new SQLiteConnection(string.Format("Data Source={0};", DATABASE_NAME));   // открываем соединение к бд
            connect.Open(); // открываем и соединяемся

            try
            {
                String id = textBox1.Text;
                command = new SQLiteCommand("SELECT * FROM 'randoms' WHERE id='" + id + "';", connect);
                reader = command.ExecuteReader();


                foreach (DbDataRecord record in reader)
                {
                    String id2 = record["id"].ToString();

                    if (id.Equals(id2))
                    {
                        String randval = record["number"].ToString();
                        String name = record["name"].ToString();

                        label3.Text = randval;
                        label5.Text = name;
                        label3.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("No results!");
                        break;
                    }
                }
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Input ID!");
            }

            connect.Close();        // закрываем соединение с бд
        }
        private void button1_Click(object sender, EventArgs e) {
            dbProcess();
        }
    }
}
