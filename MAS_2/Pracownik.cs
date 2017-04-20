using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2
{
    class Pracownik : Osoba
    {
        private static IDictionary<int,Pracownik> ext = new Dictionary<int,Pracownik>();

        public Dzial miejscePracy { get; private set; }
        public Dzial dyrektorDzialu { get; private set; }
        public int id;
        public Pracownik(string imie, string nazwisko, int id) : base(imie, nazwisko)
        {
            ext.Add(id,this);
            this.id = id;
        }

#region binarna 1 do 1 w Dziale
        public void mianujDyrektoremDzialu(Dzial d)
        {
            if (d.dyrektor == null)
            {
                this.dyrektorDzialu = d;
                d.przypiszDyrektora(this);
            }
        }
        public void zwolnijDyrektora()
        {
            dyrektorDzialu = null;
        }
#endregion binarna 1 do 1 w Dziale
#region kwalifikowana w Dziale
        public void zatrudnijWDziale(Dzial d)
        {
            if (d == miejscePracy)
                return;
            miejscePracy = d;
            d.dodajPracownika(this);
        }
        // Czy dział tu jest wymagany? Czy skoro to jest 1-* to można to zrobić bez podawania argumentu?
        public void zwolnijzDzialu()
        {
            miejscePracy = null;
        }
        public Dzial getDzial()
        {
            return miejscePracy;
        }
#endregion kwalifikowana w Dziale




        public static Pracownik getPracownik(int id)
        {
            if (ext.Keys.Contains(id))
                return ext[id];
            throw new Exception("Nie znaleziono pracownika o id:" + id);
        }
        public override string ToString()
        {
            return base.ToString() + " ID: " + id;
        }
    }
    class Premia
    {

    }
}
