using BoxModels;
using BoxModels.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BoxesProj.Forms
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
            LoadBoxesToList();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadBoxesToList()//Displays stock
        {
            listView1.Items.Clear();
            List<Box> boxList = BinaryTree.GetBoxes();
            foreach (Box box in boxList)
            {
                ListViewItem b = new ListViewItem(box.Height.ToString());

                b.SubItems.Add(box.Width.ToString());
                b.SubItems.Add(box.Amount.ToString());
                b.SubItems.Add(box.Age.ToString());
                listView1.Items.Add(b);
            }


        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBox addBox = new AddBox();
            addBox.Show();

        }

       
       
    }
}
