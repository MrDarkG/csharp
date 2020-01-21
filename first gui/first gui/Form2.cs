using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace first_gui
{
    public partial class Form2 : Form
    {
        public static bool DelButton = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) { 
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                Program.DeleteGroup(ID);
                this.Hide();
                var form2 = new Form2();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
                
                
            }
        }
        public void LoadUsers()
        {


            var list = Program.listusers();
            dataGridView2.DataSource = list;

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Action";
            deleteColumn.Text = "Make Admin";
            deleteColumn.Name = "Submit";
            deleteColumn.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(deleteColumn);



            var listAdmins = Program.listAdmin();
            dataGridView3.DataSource = listAdmins;

            DataGridViewButtonColumn deleteColumn1 = new DataGridViewButtonColumn();
            deleteColumn1.HeaderText = "Action";
            deleteColumn1.Text = "Remove Admin";
            deleteColumn1.Name = "Submit";
            deleteColumn1.UseColumnTextForButtonValue = true;
            dataGridView3.Columns.Add(deleteColumn1);
        }
        public void LoadData()
        {
            
            
            var list = Program.listgroup();
            dataGridView1.DataSource = list;

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Delete Column";
            deleteColumn.Text = "Delete";
            deleteColumn.Name = "btnDelete";
            deleteColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteColumn);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = Program.CreateGroup(NewGroup.Text);
            dataGridView1.Update();
            dataGridView1.Refresh();
            this.Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string name = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                Program.MakeUserAdmin(name);
                this.Hide();
                var form2 = new Form2();
                form2.Closed += (s, args) => this.Close();
                form2.Show();

            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string name = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                Program.RemoveUserAdmin(name);
                this.Hide();
                var form2 = new Form2();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }
    }
}
