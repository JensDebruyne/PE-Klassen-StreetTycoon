using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetTycoon.Lib.Entities;

namespace StreetTycoon.Lib.Services
{
    public class SpelerBeheer
    {
        public static List<Speler> Spelers { get; set; }

        public SpelerBeheer(string[] namen)
        {
            Spelers = new List<Speler>();
            MaakSpelers(namen);
        }

        static void MaakSpelers(string[] namen)
        {
            foreach (string naam in namen)
            {
                Speler speler = new Speler(naam);
                Spelers.Add(speler);
            }
        }

        public static int GeefSpelerIndex(Speler speler)
        {
            int index = -1;
            for (int i = 0; i < Spelers.Count; i++)
            {
                if (Spelers[i] == speler)
                {
                    index = i;
                }
            }
            return index;
        }

    }
}
