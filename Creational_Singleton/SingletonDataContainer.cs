using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Singleton
{
    //Create a class to implement IDatabase interface
    public class SingletonDataContainer : IDatabase
    {
        //Dictionary to store capital names and their population from capitals.txt
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        //Private constructor
        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }

        //Thread-safe Creational_Singleton by using the Lazy type
        //Create instance of SingletonDataContainer class only when needed
        private static Lazy<SingletonDataContainer> instance = new Lazy<SingletonDataContainer>(() => new SingletonDataContainer());

        //Expose instance through the Instance property
        public static SingletonDataContainer Instance => instance.Value;
    }
}
