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
    public partial class Form_book : Form {
        public struct Seat {
            public Button seat;
            public int row;
            public int col;
        }

        Seat[, ] btn_seat;
        LinkedList<Seat> selectSeat = new LinkedList<Seat>();
        Account current_user;

        int[,] seatMap;
        int seatCount = 0, seatMoney = 0;
        string selectFilm, selectTime, selectRound, selectNow;

        // Strore the directory of the current seat map and user booking records.
        string seatDirectory, userDirectory;

        public Form_book(Account current_user, string filmname) {
            InitializeComponent();

            // Load the current user.
            this.current_user = current_user;
            label_book_account_2.Text = current_user.name;

            // Set the local date and time.
            DateTime localdate = DateTime.Now;
            label_book_time.Text = localdate.ToShortDateString() + " " + localdate.ToLongTimeString();

            timer1_Tick(this, null);
            timer1.Interval = 1000;
            timer1.Enabled = true;

            // Reload user's selection.
            if (string.Compare(filmname, "功夫熊貓3", false) == 0) {
                comboBox_book_film.SelectedIndex = 0;
            }
            else if (string.Compare(filmname, "動物方城市", false) == 0) {
                comboBox_book_film.SelectedIndex = 1;
            }
            else if (string.Compare(filmname, "蝙蝠俠對超人：正義曙光", false) == 0) {
                comboBox_book_film.SelectedIndex = 2;
            }
            else if (string.Compare(filmname, "美國隊長3：英雄內戰", false) == 0) {
                comboBox_book_film.SelectedIndex = 3;
            }

            comboBox_book_time.SelectedIndex = 0;
            comboBox_book_round.SelectedIndex = 0;

            // Reload the seat map.
            Form_book_Load();
            seatMap = new int[7, 16];
            set_currentSeatMap();
        }

        private void Form_book_Load() {
            btn_seat = new Seat[7, 16];

            // Set the row and col.
            for (int i = 0; i < 7; ++i) {
                for (int j = 0; j < 16; ++j) {
                    btn_seat[i, j].row = i;
                    btn_seat[i, j].col = j;
                }
            }

            // Set the button.
            btn_seat[0, 0].seat = button_seat_1_01;
            btn_seat[0, 1].seat = button_seat_1_02;
            btn_seat[0, 2].seat = button_seat_1_03;
            btn_seat[0, 3].seat = button_seat_1_04;
            btn_seat[0, 4].seat = button_seat_1_05;
            btn_seat[0, 5].seat = button_seat_1_06;
            btn_seat[0, 6].seat = button_seat_1_07;
            btn_seat[0, 7].seat = button_seat_1_08;
            btn_seat[0, 8].seat = button_seat_1_09;
            btn_seat[0, 9].seat = button_seat_1_10;
            btn_seat[0, 10].seat = button_seat_1_11;
            btn_seat[0, 11].seat = button_seat_1_12;
            btn_seat[0, 12].seat = button_seat_1_13;
            btn_seat[0, 13].seat = button_seat_1_14;
            btn_seat[0, 14].seat = button_seat_1_15;
            btn_seat[0, 15].seat = button_seat_1_16;

            btn_seat[1, 0].seat = button_seat_2_01;
            btn_seat[1, 1].seat = button_seat_2_02;
            btn_seat[1, 2].seat = button_seat_2_03;
            btn_seat[1, 3].seat = button_seat_2_04;
            btn_seat[1, 4].seat = button_seat_2_05;
            btn_seat[1, 5].seat = button_seat_2_06;
            btn_seat[1, 6].seat = button_seat_2_07;
            btn_seat[1, 7].seat = button_seat_2_08;
            btn_seat[1, 8].seat = button_seat_2_09;
            btn_seat[1, 9].seat = button_seat_2_10;
            btn_seat[1, 10].seat = button_seat_2_11;
            btn_seat[1, 11].seat = button_seat_2_12;
            btn_seat[1, 12].seat = button_seat_2_13;
            btn_seat[1, 13].seat = button_seat_2_14;
            btn_seat[1, 14].seat = button_seat_2_15;
            btn_seat[1, 15].seat = button_seat_2_16;

            btn_seat[2, 0].seat = button_seat_3_01;
            btn_seat[2, 1].seat = button_seat_3_02;
            btn_seat[2, 2].seat = button_seat_3_03;
            btn_seat[2, 3].seat = button_seat_3_04;
            btn_seat[2, 4].seat = button_seat_3_05;
            btn_seat[2, 5].seat = button_seat_3_06;
            btn_seat[2, 6].seat = button_seat_3_07;
            btn_seat[2, 7].seat = button_seat_3_08;
            btn_seat[2, 8].seat = button_seat_3_09;
            btn_seat[2, 9].seat = button_seat_3_10;
            btn_seat[2, 10].seat = button_seat_3_11;
            btn_seat[2, 11].seat = button_seat_3_12;
            btn_seat[2, 12].seat = button_seat_3_13;
            btn_seat[2, 13].seat = button_seat_3_14;
            btn_seat[2, 14].seat = button_seat_3_15;
            btn_seat[2, 15].seat = button_seat_3_16;

            btn_seat[3, 0].seat = button_seat_4_01;
            btn_seat[3, 1].seat = button_seat_4_02;
            btn_seat[3, 2].seat = button_seat_4_03;
            btn_seat[3, 3].seat = button_seat_4_04;
            btn_seat[3, 4].seat = button_seat_4_05;
            btn_seat[3, 5].seat = button_seat_4_06;
            btn_seat[3, 6].seat = button_seat_4_07;
            btn_seat[3, 7].seat = button_seat_4_08;
            btn_seat[3, 8].seat = button_seat_4_09;
            btn_seat[3, 9].seat = button_seat_4_10;
            btn_seat[3, 10].seat = button_seat_4_11;
            btn_seat[3, 11].seat = button_seat_4_12;
            btn_seat[3, 12].seat = button_seat_4_13;
            btn_seat[3, 13].seat = button_seat_4_14;
            btn_seat[3, 14].seat = button_seat_4_15;
            btn_seat[3, 15].seat = button_seat_4_16;

            btn_seat[4, 0].seat = button_seat_5_01;
            btn_seat[4, 1].seat = button_seat_5_02;
            btn_seat[4, 2].seat = button_seat_5_03;
            btn_seat[4, 3].seat = button_seat_5_04;
            btn_seat[4, 4].seat = button_seat_5_05;
            btn_seat[4, 5].seat = button_seat_5_06;
            btn_seat[4, 6].seat = button_seat_5_07;
            btn_seat[4, 7].seat = button_seat_5_08;
            btn_seat[4, 8].seat = button_seat_5_09;
            btn_seat[4, 9].seat = button_seat_5_10;
            btn_seat[4, 10].seat = button_seat_5_11;
            btn_seat[4, 11].seat = button_seat_5_12;
            btn_seat[4, 12].seat = button_seat_5_13;
            btn_seat[4, 13].seat = button_seat_5_14;
            btn_seat[4, 14].seat = button_seat_5_15;
            btn_seat[4, 15].seat = button_seat_5_16;

            btn_seat[5, 0].seat = button_seat_6_01;
            btn_seat[5, 1].seat = button_seat_6_02;
            btn_seat[5, 2].seat = button_seat_6_03;
            btn_seat[5, 3].seat = button_seat_6_04;
            btn_seat[5, 4].seat = button_seat_6_05;
            btn_seat[5, 5].seat = button_seat_6_06;
            btn_seat[5, 6].seat = button_seat_6_07;
            btn_seat[5, 7].seat = button_seat_6_08;
            btn_seat[5, 8].seat = button_seat_6_09;
            btn_seat[5, 9].seat = button_seat_6_10;
            btn_seat[5, 10].seat = button_seat_6_11;
            btn_seat[5, 11].seat = button_seat_6_12;
            btn_seat[5, 12].seat = button_seat_6_13;
            btn_seat[5, 13].seat = button_seat_6_14;
            btn_seat[5, 14].seat = button_seat_6_15;
            btn_seat[5, 15].seat = button_seat_6_16;

            btn_seat[6, 0].seat = button_seat_7_01;
            btn_seat[6, 1].seat = button_seat_7_02;
            btn_seat[6, 2].seat = button_seat_7_03;
            btn_seat[6, 3].seat = button_seat_7_04;
            btn_seat[6, 4].seat = button_seat_7_05;
            btn_seat[6, 5].seat = button_seat_7_06;
            btn_seat[6, 6].seat = button_seat_7_07;
            btn_seat[6, 7].seat = button_seat_7_08;
            btn_seat[6, 8].seat = button_seat_7_09;
            btn_seat[6, 9].seat = button_seat_7_10;
            btn_seat[6, 10].seat = button_seat_7_11;
            btn_seat[6, 11].seat = button_seat_7_12;
            btn_seat[6, 12].seat = button_seat_7_13;
            btn_seat[6, 13].seat = button_seat_7_14;
            btn_seat[6, 14].seat = button_seat_7_15;
            btn_seat[6, 15].seat = button_seat_7_16;
        }

        /* Timer */
        private void timer1_Tick(object sender, EventArgs e) {
            DateTime localdate = DateTime.Now;
            label_book_time.Text = localdate.ToLongDateString() + " " + localdate.ToLongTimeString();
        }

        /* Set the current seat file. */
        private void set_currentSeatMap() {
            selectFilm = comboBox_book_film.Text;
            selectTime = comboBox_book_time.Text;
            selectRound = comboBox_book_round.Text;

            string path = "\\seat\\";

            // Set the selected film.
            switch (selectFilm) {
                case "功夫熊貓3 / KUNG FU PANDA 3":
                    path += "film_1\\";
                    break;
                case "動物方城市 / ZOOTOPIA":
                    path += "film_2\\";
                    break;
                case "蝙蝠俠對超人：正義曙光 / BATMAN V SUPERMAN: DAWN OF JUSTICE":
                    path += "film_3\\";
                    break;
                case "美國隊長3：英雄內戰 / CAPTAIN AMERICA: CIVIL WAR":
                    path += "film_4\\";
                    break;
            }

            // Set selected time.
            switch (selectTime) {
                case "2016/04/01 (五)":
                    path += "20160401\\";
                    break;
                case "2016/04/02 (六)":
                    path += "20160402\\";
                    break;
                case "2016/04/03 (日)":
                    path += "20160403\\";
                    break;
                case "2016/04/04 (一)":
                    path += "20160404\\";
                    break;
                case "2016/04/05 (二)":
                    path += "20160405\\";
                    break;
                case "2016/04/06 (三)":
                    path += "20160406\\";
                    break;
                case "2016/04/07 (四)":
                    path += "20160407\\";
                    break;
            }

            // Set selected round.
            switch (selectRound) {
                case "場次 - 09:00":
                    path += "0900.txt";
                    break;
                case "場次 - 13:00":
                    path += "1300.txt";
                    break;
                case "場次 - 16:00":
                    path += "1600.txt";
                    break;
                case "場次 - 19:00":
                    path += "1900.txt";
                    break;
                case "場次 - 22:00":
                    path += "2200.txt";
                    break;
            }

            // Set the directory.
            DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            seatDirectory = dir.Parent.Parent.FullName;
            userDirectory = seatDirectory + "\\user\\" + current_user.name + ".txt";
            seatDirectory += path;
            
            // Read the seat map.
            read_currentSeatMap();

            // Set the seat map.
            for (int i = 0; i < 7; ++i) {
                for (int j = 0; j < 16; ++j) {
                    if (seatMap[i, j] == 1) {
                        btn_seat[i, j].seat.BackColor = Color.DodgerBlue;
                        btn_seat[i, j].seat.Cursor = Cursors.Hand;
                        btn_seat[i, j].seat.Enabled = true;
                    }
                    else if (seatMap[i, j] == 0) {
                        btn_seat[i, j].seat.BackColor = Color.Gray;
                        btn_seat[i, j].seat.Cursor = Cursors.No;
                        btn_seat[i, j].seat.Enabled = false;
                    }
                    else if (seatMap[i, j] == -1) {
                        btn_seat[i, j].seat.BackColor = Color.Red;
                        btn_seat[i, j].seat.Cursor = Cursors.No;
                        btn_seat[i, j].seat.Enabled = false;
                    }
                }
            }
        }

        /* Read the current seat map. */
        private void read_currentSeatMap() {
            string seat = File.ReadAllText(seatDirectory);

            int r = 0, c = 0;
            foreach (var row in seat.Split('\n')) {
                c = 0;
                foreach (var col in row.Trim().Split(' ')) {
                    if (col.Trim() == "1")
                        seatMap[r, c] = 1;
                    else if (col.Trim() == "0")
                        seatMap[r, c] = 0;
                    else if (col.Trim() == "-1")
                        seatMap[r, c] = -1;
                    c += 1;
                }
                r += 1;
            }
        }
        
        /* Search current seat. */
        private void button_book_search_Click(object sender, EventArgs e) {
            Form_book_Load();
            for (int i = 0; i < 7; ++i) {
                for (int j = 0; j < 16; ++j)
                    btn_seat[i, j].seat.ForeColor = Color.DodgerBlue;
            }
            set_currentSeatMap();
        }

        /* Click the seat button. */
        private void button_seat_Click(object sender, EventArgs e) {
            Button button_seat = (Button)sender;

            if (string.Compare(button_seat.BackColor.Name, "DodgerBlue", false) == 0) {
                button_seat.BackColor = Color.Green;

                add_button_seat(get_button_seat(button_seat));
                seatCount += 1;
            }
            else if (string.Compare(button_seat.BackColor.Name, "Green", false) == 0) {
                button_seat.BackColor = Color.DodgerBlue;

                delete_button_seat(get_button_seat(button_seat));
                seatCount -= 1;
            }

            if (seatCount < 11)
                label_seat_count.ForeColor = Color.Green;
            else
                label_seat_count.ForeColor = Color.Red;

            label_seat_count.Text = "已選座位個數：" + seatCount;
        }

        /* Add the select seat. */
        private void add_button_seat(Seat select) {
            Seat seat_node = new Seat();
            seat_node.seat = select.seat;
            seat_node.row = select.row;
            seat_node.col = select.col;

            LinkedListNode<Seat> node = new LinkedListNode<Seat>(seat_node);
            selectSeat.AddLast(node);
        }

        /* Delete the select node. */
        private void delete_button_seat(Seat select) {
            LinkedListNode<Seat> head = selectSeat.First;

            while (head != null) {
                if (select.row == head.Value.row && select.col == head.Value.col) {
                    selectSeat.Remove(head);
                    break;
                }

                head = head.Next;
            }
        }

        /* Searcg the select node. */
        private string search_button_seat() {
            LinkedListNode<Seat> head = selectSeat.First;

            string seatNumber = "";
            while (head != null) {
                switch (head.Value.row) {
                    case 0:
                        seatNumber += "A";
                        break;
                    case 1:
                        seatNumber += "B";
                        break;
                    case 2:
                        seatNumber += "C";
                        break;
                    case 3:
                        seatNumber += "D";
                        break;
                    case 4:
                        seatNumber += "E";
                        break;
                    case 5:
                        seatNumber += "F";
                        break;
                    case 6:
                        seatNumber += "G";
                        break;
                }

                seatNumber += Convert.ToString(head.Value.col);

                if (head.Next != null)
                    seatNumber += ", ";

                head = head.Next;
            }

            return seatNumber;
        }

        /* Get the current select seat. */
        private Seat get_button_seat(Button button_seat) {
            Seat temp = new Seat();

            for (int i = 0; i < 7; ++i) {
                for (int j = 0; j < 16; ++j) {
                    if (btn_seat[i, j].seat == button_seat) {
                        temp = btn_seat[i, j];
                        break;
                    }
                }
            }

            return temp;
        }

        /* Tooltip */
        private void button_seat_MouseHover(object sender, EventArgs e) {
            Button btn_hover = (Button)sender;

            int visibleTime = 1000;
            ToolTip tooltip;

            if (string.Compare(btn_hover.BackColor.Name, "DodgerBlue", false) == 0) {
                // Tooltip
                tooltip = new ToolTip();
                tooltip.Show("此座位可以選取。", btn_hover, 0, -20, visibleTime);
            }
        }

        /* Send the booking result. */
        private void button_book_accept_Click(object sender, EventArgs e) {
            selectFilm = comboBox_book_film.Text;
            selectTime = comboBox_book_time.Text;
            selectRound = comboBox_book_round.Text;
            selectNow = label_book_time.Text;

            if (seatCount == 0) {
                MessageBox.Show("您尚未選取任何座位。", "訂票訊息", MessageBoxButtons.OK);
            }
            else if (seatCount > 10) {
                MessageBox.Show("您選取的座位已達人數上限。", "訂票訊息", MessageBoxButtons.OK);
            }
            else {
                DialogResult result = MessageBox.Show("您確定要完成訂票？", "訂票訊息", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes) {
                    // Hint.
                    MessageBox.Show("您訂的座位為：" + search_button_seat(), "訂票訊息", MessageBoxButtons.OK);

                    panel_book.Hide();

                    // Write back to current seat map.
                    write_currentSeatMap();

                    // Set the booking result.
                    if (selectFilm.Length > 40) {
                        label_result_film2.Font = new Font("微軟正黑體", 12);
                    }
                    label_result_film2.Text = selectFilm;

                    label_result_time2.Text = selectTime;
                    label_result_round2.Text = selectRound;
                    label_result_count2.Text = Convert.ToString(seatCount);
                    label_result_seat2.Text = search_button_seat();

                    seatMoney = seatCount * 290;
                    label_result_money2.Text = Convert.ToString(seatMoney);

                    // Update the user booking records.
                    update_currentBooking();

                    panel_result.Show();
                }
            }
        }

        /* Write back to the current seat map. */
        private void write_currentSeatMap() {
            StreamWriter sw = new StreamWriter(seatDirectory);

            // Update the current seat map.
            LinkedListNode<Seat> head = selectSeat.First;
            while (head != null) {
                seatMap[head.Value.row, head.Value.col] = -1;
                head = head.Next;
            }
            
            // Write back to current seat map.
            for (int i = 0; i < 7; ++i) {
                for (int j = 0; j < 16; ++j) {
                    sw.Write(seatMap[i, j].ToString() + " ");
                }
                sw.Write(Environment.NewLine);
            }

            sw.Close();
        }

        /* Update the user booking records. */
        private void update_currentBooking() {
            StreamWriter sw;

            // Chcek whether the file is exist.
            if (File.Exists(userDirectory)) {
                sw = File.AppendText(userDirectory);

                sw.WriteLine("--------------------");
                sw.WriteLine("訂票時間：" + selectNow);
                sw.WriteLine("電影名稱：" + selectFilm);
                sw.WriteLine("電影時間：" + selectTime);
                sw.WriteLine("電影場次：" + selectRound);
                sw.WriteLine("訂票張數：" + Convert.ToString(seatCount) + " 張");
                sw.WriteLine("訂票座位：" + search_button_seat());
                sw.WriteLine("需付金額：" + Convert.ToString(seatMoney) + " 元整");
            }
            else {
                FileStream fs = new FileStream(userDirectory, FileMode.CreateNew);
                sw = new StreamWriter(userDirectory);

                sw.WriteLine("--------------------");
                sw.WriteLine("訂票時間：" + selectNow);
                sw.WriteLine("電影名稱：" + selectFilm);
                sw.WriteLine("電影時間：" + selectTime);
                sw.WriteLine("電影場次：" + selectRound);
                sw.WriteLine("訂票張數：" + Convert.ToString(seatCount) + " 張");
                sw.WriteLine("訂票座位：" + search_button_seat());
                sw.WriteLine("需付金額：" + Convert.ToString(seatMoney) + " 元整");
            }

            sw.Close();
        }

        /* Cancel the booking result. */
        private void button_book_cancel_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("您確定要取消訂票？", "取消訂票", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                this.Close();
                Form_main form_main = new Form_main(current_user);
                form_main.Show();
            }
        }

        /* Continue */
        private void button_book_continue_Click(object sender, EventArgs e) {
            this.Hide();
            Form_main form_main = new Form_main(current_user);
            form_main.Show();
        }

        /* Logout */
        private void button_book_logout_Click(object sender, EventArgs e) {
            this.Close();
            Form_login form_login = new Form_login();
            form_login.Show();
        }
    }
}
