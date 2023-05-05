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
    public abstract class XPUnit : Unit
    {
        public abstract int XP { get; protected set; }
        public XPUnit() : base (movement, health)
        {
            XP = 0;
        }
        public override string ToString()
        {
            return base.ToString() + " XP=" + XP;
        }
    } 
    public class SpyUnit : XPUnit
    {
        protected override float Cost => 12.5f;
        private int movement { get; set; } = 8;
        private int health { get; set; } = 2;

        public void GetSecretInfo(Unit  u)
        {
            if (Unit == SpyUnit)
            {
                Cost += 3;
            }
            if (Unit == MilitaryUnit)
            {
                u.Cost += 2;
            }
            else
            {
                u.Cost += 1;
            }
        }
    }

}