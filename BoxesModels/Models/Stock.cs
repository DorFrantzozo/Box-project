using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesModels.Models
{
    internal class Stock
    {
        //Fields for max and min box in stock
        private int _maxInStock = 30;
        private int _minInStock = 5;  

        

        //the stock of all the boxes
       public static List<Box> BoxStock = new List<Box>();

        //adds box to BoxStock
        public void AddBox(Box box)
        {
            for (int i = 0; i < BoxStock.Count; i++)
            {
                if (!BoxStock.Contains(box))
                {
                    if (box.Amount <= _maxInStock)
                        BoxStock.Add(box);
                    else if (box.Amount > _maxInStock)
                    {
                        int temp = box.Amount;
                        box.Amount = _maxInStock;
                        BoxStock.Add(box);
                        //add massagebox with this: You have a {temp - 30} boxes extra
                        throw new Exception($"There are excess boxes left{temp-30}");



                    }
                }
                else if (box.Width == BoxStock[i].Width && box.Height == BoxStock[i].Height)
                {
                    BoxStock[i].Amount += box.Amount;
                }
            }
            SaveToFile();
        }



        //saving to file
        public static void SaveToFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            //json saving part:
            string temp = Newtonsoft.Json.JsonConvert.SerializeObject(BoxStock, settings);
            string path = @"C:\Users\Dor\Desktop\BoxesProj\DataBase\Stock.txt";
            
            System.IO.File.WriteAllText(path, temp);
        }

    }
}
