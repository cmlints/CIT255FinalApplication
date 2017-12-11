using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGroomingShop
{
    public class PetDataRepository : IDisposable
    {
        private List<PetData> _petsData;

        public object PetDataString { get; private set; }

        public PetDataRepository()
        {
            _petsData = ReadPetsData(DataSettings.dataFilePath);
        }

        /// <summary>
        /// method to read all pet data information from the data file and return it as a list of PetsData objects
        /// </summary>

        public static List<PetData> ReadPetsData(string dataFilePath)
        {
            const char delineator = ',';

            // create lists to hold the pet data strings and objects
            List<string> petDataStringList = new List<string>();
            List<PetData> petDataClassList = new List<PetData>();

            // initialize a StreamRader object for reading
            StreamReader sReader = new StreamReader(DataSettings.dataFilePath);

            using (sReader)
            {
                // keep reading lines of text until the end of the file is reached
                while (!sReader.EndOfStream)
                {
                    petDataStringList.Add(sReader.ReadLine());
                }
            }

            foreach (string petData in petDataStringList)
            {
                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = petData.Split(delineator);

                // populate the pet run list with PetsData objects
                petDataClassList.Add(new PetData()
                {
                    ID = Convert.ToInt32(properties[0]),
                    PetOwnerName = properties[1],
                    PhoneNumber = properties[2],
                    PetName = properties[3],
                    PetType = properties[4],
                    PetSize = properties[5],
                    PetBreed = properties[6],
                    GroomingType = properties[7],
                    GroomerID = Convert.ToInt32(properties[8]),
                    Price = Convert.ToInt32(properties[9]),
                });
            }

            return petDataClassList;
        }

        internal List<PetData> GetAllPetsDataInfo()
        {
            return _petsData;
        }

        /// <summary>
        /// method to write all of the list of pets data to the text file
        /// </summary>
        public void WritePetsData()
        {
            string petDataString;

            // create a StreamWriter object to access the data file
            StreamWriter sWriter = new StreamWriter(DataSettings.dataFilePath, false);

            using (sWriter)
            {
                foreach (PetData petData in _petsData)
                {
                    petDataString = petData.ID + "," + petData.PetName + "," + petData.Price;

                    sWriter.WriteLine(PetDataString);
                }
            }
        }

        /// <summary>
        /// method to add a new pet data
        /// </summary>

        public void InsertPetData(PetData petData)
        {
            _petsData.Add(petData);

            WritePetsData();
        }

        /// <summary>
        /// method to delete a pet data by pet data ID
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePetData(int ID)
        {
            _petsData.RemoveAll(pd => pd.ID == ID);

            WritePetsData();
        }

        /// <summary>
        /// method to update an existing pet data
        /// </summary>

        public void UpdatePetData(PetData petData)
        {
            //DeletePetData(petData.ID);
            InsertPetData(petData);

            WritePetsData();
        }

        internal List<PetData> QueryPetsDataInformation(int minimumPrice, int maximumPrice)
        {
            return _petsData;
        }

        /// <summary>
        /// method to return a pet data object given the ID
        /// </summary>

        public PetData GetPetDataByID(int ID)
        {
            PetData petData = null;

            petData = _petsData.FirstOrDefault(pd => pd.ID == ID);

            return petData;
        }

        /// <summary>
        /// method to return a list of pet data objects
        /// </summary>
        /// <returns>list of pet data objects</returns>
        public List<PetData> GetAllPetData()
        {
            return _petsData;
        }

        /// <summary>
        /// method to query the data by the price of each pet data
        /// </summary>

        public List<PetData> QueryByPrice(int minimumPrice, int maximumPrice)
        {
            List<PetData> matchingPetsData = new List<PetData>();

            //
            // use a lambda expression with the Where method to query
            //
            matchingPetsData = _petsData.Where(pd => pd.Price >= minimumPrice && pd.Price <= maximumPrice).ToList();

            return matchingPetsData;
        }

        /// <summary>
        /// method to handle the IDisposable interface contract
        /// </summary>
        public void Dispose()
        {
            _petsData = null;
        }
    }
}
