using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _18023892Brink_GADE6112_Task1
{
    class RangedUnit : Unit
    {
        //using a base constructor to access Unit's variables (properties must be accessed from RangedUnit which is why base is used)
        //health, speed, attackrange and symbol changed to fit the RangedUnit
        public RangedUnit(int xPos, int yPos, int health, int speed, int attack, int attackRange, int team, string symbol, bool isAttack, string name, int maxHP) : base(xPos, yPos, 100, 1, attack, 4, team, "🐎", isAttack, "Archer")
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

        //overrides the Unit class method Move() ... same for all the methods
        public override void Move(int direction)
        {
            switch (direction)
            {
                case 0: this.X = this.X + 1; break; //right
                case 1: this.X = this.X - 1; break; //left
                case 2: this.Y = this.Y + 1; break; //up
                case 3: this.Y = this.Y - 1; break; //down
            }

            //check bounds and reset character
            if (X <= 0)
            {
                X = 0;
            }
            else if (X >= 20)
            {
                X = 20;
            }

            if (Y <= 0)
            {
                Y = 0;
            }
            else if (Y >= 20)
            {
                Y = 20;
            }
        }
        public override void Combat(Unit enemy)
        {
            this.health = this.health - enemy.Attack;
            if (health <= 0)
            {
                UnitDeath();
            }
        }
        public override bool WithinRange(Unit enemy)
        {
            double distance = Math.Sqrt(Math.Pow(Math.Abs(enemy.X - this.X), 2) + Math.Pow(Math.Abs(enemy.Y - this.Y), 2));
            if (distance <= attackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override Unit ClosestUnitPos(Unit[] units)
        {
            double closestDist = Int32.MaxValue;
            int closestUnit = 0;
            //
            for (int j = 0; j < units.Length; j++)
            {
                //if units at j team is not equal to units at i team then...
                if (units[j].Team != this.Team)
                {
                    //using pyth to find the distance (c = square root(a^2 + b^2))
                    //math.abs = absolute value 
                    double distance = Math.Sqrt(Math.Pow(Math.Abs(units[j].X - this.X), 2) + (Math.Pow(Math.Abs(units[j].Y - this.Y), 2)));
                    if (distance < closestDist)
                    {
                        closestUnit = j;
                        closestDist = distance;
                    }
                }
            }
            return units[closestUnit];
        }
        public override void UnitDeath()
        {
            
        }
        public override string ToString()
        {
            //showing the unit symbol, position, health points and attack
            return symbol + " Ranged " + name + " " + symbol + "\n" + "\n" + "Unit Position: [" + X + "," + Y + "] " + "\n" + "Unit HP: " + Health + "\n" + "Unit Attack: " + Attack;
        }
        public override void Save()
        {
            //saves file to a text file in bin --> debug
            FileStream savefile = new FileStream(Environment.CurrentDirectory + "/RangedUnitSave.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(savefile);

            writer.WriteLine(Team + "," + X + "," + Y + "," + Health + "," + Attack);
            Console.WriteLine("Saved!");
            writer.Close();
            savefile.Close();
        }

        //creating the properties for this class using the variables from Unit and using getters / setters
        //set = when the value needs to be set to something (can be changed)
        //get = when a value needs to be gotten from the variable
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
