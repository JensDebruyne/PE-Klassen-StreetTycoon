using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetTycoon.Lib.Entities;
using TextFiles.Lib.Entities;
using TextFiles.Lib.Services;

namespace StreetTycoon.Lib.Services
{
    public class StratenBeheer
    {
        public static List<Straat> Straten { get; set; }

        public StratenBeheer()
        {
            LaadStraten();
        }

        void LaadStraten()
        {
            Straten = new List<Straat>
            {
                new Straat(Steden.Kortrijk , "Doorniksestraat"),
                new Straat(Steden.Brugge , "Gapaardstraat"),
                new Straat(Steden.Brugge , "Geldmuntstraat"),
                new Straat(Steden.Kortrijk , "Grote markt"),
                new Straat(Steden.Gent , "Kouter"),
                new Straat(Steden.Kortrijk , "Lange-Steenstraat"),
                new Straat(Steden.Brugge , "Noordzandstraat"),
                new Straat(Steden.Gent , "Savaanstraat"),
                new Straat(Steden.Kortrijk , "Schoorbakkestraat"),
                new Straat(Steden.Gent , "Sportstraat"),
                new Straat(Steden.Brugge , "Steenstraat"),
                new Straat(Steden.Gent , "Veldstraat")
            };
        }

        public static Straat Zoek(int teZoekenId)
        {
            Straat gezocht = null;
            foreach (Straat straat in Straten)
            {
                if (straat.Id == teZoekenId)
                {
                    gezocht = straat;
                }
            }
            return gezocht;
        }
    }
}
