using System;

namespace GameUnits
{
    public class Program
    {
        private static void Main()
        {
             Unit[] units = new Unit[]
            {
                new MilitaryUnit(3, 10, 5),
                new MilitaryUnit(4, 5, 3),
                new SettlerUnit(),
                new SpyUnit(),
                new SpyUnit()
            };

            // Unidade 0 ataca unidade 4
            (units[0] as MilitaryUnit).Attack(units[4]);
            // Unidade 0 ataca unidade 2
            (units[0] as MilitaryUnit).Attack(units[2]);
            // Unidade 3 espia unidade 4
            (units[3] as SpyUnit).GetSecretInfo(units[4]);
            // Unidade 4 espia unidade 2
            (units[4] as SpyUnit).GetSecretInfo(units[2]);

            // "Imprimir" cada unidade
            // chamando implicitamente o método ToString() de cada uma delas
            foreach (Unit u in units)
            {
                Console.WriteLine(u);
            }
        }
    }
}