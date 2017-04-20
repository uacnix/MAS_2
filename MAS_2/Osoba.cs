using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2
{
    class Osoba
    {
        readonly string imie;
        readonly string nazwisko;
        readonly string _pesel;
        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public override string ToString()
        {
            return imie + " " + nazwisko;
        }

    }
}
