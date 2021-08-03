using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
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
            using(var myDbEntities = new MyModel())
            {
                myDbEntities.Details.Add(MyDetails);
                myDbEntities.SaveChanges();
            }

            PopGridView();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            MyDetails.FName = txtFName.Text;
            MyDetails.LName = txtLName.Text;
            MyDetails.Age = Convert.ToInt32(txtAge.Text);
            MyDetails.Address = txtAddress.Text;
            MyDetails.DOB = Convert.ToDateTime(dtDOB.Text);
            using (var myDbEntities = new MyModel())
            {
                myDbEntities.Entry(MyDetails).State = System.Data.Entity.EntityState.Modified;
                myDbEntities.SaveChanges();
            }

            PopGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Index != -1)
            {
                MyDetails.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                using(var myDbEntities = new MyModel())
                {
                    MyDetails = myDbEntities.Details.Where(x => x.ID == MyDetails.ID).FirstOrDefault();
                    txtFName.Text = MyDetails.FName;
                    txtLName.Text = MyDetails.LName;
                    txtAge.Text = MyDetails.Age.ToString();
                    txtAddress.Text = MyDetails.Address;
                    dtDOB.Text = MyDetails.DOB.ToString();
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            using(var myDbEntities = new MyModel())
            {
                var entry = myDbEntities.Entry(MyDetails);
                if(entry.State == EntityState.Detached)
                {
                    myDbEntities.Details.Attach(MyDetails);
                
                    myDbEntities.Details.Remove(MyDetails);
                    myDbEntities.SaveChanges();
                    PopGridView();
                    ClearFields();
                }
            }
        }

        void ClearFields()
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            dtDOB.Text = DateTime.Now.ToString();
        }
    }
}
