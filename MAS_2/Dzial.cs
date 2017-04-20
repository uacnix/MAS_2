using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2
{
    class Dzial
    {
        private static IDictionary<int,Dzial> ext = new Dictionary<int,Dzial>();
        public string nazwaDzialu { get; private set; }
        public Pracownik dyrektor{ get; private set; }
        public Dictionary<int, Pracownik> pracownicy;

        public int id { get; private set; }
        public Dzial(string nazwa, int id, Pracownik dyrektor)
        {
            ext.Add(id, this);
            this.nazwaDzialu = nazwa;
            this.id = id;
            pracownicy = new Dictionary<int, Pracownik>();
            dyrektor = dyrektor ?? null;
        }
#region binarna 1 do 1
        public void przypiszDyrektora(Pracownik dyrektor)
        {
            if (dyrektor.dyrektorDzialu == null)
            {
                this.dyrektor = dyrektor;
                dyrektor.mianujDyrektoremDzialu(this);
            }
            Console.WriteLine("Przypisano " + dyrektor + " jako dyrektora działu " + nazwaDzialu);
        }
        public void zwolnijDyrektora(Pracownik p)
        {
            this.dyrektor = null;
            p.zwolnijDyrektora();
        }
#endregion binarna 1 do 1
#region kwalifikowana
        public void dodajPracownika(Pracownik p)
        {
            if (pracownicy.ContainsKey(p.id))
            {
                Console.WriteLine("Pracownik już tu pracuje!");
                return;
            }
            pracownicy.Add(id, p);
            p.zatrudnijWDziale(this);
            Console.WriteLine("Dodano pracownika " + p + " do działu " + nazwaDzialu);
        }
        public void zwolnijPracownika(Pracownik p)
        {
            if (!pracownicy.Keys.Contains(p.id))
            {
                Console.WriteLine("Ten pracownik nie pracuje w tym dziale!");
                return;
            }
            pracownicy.Remove(p.id);
            p.zwolnijzDzialu();
        }
        public Pracownik getPracownikDzialu(int idPracownika)
        {
            if (pracownicy.ContainsKey(idPracownika))
                return pracownicy[idPracownika];
            throw new Exception("Pracownik o id: " + idPracownika + " nie jest pracownikiem tego działu!");
        }
#endregion kwalifikowana



        public static Dzial getDzial(int id)
        {
            if(ext.Keys.Contains(id))
                  return ext[id];
            throw new Exception("Nie ma działu o takim ID:" + id);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Dział " + nazwaDzialu + " IDDziału: " + id+" Pracownicy działu:\n");
            foreach(Pracownik p in pracownicy.Values)
            {
                sb.Append(p.ToString());
            }
            return sb.ToString();
        }
    }
}
