using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star_Pathfinder
{
    internal class Tile
    {
        //automatically implemented properties with no 
            //accessor bodies
        //useful when property fetches and sets the field value
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }

        //lambda expression: indicates an expression-bodied member
        //create an anonymous funct
        public int CostDistance => Cost + Distance;

        public Tile ParentNode { get; set; }

        public void SetDistance(int locationX, int locationY)
        {
            this.Distance = Math.Abs(locationX - locationX) + Math.Abs(locationY - locationY);
        }
    }
}
