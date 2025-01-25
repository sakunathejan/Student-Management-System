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
    public partial class Registration : Form
    {
        public Registration()
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
                cmd = new SqlCommand("insert into Student values " +
                    "('" + txt_id.Text + "' , '" + txt_name.Text + "' " +
                    ", '" + txt_address.Text + "' , '" + dob_picker.Value + "' " +
                    ", '" + txt_Age.Text + "' , '" + txt_tp.Text + "') ", con);
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


            else if (txt_tp.Text.Length != 10 || txt_tp.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Telephone number must contain ten numbers only", "ERROR", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }

            else if (txt_id.Text.Length == 0)
            {
                MessageBox.Show("Telephone Number cannot be blank", "ERROR", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }

            else
            {
                MessageBox.Show("Successfully Registered", "Info", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }

        }

        private void btn_cls_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_name.Clear();
            txt_address.Clear();
            txt_Age.Clear();
            txt_tp.Clear();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
