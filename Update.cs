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

namespace Student_Management_System
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {


                con = new SqlConnection("Data Source=DESKTOP-55ESB8E;Initial Catalog=NIBM;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand("update Student set Student_name = @Student_name , Student_address = @Student_address , Student_DOB = @Student_DOB ,  Student_age = @Student_age , Student_TP = @Student_TP WHERE Student_Id = @Student_Id ", con);
                cmd.Parameters.AddWithValue("Student_Id", txt_id.Text);
                cmd.Parameters.AddWithValue("Student_name", txt_name.Text);
                cmd.Parameters.AddWithValue("Student_address", txt_address.Text);
                cmd.Parameters.AddWithValue("Student_DOB", dob_picker.Value);
                cmd.Parameters.AddWithValue("Student_Age", txt_Age.Text);
                cmd.Parameters.AddWithValue("Student_TP", txt_tp.Text);




                cmd.ExecuteNonQuery();
                con.Close();






            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            if (txt_id.Text.Length == 0)
            {
                MessageBox.Show("Student Id cannot be blank", "ERROR", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }

            else if (txt_name.Text.Length == 0)
            {
                MessageBox.Show("Student Name cannot be blank", "ERROR", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }

            else if (txt_name.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Student Name cannot contain numbers", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

            else if (txt_address.Text.Length == 0)
            {
                MessageBox.Show("Student Address cannot be blank", "ERROR", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }



            else if (txt_tp.Text.Length == 0)
            {
                MessageBox.Show("Telephone Number cannot be blank", "ERROR", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }

            else if (txt_tp.Text.Length != 10 || txt_tp.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Telephone number must contain ten numbers only", "ERROR", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }


            else
            {
                MessageBox.Show("Successfully Updated", "Info", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
        }

        private void dob_picker_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Now.Year - dob_picker.Value.Year;
            txt_Age.Text = age.ToString();

            if (Convert.ToInt32(txt_Age.Text) < 17)
            {
                MessageBox.Show("Age must be more than 17", "ERROR", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cls_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_name.Clear();
            txt_address.Clear();
            txt_Age.Clear();
            txt_tp.Clear();
        }
    }
}
