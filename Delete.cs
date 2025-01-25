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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        private void btn_delete_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-55ESB8E;Initial Catalog=NIBM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Student where Student_ID =  '" + txt_id.Text + "' ";
            cmd.ExecuteNonQuery();
            con.Close();


            if (txt_id.Text.Length == 0)
            {
                MessageBox.Show("Student Id cannot be blank", "ERROR", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }

            else
            {
                MessageBox.Show("Successfully Deleted", "Info", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
        }

        private void btn_cls_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
