using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace _18023892Brink_GADE6112_Task1
{
    abstract class Building
    {
        //declaring the protected variables
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int team;
        protected string symbol;
        protected string name;

        //constructor that receives parameteres for all the above class variables (except maxhealth)
        //setting the protected ints that were declared to the parameters of this Building method
        public Building(int xPos, int yPos, int health, int team, string symbol, string name)
        {
            //this. to refer to the instance of the variable in this class
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
        }

        //the abstract methods that will later be overridden
        public abstract void Destruction();
        public abstract string ToString();
        //the abstract Save() method
        public abstract void Save();

        //get setters -  wouldnt work unless i put them in the Building class
        public int X { get { return xPos; } set { xPos = value; } }

        public int Y { get { return yPos; } set { yPos = value; } }

        public int maxHP { get { return health; } }

        //didnt use set since the value has been set and wont change (see constructor base at the top)
        public int Health { get { return health; } }

        public int Team { get { return team; } set { team = value; } }

        public string Symbol { get { return symbol; } }

        public string Name { get { return name; } set { name = value; } }
    }
}
