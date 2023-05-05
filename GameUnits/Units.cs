using System;


namespace GameUnits
{
    /// <summary>
    /// class Unit, defines general properties for each extended Unit type
    /// </summary>
    public abstract class Unit
    {
        //variables
        public int movement;
        public virtual int Health { get; set; }
        public abstract float Cost { get; }

        //constructor Unit
        public Unit (int movement, int health)
        {
            this.movement = movement;
            Health = health;
        }
        
        //Move method
        public void Move()
        {
            Console.WriteLine("Movement: " + movement);
        }
        
        //ToString method
        public override string ToString()
        {
            return GetType().Name + ": HP=" + Health + " COST=" + Cost.ToString("0") + " ";
        }
    }

    /// <summary>
    /// class SettlerUnit, defines properties based on Unit properties plus
    /// specific properties for this type
    /// </summary>
    public class SettlerUnit : Unit
    {
        //variables
        public override float Cost => 5.0f;
        
        //constructor SettlerUnit, using values from Unit constructor
        public SettlerUnit() : base(1, 2)
        {
        }
    }

    /// <summary>
    /// class MilitaryUnit, defines properties based on Unit properties plus
    /// specific properties for this type
    /// </summary>
    public class MilitaryUnit : Unit
    {
        //variables
        public int AttackPower { get; }
        public int XP { get; private set; }
        public override int Health => base.Health + XP;
        public override float Cost => AttackPower + XP;
        
        //constructor MilitaryUnit, using values from Unit constructor
        public MilitaryUnit(int movement, int health, int attackPower) : base(movement, health)
        {
            AttackPower = attackPower;
            XP = 0;
        }

        //Attack method
        public void Attack(Unit u)
        {
            XP++;
            u.Health--;
        }

       //ToString method
        public override string ToString()
        {
            return base.ToString() + "AP=" + AttackPower + " XP=" + XP;
        }
    }
}