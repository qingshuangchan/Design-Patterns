using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee AreaManager = new AreaManager();
            IEmployee D_1 = new Director_1();
            IEmployee D_2 = new Director_2();
            IEmployee CEO = new CEO();
            List<IEmployee> objEmployee = new List<IEmployee>();
            objEmployee.Add(AreaManager);
            objEmployee.Add(D_1);
            objEmployee.Add(D_2);
            objEmployee.Add(CEO);
            foreach (IEmployee O in objEmployee)
            {
                O.Designation();
            }
            Console.ReadLine();
        }
    }

    //IEmployee INTERFACE: root node (contain sub nodes/child nodes)
    interface IEmployee
    {
        void Designation();
    }

    //CEO: sub nodes/child nodes (contain leaf nodes)
    class CEO : IEmployee
    {
        public virtual void Designation()
        {
            Console.WriteLine("I am Zack. CEO of Company");
        }
    }

    //Director_1: sub nodes/child nodes (contain leaf nodes)
    class Director_1 : CEO, IEmployee
    {
        public override void Designation()
        {
            Console.WriteLine("I am Bob. My Boss is Zack");
        }
    }

    //Director_2: sub nodes/child nodes (contain leaf nodes)
    class Director_2 : CEO, IEmployee
    {
        public override void Designation()
        {
            Console.WriteLine("I am Charlie. My Boss is Zack");
        }
    }

    //Area Manager: leaf node (do not contain any elements)
    class AreaManager : Director_1, IEmployee
    {
        public new void Designation()
        {
            Console.WriteLine("I am Alan. My Boss is Bob");
        }
    }
}
