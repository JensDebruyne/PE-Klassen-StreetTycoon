using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetTycoon.Lib.Services;

namespace StreetTycoon.Lib.Entities
{
    public class Speler
    {
        const decimal startBedrag = 1500M;
        
        public string Naam { get; set; }
        public decimal Saldo { get; set; }
        public int HuidigePositie { get; set; }

        public Straat HuidigeStraat { get; set; }

        public Speler(string naam, decimal saldo = startBedrag, int positie = -1)
        {
            Naam = naam;
            Saldo = saldo;
            HuidigePositie = positie;
        }

        public override string ToString()
        {
            return $"{Naam} - Positie {HuidigePositie + 1}";
        }

    }
}
