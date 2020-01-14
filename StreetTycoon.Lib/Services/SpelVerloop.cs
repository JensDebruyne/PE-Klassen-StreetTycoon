using StreetTycoon.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetTycoon.Lib.Services
{

    public class SpelVerloop
    {
        private static readonly Random random = new Random();

        const int winnersAantal = 2;

        public Speler HuidigeSpeler { get; set; }

        public SpelVerloop()
        {
            SpelerBeheer spelerBeheer = new SpelerBeheer(new string[] { "Jan", "Piet" });
            StratenBeheer stratenBeheer = new StratenBeheer();
            HuidigeSpeler = SpelerBeheer.Spelers[0];
            HuidigeSpeler.HuidigeStraat = StratenBeheer.Straten[0];
        }

        public void GooidobbelSteen()
        {
            WisselHuidigeSpeler();
            WijzigPositie();
        }

        void WijzigPositie()
        {
            int vertrek, nieuwePositie, aantalPlaatsen;
            aantalPlaatsen = random.Next(1, 7);
            vertrek = HuidigeSpeler.HuidigePositie;

            nieuwePositie = vertrek + aantalPlaatsen;
            if (nieuwePositie >= StratenBeheer.Straten.Count)
            {
                nieuwePositie -= StratenBeheer.Straten.Count;
                HuidigeSpeler.Saldo += 200M;
            }
            HuidigeSpeler.HuidigePositie = nieuwePositie;
        }

        void WisselHuidigeSpeler()
        {
            int indexHuidigeSpeler = SpelerBeheer.GeefSpelerIndex(HuidigeSpeler);
            int nieuweIndex = indexHuidigeSpeler == SpelerBeheer.Spelers.Count - 1 ? 0 : indexHuidigeSpeler + 1;
            HuidigeSpeler = SpelerBeheer.Spelers[nieuweIndex];

        }

        public bool IsHuidigeStraatTeKoop()
        {
            bool teKoop;
            HuidigeSpeler.HuidigeStraat = StratenBeheer.Straten[HuidigeSpeler.HuidigePositie];
            teKoop = HuidigeSpeler.HuidigeStraat.Eigenaar == null ? true : false;
            return teKoop;
        }

        public bool KanSpelerDeHuidigeStraatKopen()
        {
            bool kanKopen;
            kanKopen = HuidigeSpeler.HuidigeStraat.Eigenaar == null 
                        &&  HuidigeSpeler.Saldo >= HuidigeSpeler.HuidigeStraat.Prijs
                        ? true 
                        : false;
            return kanKopen;
        }

        public void KoopStraat()
        {
            HuidigeSpeler.HuidigeStraat.Eigenaar = HuidigeSpeler;
            HuidigeSpeler.Saldo -= HuidigeSpeler.HuidigeStraat.Prijs;
        }

        public bool IsGameOver()
        {
            bool gameIsOver;
            int aantalStraten = 0;
            foreach (Straat straat in StratenBeheer.Straten)
            {
                if (straat.Eigenaar == HuidigeSpeler)
                {
                    aantalStraten++;
                }
            }
            gameIsOver = aantalStraten >= winnersAantal ? true : false;
            return gameIsOver;

        }
    }
}
