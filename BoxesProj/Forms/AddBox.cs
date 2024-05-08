using BoxModels;
using BoxModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxesProj.Forms
{
    public partial class AddBox : Form
    {
        public AddBox()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockForm stockForm = new StockForm();
            stockForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int width = int.Parse(textBox1.Text);
            int height = int.Parse(textBox2.Text);
            int amount = int.Parse(textBox4.Text);
            HeightTree.AdditionlBoxes = amount;
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            BinaryTree.AddBox(width, height, amount);
           










            Stock.SaveToFile();
            this.Hide();
            StockForm stockForm = new StockForm();
            stockForm.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
