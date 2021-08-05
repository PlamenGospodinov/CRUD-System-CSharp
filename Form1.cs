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

        private async void Form1_Load(object sender, EventArgs e)
        {
            await PopGridView();
        }

        private async Task PopGridView()
        {
            using(var MyEntities = new MyModel())
            {
                dataGridView1.DataSource = await MyEntities.Details.ToListAsync<Detail>();
            }
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            MyDetails.FName = txtFName.Text;
            MyDetails.LName = txtLName.Text;
            MyDetails.Age = Convert.ToInt32(txtAge.Text);
            MyDetails.Address = txtAddress.Text;
            MyDetails.DOB = Convert.ToDateTime(dtDOB.Text);
            using(var myDbEntities = new MyModel())
            {
                myDbEntities.Details.Add(MyDetails);
                await myDbEntities.SaveChangesAsync();
            }
            MessageBox.Show("Information has been saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await PopGridView();
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            MyDetails.FName = txtFName.Text;
            MyDetails.LName = txtLName.Text;
            MyDetails.Age = Convert.ToInt32(txtAge.Text);
            MyDetails.Address = txtAddress.Text;
            MyDetails.DOB = Convert.ToDateTime(dtDOB.Text);
            using (var myDbEntities = new MyModel())
            {
                myDbEntities.Entry(MyDetails).State = System.Data.Entity.EntityState.Modified;
                await myDbEntities.SaveChangesAsync();
            }
            MessageBox.Show("Information has been updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await PopGridView();
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

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                using (var myDbEntities = new MyModel())
                {
                    var entry = myDbEntities.Entry(MyDetails);
                    if (entry.State == EntityState.Detached)
                    {
                        myDbEntities.Details.Attach(MyDetails);

                        myDbEntities.Details.Remove(MyDetails);
                        await myDbEntities.SaveChangesAsync();
                        await PopGridView();
                        ClearFields();

                    }
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

        private void dtDOB_ValueChanged(object sender, EventArgs e)
        {
            int dateDiff = DateTime.Now.Year - dtDOB.Value.Year;
            txtAge.Text = dateDiff.ToString();
        }

        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            await PopGridView();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
