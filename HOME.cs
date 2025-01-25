using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void btn_registration_Click(object sender, EventArgs e)
        {
            Registration obj = new Registration();
            obj.ShowDialog();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Update obj = new Update();
            obj.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Delete obj = new Delete();
            obj.ShowDialog();
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            Display obj = new Display();
            obj.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
