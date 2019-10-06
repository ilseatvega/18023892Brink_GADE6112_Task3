using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _18023892Brink_GADE6112_Task1
{
    class FactoryBuilding : Building
    {
        //variables specific to Resource Building
        int unitType;
        int speed = 5;
        int[] spawnPoint = new int[2];

        //random to be used throughout the class
        Random rnd = new Random();

        //constructor that receives parameteres for all the above class variables (except maxhealth)
        //setting the protected ints that were declared to the parameters of this ResourceBuilding method
        public FactoryBuilding(int xPos, int yPos, int health, int team, string symbol, string name, int unitType) : base(xPos, yPos, 200, team, "🏘️", "Unit Factory")
        {
            //this. to refer to the instance of the variable in this class
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
            this.name = name;
            this.unitType = unitType;
        }

        //overriding the abstract methods created in Building
        public override void Destruction()
        {

        }
        public override string ToString()
        {
            return symbol + " " + name + " " + symbol + "\n" + "\n" + "Factory Position: [" + X + "," + Y + "] " + "\n" + "Factory HP: " + Health + "\n"
                + "Unit Type: " + unitType + "\n" + "Production Speed: " + speed + "\n";
        }

        public Unit Spawn()
        {
            //random position for units (x value)
            int newX = spawnPoint[0];
                //random position for units(x value)
            int newY = spawnPoint[1];
            int tempAttack = 0;
            //switch to determine which attack strength will be used (using rnd to randomise the case)
            switch (rnd.Next(0, 4))
            {
                case 0: tempAttack = 5; break;
                case 1: tempAttack = 10; break;
                case 2: tempAttack = 15; break;
                case 3: tempAttack = 20; break;
            }
            //switch to determine which unit type will spawn (using rnd)
            switch (unitType)
                {
                    default: return new MeleeUnit(newX, newY, 120, 1, tempAttack, 1, team, "💂", false, "Soldier"); break;
                    case 0: return new MeleeUnit(newX, newY, 120, 1, tempAttack, 1, team, "💂", false, "Soldier"); break;
                    case 1: return new RangedUnit(newX, newY, 100, 1, tempAttack, 4, team, "🐎", false, "Archer"); break;
                }
        }
        public override void Save()
        {
            //saves file to a text file in bin --> debug
            FileStream savefile = new FileStream(Environment.CurrentDirectory + "/FactoryBuildingSave.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(savefile);

            writer.WriteLine(Team + "," + X + "," + Y + "," + Health + "," + maxHP + "," + unitType);
            Console.WriteLine("Saved!");
            writer.Close();
            savefile.Close();
        }

        //get accessor for production speed
        public int Speed { get { return speed; } }

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
