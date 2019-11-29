using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Assignment5
{
    //Mobile Object child class that creates and manages NPC objects
    class NPC : MobileObject
    {
        private float torsoLength;
        private float headHeight;
        private float legLength;
        private float armLength;
        private float mass;
        private float totalHeight;
        Random rnd = new Random();

        //NPC constructor
        public NPC(string name, int iD, float torsoLength, float headHeight, float legLength, float armLength, float mass) : base(name, iD)
        {
            if (torsoLength > 0)
            {
                this.torsoLength = torsoLength;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
            if (headHeight > 0)
            {
                this.headHeight = headHeight;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
            if (legLength > 0)
            {
                this.legLength = legLength;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
            if (armLength > 0)
            {
                this.armLength = armLength;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
            if (mass > 0)
            {
                this.mass = mass;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
                this.mass = 1;
            }

            this.Name = name;
            ID1 = iD;
            x = rnd.Next(1, 500);
            y = rnd.Next(1, 500);
            z = rnd.Next(1, 500);
            DFO = Convert.ToInt32(Math.Sqrt((x * x) + (y * y) + (z * z)));

            this.totalHeight = heightFinder(torsoLength, headHeight, legLength);
        }
        //Getters and setters for NPC attributes
        public float getTorsoLength()
        {
            return this.torsoLength;
        }
        public void setTorsoLength(float value)
        {
            if (value > 0)
            {
                this.torsoLength = value;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
        }

        public float getHeadHeight()
        {
            return this.headHeight;
        }
        public void setHeadHeight(float value)
        {
            if (value > 0)
            {
                this.headHeight = value;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
        }

        public float getLegLength()
        {
            return this.legLength;
        }
        public void setLegLength(float value)
        {
            if (value > 0)
            {
                this.legLength = value;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
        }

        public float getArmLength()
        {
            return this.armLength;
        }
        public void setArmLength(float value)
        {
            if (value > 0)
            {
                this.armLength = value;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
        }

        public float getMass()
        {
            return this.mass;
        }
        public void setMass(float value)
        {
            if (value > 0)
            {
                this.mass = value;
            }
            else
            {
                Console.Out.WriteLine("Error: Numerical values entered must be greater than 0.");
            }
        }

        public float TotalHeight { get => heightFinder(torsoLength, headHeight, legLength); }


        //Private method that calculates and returns the total height of the NPC as a float
        private float heightFinder(float torso, float head, float leg)
        {
            float height = (torso + head + leg);
            return height;
        }

        //Print method that overrides parent class method: prints out the information of the NPC object in question
        public override void printObject()
        {
            Console.Out.WriteLine("Name: " + Name + " ID: " + ID1 + " Torso Length: " + torsoLength + " Head Height: " + headHeight + " Leg Length: " + legLength + " Arm Length: " + armLength + " Mass: " + mass + " Total Height: " + totalHeight);
        }

    }
}
