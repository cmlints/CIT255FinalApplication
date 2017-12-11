using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGroomingShop
{
    public class Controller
    {
        #region FIELDS

        bool active = true;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            ApplicationControl();
        }

        #endregion

        #region METHODS

        private void ApplicationControl()
        {
            PetDataRepository petDataRepository = new PetDataRepository();

            ConsoleView.DisplayWelcomeScreen();

            using (petDataRepository)
            {
                List<PetData> petsData = petDataRepository.GetAllPetsDataInfo();

                int petDataID;
                PetData petData;
                string message;

                while (active)
                {
                    AppEnum.ManagerAction userActionChoice;

                    userActionChoice = ConsoleView.GetUserActionChoice();

                    switch (userActionChoice)
                    {
                        case AppEnum.ManagerAction.None:
                            break;

                        case AppEnum.ManagerAction.ListAllPetsData:
                            ConsoleView.DisplayAllPetsData(petsData);

                            ConsoleView.DisplayContinuePrompt();
                            break;

                        case AppEnum.ManagerAction.DisplayPetsData:
                            petDataID = ConsoleView.GetPetDataID(petsData);
                            petData = petDataRepository.GetPetDataByID(petDataID);

                            ConsoleView.DisplayPetData(petData);
                            ConsoleView.DisplayContinuePrompt();
                            break;

                        case AppEnum.ManagerAction.AddPetData:
                            petData = ConsoleView.AddPetData();
                            petDataRepository.InsertPetData(petData);

                            ConsoleView.DisplayContinuePrompt();
                            break;

                        case AppEnum.ManagerAction.UpdatePetData:
                            petDataID = ConsoleView.GetPetDataID(petsData);
                            petData = petDataRepository.GetPetDataByID(petDataID);

                            ConsoleView.DisplayContinuePrompt();

                            petDataRepository.UpdatePetData(petData);
                            break;

                        case AppEnum.ManagerAction.DeletePetData:
                            petDataID = ConsoleView.GetPetDataID(petsData);
                            petDataRepository.DeletePetData(petDataID);

                            ConsoleView.DisplayReset();
                            message = String.Format("Pet Data ID: {0} had been deleted.", petDataID);
                            ConsoleView.DisplayMessage(message);
                            ConsoleView.DisplayContinuePrompt();
                            break;

                        case AppEnum.ManagerAction.QueryPriceRange:
                            List<PetData> matchingPetsData = new List<PetData>();

                            int minimumPrice;
                            int maximumPrice;
                            ConsoleView.GetPriceQueryMinMaxValues(out minimumPrice, out maximumPrice);

                            matchingPetsData = petDataRepository.QueryPetsDataInformation(minimumPrice, maximumPrice);

                            ConsoleView.DisplayQueryResults(matchingPetsData);
                            ConsoleView.DisplayContinuePrompt();
                            break;

                        case AppEnum.ManagerAction.Quit:
                            active = false;
                            break;

                        default:
                            break;
                    }
                }
            }

            ConsoleView.DisplayExitPrompt();
        }

        #endregion

    }
}
