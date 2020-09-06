using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleNoteTaker
{
    public partial class MyNotesForm : Form
    {
        public MyNotesForm()
        {
            InitializeComponent();
        }
        
       
        
        DataTable table; // Allows program to create an instance of a datatable(new instance created on form load)
        private void MyNotesForm_Load_1(object sender, EventArgs e)
        {
            // Creates new instance of a data table for us to use
            table = new DataTable();
            // Create 2 columns named "Title" and "Messages", both types of string
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));

            // Call dataGrid, set its DataSource to table
            dataGrid.DataSource = table;
            dataGrid.Columns["Messages"].Visible = false;
            dataGrid.Columns["Title"].Width = 131;
        }





        #region Buttons

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Clear();
            noteTextBox.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            table.Rows.Add(titleTextBox.Text, noteTextBox);
            titleTextBox.Clear();
            noteTextBox.Clear();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            int index = dataGrid.CurrentCell.RowIndex;

            

            if (index > -1)
            {
                titleTextBox.Text = table.Rows[index].ItemArray[0].ToString();
                noteTextBox.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int index = dataGrid.CurrentCell.RowIndex;
            if (index > -1)
            {
                table.Rows[index].Delete();
            }
        }
        #endregion
    }
}
