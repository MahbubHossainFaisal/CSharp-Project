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
    public partial class RegistrationForm : Form
    {
        public static string gender;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string father = txtFather.Text;
            string mother = txtMother.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string sscresult = txtSSCResult.Text;
            string passingyear = txtPassingYear.Text;
            string email = txtEmail.Text;
            string cmbgroup = cmbGroup.Text;
            string cmbreligion = cmbReligion.Text;

            if (name == "" || father == "" || mother == "" || address == "" || phone == "" || sscresult == "" || passingyear =="" || email=="" ||gender=="" || cmbgroup=="" || cmbreligion=="")
            {
                MessageBox.Show("Please fillup the whole form properly");

            }
            else
            {
                SqlConnection con = new SqlConnection();

                //ConnectionString:
                con.ConnectionString = "data source = localhost;database = AIC;integrated security = SSPI";

                //Generating SQL Query
                string sql = "INSERT INTO Registration(Name,Father,Mother,DOB,Address,Phone,SSCResult,PassingYear,SSCGroup,Gender,Religion,Email) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11,@param12)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //Opening the connection:
                    con.Open();

                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = txtName.Text;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = txtFather.Text;
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = txtMother.Text;
                    cmd.Parameters.Add("@param4", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@param5", SqlDbType.NVarChar, 50).Value = txtAddress.Text;
                    cmd.Parameters.Add("@param6", SqlDbType.NVarChar, 50).Value = txtPhone.Text;
                    cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = txtSSCResult.Text;
                    cmd.Parameters.Add("@param8", SqlDbType.VarChar, 50).Value = txtPassingYear.Text;
                    cmd.Parameters.Add("@param9", SqlDbType.VarChar, 50).Value = cmbGroup.Text;
                    cmd.Parameters.Add("@param10", SqlDbType.VarChar, 50).Value = gender;
                    cmd.Parameters.Add("@param11", SqlDbType.VarChar, 50).Value = cmbReligion.Text;
                    cmd.Parameters.Add("@param12", SqlDbType.VarChar, 50).Value = txtEmail.Text;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Your information has been stored!Thank you");

                    //Disconnect
                    con.Close();
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
                
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }
    }
}
