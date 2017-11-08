using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CourseWork_VladislavSolovey {

    public partial class Form1 : Form {

        private Random random;
        private int firstValue = 0;             // Первое число
        private int secondValue = 0;            // Второе число
        public static int randomResult = 0;            // Результат рандома 
        

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                firstValue = Convert.ToInt32(textBox1.Text);
                secondValue = Convert.ToInt32(textBox2.Text);

                random = new Random();
                randomResult = random.Next(firstValue, secondValue);

                label3.Visible = true;
                label3.Text = randomResult.ToString();

            } catch (System.FormatException) {
                if (textBox1.Text == String.Empty || textBox2.Text == String.Empty)
                {
                    MessageBox.Show("Input Error, please input numbers, no symbols!");
                }

                MessageBox.Show("Not Correct Value");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("The first number can not be greater than the other");
            }
        }

        private void ConnecttoDB_button_Click(object sender, EventArgs e) {
            Form2 form = new Form2();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e) {
            Form3 form = new Form3();
            form.Show();
        }
        public static String getResult() {
            return randomResult.ToString();
        }
    }
}
