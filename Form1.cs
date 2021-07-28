using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD.Entities;

namespace CRUD
{
    public partial class Form1 : Form
    {
        Detail MyDetails = new Detail();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopGridView();
        }

        private void PopGridView()
        {
            using(var MyEntities = new MyModel())
            {
                dataGridView1.DataSource = MyEntities.Details.ToList<Detail>();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            MyDetails.FName = txtFName.Text;
            MyDetails.LName = txtLName.Text;
            MyDetails.Age = Convert.ToInt32(txtAge.Text);
            MyDetails.Address = txtAddress.Text;
            MyDetails.DOB = Convert.ToDateTime(dtDOB.Text);
        }
    }
}
