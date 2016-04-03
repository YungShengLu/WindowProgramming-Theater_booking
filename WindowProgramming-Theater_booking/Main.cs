using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74039025_HW1 {
    public partial class Form_main : Form {
        PictureBox[] filmPicture;
        Account current_user;

        public Form_main(Account current_user) {
            InitializeComponent();

            // Set the local date and time.
            DateTime localdate = DateTime.Now;
            label_main_time.Text = localdate.ToShortDateString() + " " + localdate.ToLongTimeString();

            timer1_Tick(this, null);
            timer1.Interval = 1000;
            timer1.Enabled = true;
            
            // Load the user name.
            this.current_user = current_user;
            label_main_account_2.Text = current_user.name;
            label_main_member_name2.Text = current_user.name;
            label_main_member_email2.Text = current_user.username;

            // Load the user booking records.
            search();
        }

        private void Form_main_Load(object sender, EventArgs e) {
            // Set film buttons.
            filmPicture = new PictureBox[4];
            filmPicture[0] = pictureBox_main_film_1;
            filmPicture[1] = pictureBox_main_film_2;
            filmPicture[2] = pictureBox_main_film_3;
            filmPicture[3] = pictureBox_main_film_4;
        }

        /* Timer */
        private void timer1_Tick(object sender, EventArgs e) {
            DateTime localdate = DateTime.Now;
            label_main_time.Text = localdate.ToLongDateString() + " " + localdate.ToLongTimeString();
        }

        private void pictureBox_main_film_1_Click(object sender, EventArgs e) {
            this.Hide();
            Form_book form_book = new Form_book(current_user, label_main_film_ch1.Text);
            form_book.Show();
        }

        /* Film picture */
        private void pictureBox_main_film_2_Click(object sender, EventArgs e) {
            this.Hide();
            Form_book form_book = new Form_book(current_user, label_main_film_ch2.Text);
            form_book.Show();
        }

        private void pictureBox_main_film_3_Click(object sender, EventArgs e) {
            this.Hide();
            Form_book form_book = new Form_book(current_user, label_main_film_ch3.Text);
            form_book.Show();
        }
        
        private void pictureBox_main_film_4_Click(object sender, EventArgs e) {
            this.Hide();
            Form_book form_book = new Form_book(current_user, label_main_film_ch4.Text);
            form_book.Show();
        }

        /* Searching */
        private void search() {
            // Set the current user directory.
            DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            string userDirectory = dir.Parent.Parent.FullName + "\\user\\" + current_user.name + ".txt";

            StreamReader sr = new StreamReader(userDirectory);

            if (File.Exists(userDirectory)) {
                string line;

                textBox_search.Text += Environment.NewLine;
                while ((line = sr.ReadLine()) != null) {
                    textBox_search.Text += line + Environment.NewLine;
                }
            }
            else {
                textBox_search.Text = "無訂票紀錄。";
            }
        }

        /* Logout Button */
        private void button_main_logout_Click(object sender, EventArgs e) {
            this.Close();
            Form_login form_login = new Form_login();
            form_login.Show();
        }

        private void button_main_member_logout_Click(object sender, EventArgs e) {
            this.Close();
            Form_login form_login = new Form_login();
            form_login.Show();
        }
    }
}
