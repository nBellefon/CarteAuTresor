using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Model
{
    public class Point
    {
        public int AxeX { get; set; } 
        public int AxeY { get; set; }


        public string ToString()
        { 
            return "M - " + AxeX + " - " + AxeY;
        }
    }
}
