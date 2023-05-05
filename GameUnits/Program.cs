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
                new SpyUnit();
        }

            (units[0] as MilitaryUnit).Attack(units[4]);
            (units[0] as MilitaryUnit).Attack(units[2]);
            (units[3] as SpyUnit).GetSecretInfo(units[4]);
            (units[4] as SpyUnit).GetSecretInfo(units[2]);

            foreach (Unit u in units)
            {
                Console.WriteLine(u);
            }
        }
    }
}