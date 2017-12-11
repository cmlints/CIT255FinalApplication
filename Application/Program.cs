using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGroomingShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //add test data the the data file
            InitializeDataFile.AddStartData();

            //instantiate the controller
            Controller appController = new Controller();
        }
    }
}
