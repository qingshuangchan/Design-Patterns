using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioural_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CookingMethod cookMethod = new CookingMethod();

            Console.WriteLine("What food would you like to cook?");
            var food = Console.ReadLine();
            cookMethod.SetFood(food);

            Console.WriteLine("What cooking strategy would you like to use (1-3)?");
            int input = int.Parse(Console.ReadKey().KeyChar.ToString());

            switch (input)
            {
                case 1:
                    cookMethod.SetCookStrategy(new Grilling());
                    cookMethod.Cook();
                    break;

                case 2:
                    cookMethod.SetCookStrategy(new OvenBaking());
                    cookMethod.Cook();
                    break;

                case 3:
                    cookMethod.SetCookStrategy(new DeepFrying());
                    cookMethod.Cook();
                    break;

                default:
                    Console.WriteLine("Invalid Selection!");
                    break;
            }

            Console.ReadLine();
        }
    }

    //Strategy: defines an interface that is implemented by all supported strategy algorithms
    interface CookStrategy
    {
        void Cook(string food);
    }

    //Concrete Strategy class: implement the algorithm defined by the Strategy
    class Grilling : CookStrategy
    {
        public void Cook(string food)
        {
            Console.WriteLine("\nCooking " + food + " by grilling it.");
        }
    }

    //Concrete Strategy class: implement the algorithm defined by the Strategy
    class OvenBaking : CookStrategy
    {
        public void Cook(string food)
        {
            Console.WriteLine("\nCooking " + food + " by oven baking it.");
        }
    }

    //Concrete Strategy class: implement the algorithm defined by the Strategy
    class DeepFrying : CookStrategy
    {
        public void Cook(string food)
        {
            Console.WriteLine("\nCooking " + food + " by deep frying it");
        }
    }

    //Context class: maintains a reference to a Strategy object
    //Use that reference to call the algorithm defined by a particular Concrete Strategy
    class CookingMethod
    {
        private string Food;
        private CookStrategy _cookStrategy;

        public void SetCookStrategy(CookStrategy cookStrategy)
        {
            this._cookStrategy = cookStrategy;
        }

        public void SetFood(string name)
        {
            Food = name;
        }

        public void Cook()
        {
            _cookStrategy.Cook(Food);
            Console.WriteLine();
        }
    }
}
