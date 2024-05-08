using BoxModels;
using BoxModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxModels
{
    public class Stock
    {
        //Fields for max and min box in stock
        private int _maxInStock = 30;
        private int _minInStock = 5;  

       
      



        //saving to file
        public static void SaveToFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            string temp = Newtonsoft.Json.JsonConvert.SerializeObject(BinaryTree.root, settings);
            string path = @"C:\Users\Dor\Desktop\BoxesProj\DataBase\stock.txt";
            
            System.IO.File.WriteAllText(path, temp);
        }
           //deserialize file
        public static TreeNode LoadTree()

        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            string path = @"C:\Users\Dor\Desktop\BoxesProj\DataBase\Stock.txt";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                TreeNode items = JsonConvert.DeserializeObject<TreeNode>(json, settings);
                return items;
            }
            else return null;



        }



    }
}
