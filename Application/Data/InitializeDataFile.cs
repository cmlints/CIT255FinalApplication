using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGroomingShop
{
    public class InitializeDataFile
    {
        public static void AddStartData()
        {
            List<PetData> petsData = new List<PetData>();
            //list starter data for pet grooming shop
            petsData.Add(new PetData() { ID = 1, PetOwnerName = "Sally Sue", PhoneNumber = "231-321-4567", PetName = "Sprinkles", PetType = "Dog", PetSize = "Small", PetBreed = "Shih Tzu", GroomingType = "Option 1: Bath - Haircut - Nail Trim", GroomerID = 1, Price = 45 });

            petsData.Add(new PetData() { ID = 2, PetOwnerName = "Bobby Joe", PhoneNumber = "231-651-5567", PetName = "Guss", PetType = "Dog", PetSize = "Large", PetBreed = "German Shaperd", GroomingType = "Option 3: Bath - Hair Brushed", GroomerID = 2, Price = 55 });

            petsData.Add(new PetData() { ID = 3, PetOwnerName = "Barbie Raedol", PhoneNumber = "231-321-4567", PetName = "Sparkie", PetType = "Dog", PetSize = "Medium", PetBreed = "Boarder Collie", GroomingType = "Option 3: Bath - Hair Brushed", GroomerID = 3, Price = 45 });

            petsData.Add(new PetData() { ID = 4, PetOwnerName = "Jake", PhoneNumber = "231-421-4667", PetName = "Blaze", PetType = "Dog", PetSize = "Large", PetBreed = "Pitbull", GroomingType = "Option 6: Bath - Nail Trim", GroomerID = 1, Price = 55 });

            petsData.Add(new PetData() { ID = 5, PetOwnerName = "Ella", PhoneNumber = "231-871-8657", PetName = "Elmo", PetType = "Dog", PetSize = "Large", PetBreed = "Lab", GroomingType = "Option 1: Bath - Haircut - Nail Trim", GroomerID = 2, Price = 65 });

            petsData.Add(new PetData() { ID = 6, PetOwnerName = "Rae Bull", PhoneNumber = "231-320-4007", PetName = "Dusty", PetType = "Dog", PetSize = "Small", PetBreed = "Yorki", GroomingType = "Option 1: Bath - Haircut - Nail Trim", GroomerID = 3, Price = 45 });

            petsData.Add(new PetData() { ID = 7, PetOwnerName = "Kayden Right", PhoneNumber = "231-541-9067", PetName = "Gizmo", PetType = "Dog", PetSize = "Small", PetBreed = "Shih Tzu", GroomingType = "Option 1: Bath - Haircut - Nail Trim", GroomerID = 3, Price = 45 });

            petsData.Add(new PetData() { ID = 8, PetOwnerName = "Luke", PhoneNumber = "231-320-9987", PetName = "BayMax", PetType = "Dog", PetSize = "Medium", PetBreed = "Boxer", GroomingType = "Option 6: Bath - Nail Trim", GroomerID = 2, Price = 45 });

            petsData.Add(new PetData() { ID = 9, PetOwnerName = "Sally Sue", PhoneNumber = "231-321-3345", PetName = "Sprinkles", PetType = "Dog", PetSize = "Large", PetBreed = "Poodle", GroomingType = "Option 1: Bath - Haircut - Nail Trim", GroomerID = 2, Price = 65 });

            petsData.Add(new PetData() { ID = 10, PetOwnerName = "Bae Rox", PhoneNumber = "231-321-0089", PetName = "Rockie", PetType = "Dog", PetSize = "Small", PetBreed = "Shih Tzu", GroomingType = "Option 1: Bath - Haircut - Nail Trim", GroomerID = 1, Price = 45 });

            WriteAllPetsData(petsData, DataSettings.dataFilePath);
        }
        ///<summary>method to write all pets data info to the data file</summary>
        public static void WriteAllPetsData(List<PetData> petsData, string dataFilePath)
        {
            string petsDataString;

            List<string> petDataStringList = new List<string>();

            //build the list to write the text file line by line 
            foreach (var petData in petsData)
            {
                petsDataString =
                    petData.ID + "," +

                    petData.PetOwnerName + "," +
                    
                    petData.PhoneNumber + "," +
                    
                    petData.PetName + "," +
                    
                    petData.PetType + "," +
                    
                    petData.PetSize + "," +
                    
                    petData.PetBreed + "," +
                    
                    petData.GroomingType + "," +
                    
                    petData.GroomerID + "," +
                    
                    petData.Price;
                petDataStringList.Add(petsDataString);
            }

            // initialize a FileStream object for writing
            FileStream wfileStream = File.OpenWrite(DataSettings.dataFilePath);

            // wrap the FieldStream object in a using statement to ensure of the dispose
            using (wfileStream)
            {
                // wrap the FileStream object in a StreamWriter object to simplify writing strings
                StreamWriter sWriter = new StreamWriter(wfileStream);

                // write each line to the data file
                foreach (string petData in petDataStringList)
                {
                    sWriter.WriteLine(petData);
                }

                // be sure to close the StreamWriter object
                sWriter.Close();
            }
        }
    }
}
