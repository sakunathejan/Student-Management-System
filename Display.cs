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
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("Select * from Student", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            con.Close();
        }

        private void Display_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-55ESB8E;Initial Catalog=NIBM;Integrated Security=True");
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
