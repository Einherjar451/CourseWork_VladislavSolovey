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
    
    public partial class Form2 : Form {
        private const string DATABASE_NAME = @"C:\dir\VladislaDB.sqlite3";    // Путь к созданию базы данных
        private SQLiteConnection connect;                               // Переменная соединения          
        private SQLiteCommand command;                                  // Переменная команд к бд
        private Random rand = new Random();
        public static int id;
        private String number;
        private String name;

        public Form2() {
            InitializeComponent();

            String resultRandom_forDB = Form1.getResult();
            label5.Text = resultRandom_forDB;
        }
        public void dbProcess() { 
         try {
                id = rand.Next(0, 100000);
                number = label5.Text;
                name = textBox1.Text;

                connect = new SQLiteConnection(string.Format("Data Source={0};Version=3;New=False;Compress=True;", DATABASE_NAME));
                connect.Open();

                String sqliteCommand = "insert into 'randoms'(id, number, name) VALUES(" + id + ",'" + number + "','" + name + "');";

                command = new SQLiteCommand(sqliteCommand, connect);
                command.ExecuteNonQuery();
                connect.Close();

            } catch(SQLiteException) {
                MessageBox.Show("Error");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            dbProcess();
            label3.Text = id.ToString();

            label2.Visible = true;
            label3.Visible = true;
        }
    }
}
