using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGroomingShop
{
    public class PetData
    {
        public int ID { get; set; }
        public String PetOwnerName { get; set; }
        public String PhoneNumber { get; set; }
        public String PetName { get; set; }
        public String PetType { get; set; }
        public String PetSize { get; set; }
        public String PetBreed { get; set; }
        public String GroomingType { get; set; }
        public int GroomerID { get; set; }
        public int Price { get; set; }

        public PetData()
        {

        }

        public PetData(int id, string petOwnerName, string phoneNumber, string petName, 
            string petType, string petSize, string petBreed, string groomingType, int groomerID, int price )
        {
            this.ID = id;
            this.PetOwnerName = PetOwnerName;
            this.PhoneNumber = phoneNumber;
            this.PetName = petName;
            this.PetType = petType;
            this.PetSize = petSize;
            this.PetBreed = petBreed;
            this.GroomingType = groomingType;
            this.GroomerID = groomerID;
            this.Price = price;

        }

    }
}
