using System;


namespace GameUnits
{
    public abstract class Unit
    {
        public int movement;
        public virtual int Health { get; set; }
        public abstract float Cost { get; }

        public Unit (int movement, int health)
        {
            this.movement = movement;
            Health = health;
        }
        public void Move()
        {
            Console.WriteLine("Movement: " + movement);
        }
    }
    public class SettlerUnit : Unit
    {
        public override float Cost => 5.0f;
        public SettlerUnit() : base(1, 2)
        {
        }
    }
    public class MilitaryUnit : Unit
    {
        public int AttackPower { get; }
        public int XP { get; private set; }
        public override int Health => base.Health + XP;
        public override float Cost => AttackPower + XP;
        public MilitaryUnit(int attackPower, int xp, int movement, int health) : base(movement, health)
        {
            AttackPower = attackPower;
            XP = xp;
        }

        public void Attack(Unit u)
        {
            XP++;
            Health--;
        }
    }
}