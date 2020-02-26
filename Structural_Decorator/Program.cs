using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Decorator
{
    class Program
    {
        static void Main()
        {
            //Create EcomomyCar instance
            ICar objCar = new EconomyCar();

            //Wrap EconomyCar instance with BasicAccessories
            CarAccessoriesDecorator objAccessoriesDecorator = new BasicAccessories(objCar);

            //Wrap EconomyCar instance with AdvancedAccessories instance
            objAccessoriesDecorator = new AdvancedAccessories(objAccessoriesDecorator);

            Console.Write("Car Details: " + objAccessoriesDecorator.GetDescription());
            Console.WriteLine("\n");
            Console.Write("Total Price: " + objAccessoriesDecorator.GetCost());

            Console.ReadLine();
        }

        //Component: defines INTERFACE of actual obj that needs functionality to be added dynamically to the concrete components
        public interface ICar
        {
            string GetDescription();
            double GetCost();
        }

        //Concrete Component 1: actual object in which the functionalities could be added dynamically
        public class EconomyCar : ICar
        {
            public string GetDescription()
            {
                return "Economy Car";
            }

            public double GetCost()
            {
                return 450000.0;
            }
        }

        //Concrete Component 2: actual object in which the functionalities could be added dynamically
        public class DeluxeCar : ICar
        {
            public string GetDescription()
            {
                return "Deluxe Car";
            }

            public double GetCost()
            {
                return 750000.0;
            }
        }

        //Concrete Component 3: actual object in which the functionalities could be added dynamically 
        public class LuxuryCar : ICar
        {
            public string GetDescription()
            {
                return "Luxury Car";
            }

            public double GetCost()
            {
                return 1000000.0;
            }
        }

        //Abstract Decorator: defines the INTERFACE for all the dynamic functionalities that can be added to the Concrete Component
        public abstract class CarAccessoriesDecorator : ICar
        {

            private ICar _car;

            public CarAccessoriesDecorator(ICar aCar)
            {
                this._car = aCar;
            }
            public virtual string GetDescription()
            {
                return this._car.GetDescription();
            }

            public virtual double GetCost()
            {
                return this._car.GetCost();
            }
        }

        //Concrete Decorator 1: first functionality that can be added to the Concrete Component   
        public class BasicAccessories : CarAccessoriesDecorator
        {
            public BasicAccessories(ICar aCar)
            : base(aCar)
            {

            }

            public override string GetDescription()
            {
                return base.GetDescription() + ", Basic Accessories Package";
            }

            public override double GetCost()
            {
                return base.GetCost() + 2000.0;
            }
        }

        //Concrete Decorator 2: second functionality that can be added to the Concrete Component   
        public class AdvancedAccessories : CarAccessoriesDecorator
        {
            public AdvancedAccessories(ICar aCar)
            : base(aCar)
            {

            }

            public override string GetDescription()
            {
                return base.GetDescription() + ", Advanced Accessories Package";
            }

            public override double GetCost()
            {
                return base.GetCost() + 10000.0;
            }
        }

        //Concrete Decorator 3: third functionality that can be added to the Concrete Component      
        public class SportsAccessories : CarAccessoriesDecorator
        {
            public SportsAccessories(ICar aCar)
            : base(aCar)
            {

            }

            public override string GetDescription()
            {
                return base.GetDescription() + ", Sports Accessories Package";
            }

            public override double GetCost()
            {
                return base.GetCost() + 15000.0;
            }
        }

    }
}
