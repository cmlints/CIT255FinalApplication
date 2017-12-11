using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGroomingShop
{
    public class AppEnum
    {
        public enum ManagerAction
        {
            None,
            ListAllPetsData,
            DisplayPetsData,
            DeletePetData,
            AddPetData,
            UpdatePetData,
            QueryPriceRange,
            Quit,
            DisplayAllPetsData
        }
    }
}
