using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAL.CW04_01_human
{

    public class Human
    {

        private string _Name;
        public string Name
        {
            get
            {
                return this._Name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 2)
                {
                    return;
                }
                this._Name = value;
            }
        }

        private string _Gender;
        public string Gender
        {
            get
            {
                return this._Gender;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value != "M" && value != "F"))
                {
                    return;
                }
                this._Gender = value;
            }
        }

        private int _Age;
        public int Age
        {
            get
            {
                return this._Age;
            }
            set
            {
                this._Age = value;
            }
        }

        public Human(string name, string gender, int age)
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
        }

        public void SayHello()
        {
            Console.WriteLine("Hello, my name is " + this.Name + ", I am " + this.Age + " and " + this.Gender + ".");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Human Human01 = new Human("Bob", "M", 15);
            Human Human02 = new Human("Kate", "F", 20);

            Human01.SayHello();
            Human02.SayHello();

            Human01.Name = "Puh";
            Human02.Gender = "A";
            Human01.SayHello();

            Console.ReadLine();
        }
    }
}
