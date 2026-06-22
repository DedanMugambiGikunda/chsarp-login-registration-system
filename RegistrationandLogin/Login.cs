using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RegistrationandLogin
{
    public partial class Login : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Desktop\RegandLog\RegistrationandLogin\Database.mdf;Integrated Security=True");

            cn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
                {
                  

                   

                    cmd = new SqlCommand(
                    "select * from LoginTable where username='" + txtusername.Text +
                    "' and password='" + txtpassword.Text + "'",
                    cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        this.Hide();
                      
                    Home home = new Home();
                        home.ShowDialog();
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("No Account avilable with this username and password ", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
