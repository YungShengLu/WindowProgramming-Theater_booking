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
    public partial class Form_login : Form {
        LinkedList<Account> account = new LinkedList<Account>();
        Account current_user;
        string inputUsername, inputPassword;

        // Store the all users' accounts.
        string accountDirectory;

        public Form_login() {
            InitializeComponent();

            // Load all users' accounts.
            load_account();
        }

        /* Login */
        private void button_login_Click(object sender, EventArgs e) {
            inputUsername = textBox_login_user.Text;
            inputPassword = textBox_login_password.Text;

            if (check_account(inputUsername, inputPassword) == true) {
                this.Hide();
                Form_main form_main = new Form_main(current_user);
                form_main.Show();
            }
            else {
                MessageBox.Show("輸入的會員帳戶或密碼密碼錯誤。", "登入失敗", MessageBoxButtons.OK);
                label_login_message.Text = "輸入的會員帳戶或密碼密碼錯誤，請重新輸入。";
                label_login_message.ForeColor = Color.Red;
            }
        }

        /* Key event - textBox_login_email */
        private void textBox_login_user_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            int visibleTime = 1000;
            ToolTip tooltip;

            if (e.KeyChar > 64 && e.KeyChar < 91) {
                tooltip = new ToolTip();
                tooltip.Show("輸入為大寫字母，輸入完畢後，按下 Enter 鍵即可登入。", textBox_login_user, 0, -20, visibleTime);
            }
            else if (e.KeyChar > 96 && e.KeyChar < 123) {
                tooltip = new ToolTip();
                tooltip.Show("輸入為小寫字母，輸入完畢後，按下 Enter 鍵即可登入。", textBox_login_user, 0, -20, visibleTime);
            }

            if (e.KeyChar == (char)Keys.Enter) {
                inputUsername = textBox_login_user.Text;
                inputPassword = textBox_login_password.Text;

                if (check_account(inputUsername, inputPassword) == true) {
                    this.Hide();
                    Form_main form_main = new Form_main(current_user);
                    form_main.Show();
                }
                else {
                    MessageBox.Show("輸入的會員帳戶或密碼密碼錯誤。", "登入失敗", MessageBoxButtons.OK);
                    label_login_message.Text = "輸入的會員帳戶或密碼密碼錯誤，請重新輸入。";
                    label_login_message.ForeColor = Color.Red;
                }
            }
        }

        /* Key event - textBox_login_password */
        private void textBox_login_password_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            int visibleTime = 1000;
            ToolTip tooltip;

            if (e.KeyChar > 64 && e.KeyChar < 91) {
                tooltip = new ToolTip();
                tooltip.Show("輸入為大寫字母，輸入完畢後，按下 Enter 鍵即可登入。", textBox_login_user, 0, 30, visibleTime);
            }
            else if (e.KeyChar > 96 && e.KeyChar < 123) {
                tooltip = new ToolTip();
                tooltip.Show("輸入為小寫字母，輸入完畢後，按下 Enter 鍵即可登入。", textBox_login_user, 0, 30, visibleTime);
            }

            if (e.KeyChar == (char)Keys.Enter) {
                inputUsername = textBox_login_user.Text;
                inputPassword = textBox_login_password.Text;

                if (check_account(inputUsername, inputPassword) == true) {
                    this.Hide();
                    Form_main form_main = new Form_main(current_user);
                    form_main.Show();
                }
                else {
                    MessageBox.Show("輸入的會員帳戶或密碼密碼錯誤。", "登入失敗", MessageBoxButtons.OK);
                    label_login_message.Text = "輸入的會員帳戶或密碼密碼錯誤，請重新輸入。";
                    label_login_message.ForeColor = Color.Red;
                }
            }
        }

        /* Login */
        private void login_KeyPressEvent(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                // Tooltip
                int visibleTime = 1000;
                ToolTip tooltip = new ToolTip();
                tooltip.Show("輸入完畢後，按下 Enter 鍵即可登入。", textBox_login_user, -20, -20, visibleTime);

                inputUsername = textBox_login_user.Text;
                inputPassword = textBox_login_password.Text;

                if (check_account(inputUsername, inputPassword) == true) {
                    this.Hide();
                    Form_main form_main = new Form_main(current_user);
                    form_main.Show();
                }
                else {
                    MessageBox.Show("輸入電子信箱或密碼密碼錯誤。", "登入失敗", MessageBoxButtons.OK);
                    label_login_message.Text = "輸入電子信箱或密碼密碼錯誤，請重新輸入。";
                    label_login_message.ForeColor = Color.Red;
                }
            }
        }

        /* Load the user account. */
        private void load_account() {
            // Set the file directory.
            DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            accountDirectory = dir.Parent.Parent.FullName;
            accountDirectory += "\\user\\account.txt";

            // Read the account file.
            string user = File.ReadAllText(accountDirectory);
            string[] temp = new string[3];

            int r = 0, c = 0;
            foreach (var row in user.Split('\n')) {
                c = 0;
                foreach (var col in row.Trim().Split(' ')) {
                    temp[c] = col.Trim();
                    c += 1;
                }

                add_account(temp);
                r += 1;
            }
        }

        /* Check the user account. */
        private bool check_account(string username, string password) {
            bool isValid = false;

            // Check.
            LinkedListNode<Account> head = account.First;
            while (head != null) {
                if (string.Compare(head.Value.username, username, false) == 0 && string.Compare(head.Value.password, password, false) == 0) {
                    current_user.username = head.Value.username;
                    current_user.password = head.Value.password;
                    current_user.name = head.Value.name;

                    isValid = true;
                    break;
                }

                head = head.Next;
            }
            
            return isValid;
        }

        /* Add the account. */
        private void add_account(string[] current) {
            Account account_node = new Account();
            account_node.username = current[0];
            account_node.password = current[1];
            account_node.name = current[2];

            LinkedListNode<Account> node = new LinkedListNode<Account>(account_node);
            account.AddLast(node);
        }
    }
}
