using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace American_Internationa_College
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();


            //ConnectionString:
            con.ConnectionString = "data source = localhost;database = AIC;integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("select * from LoginDB where UserName='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            

            if(dt.Rows.Count>0)
            {
                for(int i=0; i<dt.Rows.Count;i++)
                {
                    if(dt.Rows[i][0].ToString()== userName && dt.Rows[i][1].ToString()== password)
                    {
                        MessageBox.Show("You have logged in as " + dt.Rows[i][2].ToString());
                        if(dt.Rows[i][2].ToString()=="Admin")
                        {
                            this.Hide();
                            Admin admin = new Admin();
                            admin.Show();
                        }
                        if (dt.Rows[i][2].ToString() == "Principle")
                        {
                            this.Hide();
                            Principle principle = new Principle();
                            principle.Show();
                        }
                        if (dt.Rows[i][2].ToString() == "Teacher")
                        {
                            this.Hide();
                            Teacher tr = new Teacher();
                            tr.Show();
                        }
                        if (dt.Rows[i][2].ToString() == "Student")
                        {
                            this.Hide();
                            Student st = new Student();
                            st.Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

            }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            RegistrationForm rf = new RegistrationForm();
            this.Hide();
            rf.Show();
        }
    }
    }

