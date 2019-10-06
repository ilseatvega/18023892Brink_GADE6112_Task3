using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18023892Brink_GADE6112_Task1
{
    //base class Unit
    abstract class Unit
    {
        //declaring the field protected definitions
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected int team;
        protected string symbol;
        protected bool isAttack;
        protected string name;

        //constructor that receives parameteres for all the above class variables
        //setting the protected ints that were declared to the parameters of this Unit method
        public Unit(int xPos, int yPos, int health, int speed, int attack, int attackRange, int team, string symbol, bool isAttack, string name)
        {
            //this. to refer to the instance of the variable in this class
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.team = team;
            this.symbol = symbol;
            this.isAttack = isAttack;
            this.name = name;
        }
        
        //declaring public abstracts
        public abstract void Move(int direction);
        public abstract void Combat(Unit enemy);
        public abstract bool WithinRange(Unit enemy);
        public abstract Unit ClosestUnitPos(Unit[] units);
        public abstract void UnitDeath();
        public abstract string ToString();
        //the abstract Save() method
        public abstract void Save();


        //putting the accessors in the Unit class so I can get my map update to work
        public int X { get { return xPos; } set { xPos = value; } }

        public int Y { get { return yPos; } set { yPos = value; } }

        public int maxHP { get { return health; } }

        //gets health and sets it to call death if health is 0
        public int Health { get { return health; } set { if (value < 0) { health = 0; this.UnitDeath(); } else { health = value; } } }

        public int Attack { get { return attack; } set { attack = value; } }

        //didnt use set since the value has been set and wont change (see constructor base at the top)
        public int Speed { get { return speed; } }

        public int Range { get { return attackRange; } }

        public int Team { get { return team; } set { team = value; } }

        public string Symbol { get { return symbol; } }

        public bool isAttacking { get { return isAttack; } set { isAttack = value; } }

        public string Name { get { return name; } set { name = value; } }
    }
}
