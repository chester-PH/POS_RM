using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace POS_RM
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        public class Log_IN_Info
        {
            // Private fields
            private string user;
            private string pass;

            public Log_IN_Info()
            {
                this.user = "";
                this.pass = "";
            }
            public Log_IN_Info(string user, string pass)
            {
                this.user = user;
                this.pass = pass;
            }

            public string User { 
                get { return user; }
                set { user = value; }
            }
            public string Pass {
                get { return pass; }
                set { pass = value; }
            }

        }

       
        

        
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string conString = "server=LocalHost; uid=root;pwd=password;database=db_pos_rm;";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            /*string query = "SELECT * FROM db_pos_rm.new_table;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;*/

            Log_IN_Info quer = new Log_IN_Info(
                UserNameTextBox.Text,
                PasswordTextBox.Text
                );

            string qury = "SELECT COUNT(*) FROM new_table WHERE username = @username AND password = @password";

            using (MySqlCommand cmd = new MySqlCommand(qury, con))
            {
                cmd.Parameters.AddWithValue("@username", quer.User);
                cmd.Parameters.AddWithValue("@password", quer.Pass);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    Console.WriteLine("Login successful!");
                    Form2 frm = new Form2();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Invalid Username or Passord");
                }


            }
        }
    }
}
