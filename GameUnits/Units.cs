using System;


namespace GameUnits
{
    /// <summary>
    /// class Unit, defines general properties for each extended Unit type
    /// </summary>
    public abstract class Unit
    {
        //variable
        public int movement;
    
        //setters and getters
        public virtual int Health { get; set; }
        public abstract float Cost { get; }

        //constructor rUnit
        public Unit(int movement, int health)
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
    /// class MilitaryUnit, defines properties based on XPUnit properties plus
    /// specific properties for this type
    /// </summary>
    public abstract class MilitaryUnit : XPUnit
    {
        //variables
        public int AttackPower { get; }
        
        //setters and getters
        public override int Health => base.Health + XP;
        public override float Cost => AttackPower + XP;
        
        /*constructor MilitaryUnit, using values from Unit constructor plus 
        more properties*/
        public MilitaryUnit(int movement, int health, int attackPower) : base(movement, health)
        {
            AttackPower = attackPower;
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
            return base.ToString() + " AP=" + attackpower;
        }

    }

    /// <summary>
    /// class XPUnit, defines properties based on Unit properties plus
    /// specific properties for this type
    /// </summary>
    public abstract class XPUnit : Unit
    {
        //setters and getters
        public abstract int XP { get; protected set; }
        
        //constructor XPUnit, using values from Unit constructor
        public XPUnit() : base (movement, health)
        {
            XP = 0;
        }
    
        //ToString method
        public override string ToString()
        {
            return base.ToString() + " XP = " + XP;
        }
    }

    /// <summary>
    /// class SpyUnit, defines properties based on XPUnit properties plus
    /// specific properties for this type 
    /// </summary>
    public class SpyUnit : XPUnit
    {
        //variables
        protected override float Cost => 12.5f;
        //setters and getters
        private int movement { get; set; } = 8;
        private int health { get; set; } = 2;

        //GetSecretInfo method
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