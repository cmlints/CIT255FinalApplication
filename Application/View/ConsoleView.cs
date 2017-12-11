using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGroomingShop
{
    public static class ConsoleView
    {
        #region ENUMERABLES

        #endregion 

        #region FIELDS
        //window size
        private const int WINDOW_WIDTH = ViewSettings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = ViewSettings.WINDOW_HEIGHT;

        //horizontal and vertical margins in console window for display
        private const int DISPLAY_HORIZONTAL_MARGIN = ViewSettings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPLAY_VERTICAL_MARGIN = ViewSettings.DISPLAY_VERITCAL_MARGIN;
        private static IEnumerable<PetData> petsData;
        private static IEnumerable<PetData> matchingPetsData;

        public static IEnumerable<PetData> PetsData { get => petsData; set => petsData = value; }
        public static IEnumerable<PetData> PetsData1 { get => petsData; set => petsData = value; }
        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS
        ///<summary>method to display the manager menu and get the users choice</summary> 
        public static AppEnum.ManagerAction GetUserActionChoice()
        {
            AppEnum.ManagerAction userActionChoice = AppEnum.ManagerAction.None;
            //set a string variable with a length equal to the horizontal margin and filled with spaces
            string leftTab = ConsoleUtil.FillStringWithSpaces(DISPLAY_HORIZONTAL_MARGIN);

            //set up display area
            DisplayReset();

            //display menu
            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Pet Shop Grooming Menu", WINDOW_WIDTH));
            DisplayMessage("");

            Console.WriteLine(
                leftTab + "1. ListAllPetsData" + Environment.NewLine +
                leftTab + "2. DisplayPetDataDetail" + Environment.NewLine +
                leftTab + "3. AddPetData" + Environment.NewLine +
                leftTab + "4. DeletePetData" + Environment.NewLine +
                leftTab + "5. UpdatePetData" + Environment.NewLine +
                leftTab + "6. QueryPriceRange" + Environment.NewLine +
                leftTab + "E. Quit" + Environment.NewLine);

            DisplayMessage("");
            DisplayPromptMessage("Enter the number/letter to for your menu choice: ");
            ConsoleKeyInfo userResponse = Console.ReadKey(true);

            switch (userResponse.KeyChar)
            {
                case '1':
                    userActionChoice = AppEnum.ManagerAction.ListAllPetsData;
                    break;
                case '2':
                    userActionChoice = AppEnum.ManagerAction.DisplayPetsData;
                    break;
                case '3':
                    userActionChoice = AppEnum.ManagerAction.AddPetData;
                    break;
                case '4':
                    userActionChoice = AppEnum.ManagerAction.DeletePetData;
                    break;
                case '5':
                    userActionChoice = AppEnum.ManagerAction.UpdatePetData;
                    break;
                case '6':
                    userActionChoice = AppEnum.ManagerAction.QueryPriceRange;
                    break;
                case 'E':
                case 'e':
                    userActionChoice = AppEnum.ManagerAction.Quit;
                    break;
                default:
                    DisplayMessage("");
                    DisplayMessage("");
                    DisplayMessage("You selected an incorrect choice. Please try again.");
                    DisplayMessage("");
                    DisplayMessage("Press any key to try again or the ESC to quit.");

                    userResponse = Console.ReadKey(true);
                    if (userResponse.Key == ConsoleKey.Escape)
                    {
                        userActionChoice = AppEnum.ManagerAction.Quit;
                    }
                    break;
            }

            return userActionChoice;
        }

        public static void DisplayAllPetsData(List<PetData> petsData)
        {
            DisplayReset();
            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Display All Pets Data", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage("All of the existing pets data are displayed below: ");
            DisplayMessage("");

            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("ID".PadRight(8));

            columnHeader.Append("Pet Name".PadRight(25));

            columnHeader.Append("Pet Owner Name".PadRight(8));

            columnHeader.Append("Pet Breed".PadRight(25));

            columnHeader.Append("Pet Type".PadRight(8));

            columnHeader.Append("Pet Size".PadRight(25));

            columnHeader.Append("Phone Number".PadRight(8));

            columnHeader.Append("Groomer ID".PadRight(25));

            columnHeader.Append("Grooming Type".PadRight(8));

            columnHeader.Append("Price".PadRight(25));

            DisplayMessage(columnHeader.ToString());

            foreach (PetData petData in petsData)
            {
                StringBuilder petDataInfo = new StringBuilder();

                petDataInfo.Append(petData.ID.ToString().PadRight(8));

                petDataInfo.Append(petData.PetName.ToString().PadRight(25));

                petDataInfo.Append(petData.PetOwnerName.ToString().PadRight(8));

                petDataInfo.Append(petData.PetBreed.ToString().PadRight(25));

                petDataInfo.Append(petData.PetType.ToString().PadRight(8));

                petDataInfo.Append(petData.PetSize.ToString().PadRight(25));

                petDataInfo.Append(petData.PhoneNumber.ToString().PadRight(8));

                petDataInfo.Append(petData.GroomerID.ToString().PadRight(25));

                petDataInfo.Append(petData.GroomingType.ToString().PadRight(8));

                petDataInfo.Append(petData.Price.ToString().PadRight(25));

                DisplayMessage(petDataInfo.ToString());
            }

            return;

        }

        ///<summary>method to display all pets information</summary>
        public static void DisplayPetDataDetail(List<PetData> petsData)
        {
            DisplayReset();
            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Display All Pets Data", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage("All of the existing pet data are displayed below: ");
            DisplayMessage("");

            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("ID".PadRight(8));

            columnHeader.Append("Pet Data".PadRight(25));

            DisplayMessage(columnHeader.ToString());

            foreach (PetData petData in petsData)
            {
                StringBuilder petDataInfo = new StringBuilder();

                petDataInfo.Append(petData.ID.ToString().PadRight(8));

                petDataInfo.Append(petData.PetName.ToString().PadRight(25));

                DisplayMessage(petDataInfo.ToString());
            }

            return;

        }

        ///<summary>method to get the users choice of pet data ID</summary>
        public static int GetPetDataID(List<PetData> petsData)
        {
            int petDataID = -1;
            DisplayAllPetsData(petsData);

            DisplayMessage("");
            DisplayPromptMessage("Enter the pet data ID: ");

            petDataID = ConsoleUtil.ValidateIntegerResponse("Please enter the pet data ID: ", Console.ReadLine());

            return petDataID;
        }

        ///<summary>method to display a pet data info</summary>
        public static void DisplayPetData(PetData petData)
        {
            DisplayReset();
            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Pet Data Detail: ", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("Pet Data: {0}", petData.PetName));
            DisplayMessage("");

            DisplayMessage(String.Format("ID: {0}", petData.ID.ToString()));

            DisplayMessage(String.Format("Pet Owners Name: {0}", petData.PetOwnerName.ToString()));

            DisplayMessage(String.Format("Pet Breed: {0}", petData.PetName.ToString()));

            DisplayMessage(String.Format("Pet Type: {0}", petData.PetType.ToString()));

            DisplayMessage(String.Format("Pet Size: {0}", petData.PetSize.ToString()));

            DisplayMessage(String.Format("Pet Breed: {0}", petData.PetBreed.ToString()));

            DisplayMessage(String.Format("Pet Groomer ID: {0}", petData.GroomerID.ToString()));

            DisplayMessage(String.Format("Pet Grooming Type: {0}", petData.GroomingType.ToString()));

            DisplayMessage(String.Format("Pet Breed: {0}", petData.PhoneNumber.ToString()));

            ///DisplayMessage(String.Format("Pet Breed: {0}", petData.Price.ToString()));

            DisplayMessage("");
        }

        ///<summary>method to add pet data</summary>
        public static PetData AddPetData()
        {
            PetData petData = new PetData();
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Add Pet Data: ", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet ID: ");
            petData.ID = ConsoleUtil.ValidateIntegerResponse("Please enter the pet name: ", Console.ReadLine());
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Owner Name: ");
            petData.PetOwnerName = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Name: ");
            petData.PetName = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Type: ");
            petData.PetType = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Size: ");
            petData.PetSize = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Breed: ");
            petData.PetBreed = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Groomer ID: ");
            petData.GroomerID = ConsoleUtil.ValidateIntegerResponse("Please enter the pet groomer ID: ", Console.ReadLine());
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Grooming Type: ");
            petData.GroomingType = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Owner Phone Number: ");
            petData.PhoneNumber = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the pet Price: ");
            petData.Price = ConsoleUtil.ValidateIntegerResponse("Please enter the price for grooming: ", Console.ReadLine());
            DisplayMessage("");

            return petData;
        }

        ///<summary>method to Update a pets data into</summary>
        public static PetData UpdatePetData(PetData petData)
        {
            string userResponse = "";

            DisplayReset();
            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Edit A Pet Data: ", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("Current Groomer ID: {0}", petData.GroomerID));
            DisplayPromptMessage("Enter a Groomer ID or just press ENTER to keep the current grooming id: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                petData.GroomerID = ConsoleUtil.ValidateIntegerResponse("Please enter the Grooming ID: ", userResponse);
            }

            DisplayMessage("");
            DisplayMessage(String.Format("Current Grooming Type: {0}", petData.GroomingType));
            DisplayPromptMessage("Enter the new grooming type or press ENTER to keep the current grooming type: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                petData.GroomingType = userResponse;
            }

            DisplayMessage("");

            DisplayMessage("");
            DisplayMessage(String.Format("Current Grooming Price: {0}", petData.Price));
            DisplayPromptMessage("Enter the new price or press ENTER to keep the current price: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                petData.Price = ConsoleUtil.ValidateIntegerResponse("Please enter the Price: ", userResponse);
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Current Phone Number: {0}", petData.PhoneNumber));
            DisplayPromptMessage("Enter a new phone number or press Enter to keep the current phone number: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                petData.PhoneNumber = userResponse;
            }

            DisplayContinuePrompt();

            return petData;
        }

        /// <summary>
        /// method gets the minimum and maximum values for the price query
        /// </summary>

        public static void GetPriceQueryMinMaxValues(out int minimumPrice, out int maximumPrice)
        {
            minimumPrice = 0;
            maximumPrice = 0;
            string userResponse = "";

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Query Pet Data by Price", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayPromptMessage("Enter the minimum price: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                minimumPrice = ConsoleUtil.ValidateIntegerResponse("Please enter the minimum Price: ", userResponse);
            }

            DisplayMessage("");

            DisplayPromptMessage("Enter the maximum price: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                maximumPrice = ConsoleUtil.ValidateIntegerResponse("Please enter the maximum price: ", userResponse);
            }

            DisplayMessage("");

            DisplayMessage(String.Format("You have entered {0} dollars as the minimum value and {1} dollars as the maximum value.", minimumPrice, maximumPrice));

            DisplayMessage("");

            DisplayContinuePrompt();
        }

        public static void DisplayQueryResults(List<PetData> petsData)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Display Minimum and Maximum Query Results", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage("All of the matching pet prices are displayed below;");
            DisplayMessage("");

            StringBuilder columnHeader = new StringBuilder();

            //columnHeader.Append("ID".PadRight(8));
            columnHeader.Append("Price".PadRight(25));

            DisplayMessage(columnHeader.ToString());

            foreach (PetData petData in petsData)
            {
                StringBuilder petDataInfo = new StringBuilder();

                //petDataInfo.Append(petData.ID.ToString().PadRight(8));
                petDataInfo.Append(petData.Price);

                DisplayMessage(petDataInfo.ToString());
            }
        }

        /// <summary>
        /// reset display to default size and colors including the header
        /// </summary>
        public static void DisplayReset()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Pet Grooming Shop", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// diplay the Continue prompt
        /// </summary>
        public static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            Console.WriteLine(ConsoleUtil.Center("Press any key to continue.", WINDOW_WIDTH));
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }


        /// <summary>
        /// display the Exit prompt
        /// </summary>
        public static void DisplayExitPrompt()
        {
            DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            DisplayMessage("Thank you for using the pet grooming shop application. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("Welcome to", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Pet Grooming Shop", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message in the message area
        /// </summary>
        public static void DisplayMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            // message is not an empty line, display text
            if (message != "")
            {
                //
                // create a list of strings to hold the wrapped text message
                //
                List<string> messageLines;

                //
                // call utility method to wrap text and loop through list of strings to display
                //
                messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
                foreach (var messageLine in messageLines)
                {
                    Console.WriteLine(messageLine);
                }
            }
            // display an empty line
            else
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// display a message in the message area without a new line for the prompt
        /// </summary>

        public static void DisplayPromptMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            //
            // create a list of strings to hold the wrapped text message
            //
            List<string> messageLines;

            //
            // call utility method to wrap text and loop through list of strings to display
            //
            messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);

            for (int lineNumber = 0; lineNumber < messageLines.Count() - 1; lineNumber++)
            {
                Console.WriteLine(messageLines[lineNumber]);
            }

            Console.Write(messageLines[messageLines.Count() - 1]);
        }


        #endregion 
    }
}
