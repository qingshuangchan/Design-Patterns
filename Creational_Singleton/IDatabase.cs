using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Singleton
{
    //Create a single interface
    public interface IDatabase
    {
        int GetPopulation(string name);
    }
}
