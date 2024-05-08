using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxModels
{
    public class Box
    {

        private double _width;
        private double _height;
        private int _amount;
        private DateTime _age;



        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
     
        public DateTime Age
        {
            get { return _age; }
            set { _age = value; }
        }
        //ctor
        public Box(double width, double height, int amount)
        {

            _width = width;
            _height = height;
            _amount = amount;
            _age = DateTime.Now;
        }
    }
}
