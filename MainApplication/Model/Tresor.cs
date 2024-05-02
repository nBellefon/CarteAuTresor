using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Model
{
    public class Tresor : Point
    {
        public int Quantite {  get; set; }


        public string ToString()
        {
            return "T - " + AxeX + " - " + AxeY+" - "+Quantite;
        }

    }
}
