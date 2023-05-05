using System;

namespace GameUnits
{
    public class Program
    {
        private static void Main()
        {
            // Create array with 3 units
            Unit[] units = new Unit[]
            {
                new MilitaryUnit(3, 10, 5),
                new MilitaryUnit(4, 5, 3),
                new SettlerUnit(),
            };
            foreach (Unit u in units)
            {
                Console.WriteLine(u);
            }
            // Unit 0 atack unit 1
            (units[0] as MilitaryUnit).Attack(units[1]);
            // Unit 0 atack unit 2
            (units[0] as MilitaryUnit).Attack(units[2]);

            foreach (Unit u in units)
            {
                Console.WriteLine(u);
            }
        }
    }
}