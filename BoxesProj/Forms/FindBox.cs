using BoxModels;
using BoxModels.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BoxesProj.Forms
{
    public partial class FindBox : Form
    {
        public FindBox()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox3.Text, out int userInput))
            {



                int width = int.Parse(textBox1.Text);
                int height = int.Parse(textBox2.Text);
                int amount = int.Parse(textBox4.Text);
                // Box ExactBox = BinaryTree.root.HeightTr.Boxes.FirstOrDefault(box => box.Width == width && box.Height == height);
                List<Box> suitableBoxes = BinaryTree.FindBoxes(width, height, amount);
                List<Box> filteredBoxes = DisplayBoxesWithoutDuplicates(suitableBoxes);
                DialogResult dialogResult = MessageBox.Show("Do you want this boxes? ", "Result", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("Thank you for your purchase");
                }
                else
                {
                    foreach (Box box in suitableBoxes)
                    {
                        BinaryTree.AddBox(box.Width, box.Height, 1);
                    }
                    MessageBox.Show("Thank you for visiting!");

                }

                Stock.SaveToFile();
            }




        }
        public static List<Box> DisplayBoxesWithoutDuplicates(List<Box> boxes)
        {
            List<Box> filteredBoxes = new List<Box>();
            string boxesString = "";
            int amount = boxes.Count;
            int countSame = 1;
            for (int i = 0; i < boxes.Count - 1; i++)
            {
                if (boxes[i].Width == boxes[i + 1].Width && boxes[i].Height == boxes[i + 1].Height)
                {
                    countSame++;
                }
                else
                {
                    boxesString += $"Width: {boxes[i].Width}, Height: {boxes[i].Height}, amount: {countSame}\n";
                    filteredBoxes.Add(boxes[i]);
                    amount -= countSame;
                    countSame = 1;
                }
            }
            if (amount > 0)
            {
                boxesString += $"Width: {boxes[boxes.Count - 1].Width}, Height: {boxes[boxes.Count - 1].Height}, amount: {countSame}\n";
                filteredBoxes.Add(boxes[boxes.Count - 1]);
            }
            MessageBox.Show(boxesString);
            return filteredBoxes;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void FindBox_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
