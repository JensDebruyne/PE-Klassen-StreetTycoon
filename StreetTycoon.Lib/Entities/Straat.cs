using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetTycoon.Lib.Services;

namespace StreetTycoon.Lib.Entities
{

    public class Straat
    {
        static Random random = new Random();

        public int Id { get; set; }

        private string naam;

        public string Naam
        {
            get { return naam; }
            
            set 
            {
                if (value.Trim().Length >= 3) naam = value;
                else throw new Exception("De naam moet minstens 3 tekens lang zijn.");
            }
        }

        
        private decimal prijs;

        public decimal Prijs
        {
            get { return prijs; }
            set
            {
                if (value < 100) throw new Exception("De waarde van een straat moet minstens 100 zijn");
                else prijs = value; 
            }
        }

        public Steden Stad { get; set; }

        public Speler Eigenaar { get; set; }

        static int AantalStraten { get; set; } 

        public Straat(Steden stad, string naam)
        {
            Id = ++AantalStraten;
            Stad = stad;
            Naam = naam;
            Prijs = BepaalPrijs();
        }

        public Straat(string naam, decimal prijs) : this(Steden.Brugge, naam)
        {
            Stad = (Steden)random.Next(0, 3);
            Prijs = prijs;
        }

        decimal BepaalPrijs()
        {
            decimal prijs;
            int hondertal = random.Next(2, 6);
            prijs = hondertal * 100;
            return prijs;
        }

        public override string ToString()
        {
            string info;

            if (Eigenaar == null)
            {
                info = $"{Naam} - {Stad.ToString()}:  € {Prijs}";
            }
            else
            {
                info = $"{Naam} - {Stad.ToString()}:  € {Prijs}\n";
                info += $"\tEigenaar: {Eigenaar.Naam}";
            }
            return info;
        }
    }
}
