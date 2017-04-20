using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Pracownik p = new Pracownik("Jarowsław", "Psikuta", 1);
            Pracownik p1 = new Pracownik("Józef", "Stalin", 2);

            Console.WriteLine(p + "\n" + p1);


            Dzial wihajstry = new Dzial("wihajstry", 1, p);
            wihajstry.przypiszDyrektora(p1);
            p.zatrudnijWDziale(wihajstry);
            Console.Read();
        }
    }
}
