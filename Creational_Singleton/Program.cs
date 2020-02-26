using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call the Instance property as many times as we want
            //But object is going to be instantiated only once and shared for every other call
            var db = SingletonDataContainer.Instance;
            Console.WriteLine("Population in Washington, D.C.: " + db.GetPopulation("Washington, D.C."));
            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine("Population in London: " + db.GetPopulation("London"));

            Console.ReadLine();
        }
    }
}
