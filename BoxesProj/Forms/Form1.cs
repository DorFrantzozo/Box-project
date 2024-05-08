using BoxesProj.Forms;
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

namespace BoxesProj
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            BinaryTree.GetBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockForm stockForm = new StockForm();
            stockForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FindBox findBox = new FindBox();
            findBox.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
