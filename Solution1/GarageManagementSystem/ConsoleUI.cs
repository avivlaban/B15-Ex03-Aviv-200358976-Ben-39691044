using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManagementSystem.ConsoleUI
{


    public class ConsoleUI
    {

        private enum eMainMenuChoices
        {
            EnterNewVehicle = 1,
            ShowListOfRegistrationNumbers = 2,
            ChangeVehicleStatus = 3,
            FillAirInWheels = 4,
            FillGasInVehicle = 5,
            ChargeBatteryInVehicle = 6,
            ShowFullVehicleDetails = 7,
            ReturnToPreviousMenu = 8,
            ExitProgram = 0
        }


        private GarageLogic.GarageLogic m_GarageToManage;
        private readonly string r_LineSeperator = "******************************************************************************";
        private readonly string r_EnterChoice = "Please enter the option number you selected: ";
        private readonly string r_InvalidOption = "Invalid option.";
        private readonly string r_ReturnToPreviousMenu = "0. Return to previous menu";
        private readonly string r_ExitProgram = "0. Exit the program";
        private readonly string r_EnterCarRegistrationNumber = "Please enter the vehicle registration number: ";
        private readonly string r_MainMenu =
    @"
          Main Menu
{0}
1. Enter a new vehicle to the system
2. Show a list of all the cars' registration numbers
3. Change vehicle status
4. Fill the air in a vehicle's wheels
5. Fill gas in a vehicle
6. Charge the battery in a vehicle
7. Show full vehicle details by registration number
{1}
{0}
";

        private readonly string r_NewVehicleMenuHeader =
@"
          Enter new vehicle to the system
{0}
";

        private readonly string r_NewVehicleMenuSelectVehicleType =
@"
Please select vehicle type:
1. Motorcycle
2. Car
3. Truck
";

        private readonly string r_NewVehicleMenuSelectEngineType =
@"
Please select your engine type:
1. Gas
2. Electric
";
        private readonly string r_NewVehicleMenuEnterDetails =
@"
          Enter details for {1}, {2}, {3} engine
{0}
";
        private readonly string r_NewVehicleMenuEnterDetailsCarColor =
@"
          Enter details for {1}, {2}, {3} engine
{0}
Select the color of the car:
1. Green
2. Black
3. White
4. Red
";

        private readonly string r_NewVehicleMenuEnterDetailsTruck =
@"
          Enter details for {1}, {2}, {3} engine
{0}
Does the truck carry dangerous load?:
1. Yes
2. No
";
        private readonly string r_NewVehicleMenuEnterDetailsMotorcycle =
@"
          Enter details for {1}, {2}, {3} engine
{0}
Which license type is the motorcycle:
1. A
2. A2
3. AB
4. B1
";
        
        private readonly string r_NewVehicleMenuEnterDetailsGasEngineFuelType =
@"      Enter details for Gas engine
{0}
Select the fuel type of the engine:
1. Soler
2. Octan95
3. Octan96
4. Octan98
{0}
";
        private readonly string r_ShowListOfRegistrationNumbersMenu =
@"
          List registration numbers in the system
{0}
1. List all the vehicles in status 'In Repair' in the system
2. List all the vehicles in status 'Repaired' in the system
3. List all the vehicles in status 'Paid' in the system
4. List all the vehicles in the system
{1}
{0}
";

        private readonly string r_ChangeVehicleStatusMenuHeader =
@"
          Change existing vehicle status
{0}
";
        private readonly string r_ChangeVehicleStatusMenu =
@"
          Change existing vehicle status: {2}
{0}
1. Change vehicle status to: 'In-Repair'
2. Change vehicle status to: 'Repaired'
3. Change vehicle status to: 'Paid'
{1}
{0}
";
        private readonly string r_FillAirInTheWheelsHeader =
@"
          Fill the air in the wheels to max pressure
{0}
";

        private readonly string r_FillGasInVehicleHeader =
@"
          Fill the gas in the vehicle
{0}
";
        private readonly string r_FillGasInVehicleFuelTypes =
@"      Fill Gas in vehicle: {1}
{0}
1. Soler
2. Octan95
3. Octan96
4. Octan98
{0}
";
        private readonly string r_FillGasInVehicleAmountOfFuel =
@"
          Fill the gas in the vehicle {1}
{0}
Enter the amount of {2} to fill: ";

        private readonly string r_ChargeBatteryInVehicleHeader =
@"
          Charge the battery in the vehicle
{0}

";
        private readonly string r_ChargeBatteryInVehicleGetMinutes =
@"
          Charge the battery in the vehicle {1}
{0}
Enter the amount of minutes to charge: ";
        private readonly string r_ShowFullDetailsOnTheVehicleHeader =
@"
          Show full details of the vehicle {1}
{0}

";

        public void StartUI(GarageLogic.GarageLogic i_garageToManage)
        {
            bool exitProgramSelected = false;
            int userSelection = 0;
            m_GarageToManage = i_garageToManage;

            while (!exitProgramSelected)
            {
                displayMainMenu();
                userSelection = getLegalSelectionFromUser(0, 7);

                switch ((eMainMenuChoices)userSelection)
                {
                    case eMainMenuChoices.EnterNewVehicle:
                        displayEnterNewVehicleMenu();
                        break;
                    case eMainMenuChoices.ShowListOfRegistrationNumbers:
                        displayShowListOfRegistrationNumbersMenu();
                        break;
                    case eMainMenuChoices.ChangeVehicleStatus:
                        displayChangeVehicleStatusMenu();
                        break;
                    case eMainMenuChoices.FillAirInWheels:
                        displayFillAirInWheelsMenu();
                        break;
                    case eMainMenuChoices.FillGasInVehicle:
                        displayFillGasVehicleMenu();
                        break;
                    case eMainMenuChoices.ChargeBatteryInVehicle:
                        displayChargeElectricVehicleMenu();
                        break;
                    case eMainMenuChoices.ShowFullVehicleDetails:
                        displayShowFullVehicleDetailsMenu();
                        break;
                    case eMainMenuChoices.ExitProgram:
                        exitProgramSelected = true;
                        break;
                }
            }
        }

        private void displayMainMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine(string.Format(r_MainMenu, r_LineSeperator, r_ExitProgram));

        }

        private void displayEnterNewVehicleMenu()
        {
            string vehicleRegistrationEntered = string.Empty;
            System.Console.Clear();
            vehicleRegistrationEntered = getRegistrationNumberFromUser(r_NewVehicleMenuHeader);

            // Check if the car is already in the garage, if so update its status, if not request more details
            bool registrationAlreadyInTheGarage = m_GarageToManage.IsVehicleInGerage(vehicleRegistrationEntered);

            if (registrationAlreadyInTheGarage)
            {
                System.Console.WriteLine(string.Format("The car registration you've entered: {0}, is already registered in the system. Updating it's status to \"In Repair\"", vehicleRegistrationEntered));
                System.Console.WriteLine(m_GarageToManage.DisplayCustomerInformation(vehicleRegistrationEntered));
                pressEnterToContinue();
            }
            else
            {
                GarageLogic.eVehicleOptions vehicleTypeSelected = getVehicleTypeFromUser();
                GarageLogic.eEngineType engineTypeSelected = GarageLogic.eEngineType.Gas;
                if (vehicleTypeSelected != GarageLogic.eVehicleOptions.Truck)
                {
                    engineTypeSelected = getEngineTypeFromUser();
                }

                enterVehicleDetails(vehicleRegistrationEntered, vehicleTypeSelected, engineTypeSelected);


            }
        }

        private void enterVehicleDetails(string i_VehicleRegistration, GarageLogic.eVehicleOptions i_VehicleType, GarageLogic.eEngineType i_EngineType)
        {
            string ownerName = string.Empty;
            string brandName = string.Empty;
            string ownerPhoneNumber = string.Empty;
            string wheelsManufacturerName = string.Empty;
            float wheelsCurrentAirPressure = 0;

            System.Console.Clear();
            System.Console.WriteLine(string.Format(r_NewVehicleMenuEnterDetails, r_LineSeperator, i_VehicleRegistration, i_VehicleType, i_EngineType));
            System.Console.Write("Enter vehicle's brand name: ");
            brandName = System.Console.ReadLine();
            enterOwnerDetails(out ownerName, out ownerPhoneNumber);
            enterWheelsDetails(out wheelsManufacturerName, out wheelsCurrentAirPressure);
            if (i_VehicleType == GarageLogic.eVehicleOptions.Car)
            {
                enterCarDetails(i_VehicleRegistration, brandName, i_EngineType, ownerName, ownerPhoneNumber, wheelsManufacturerName, wheelsCurrentAirPressure);
            }
            else if (i_VehicleType == GarageLogic.eVehicleOptions.Motorcycle)
            {
                enterMotorCycleDetails(i_VehicleRegistration, brandName, i_EngineType, ownerName, ownerPhoneNumber, wheelsManufacturerName, wheelsCurrentAirPressure);
            }
            else
            {
                enterTruckDetails(i_VehicleRegistration, brandName, ownerName, ownerPhoneNumber, wheelsManufacturerName, wheelsCurrentAirPressure);
            }


        }

        private void enterTruckDetails(string i_VehicleRegistration, string i_BrandName, string i_OwnerName, string i_OwnerPhoneNumber, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            string weightOfCurrentLoadEntered = string.Empty;
            float weightOfCurrentLoad = 0;
            float currentFuelInVehicleInLiters = 0;
            bool isCurrentLoadDangerous = false;
            GarageLogic.eFuelType selectedFuelType = GarageLogic.eFuelType.Octan95;
            GarageLogic.Vehicle vehicleCreated = null;

            System.Console.Clear();
            System.Console.WriteLine(string.Format(r_NewVehicleMenuEnterDetailsTruck, r_LineSeperator, i_VehicleRegistration, "Truck", GarageLogic.eEngineType.Gas));
            isCurrentLoadDangerous = getLegalSelectionFromUser(1, 2) == 1;
            System.Console.Write("Please enter the weight of current load: ");
            weightOfCurrentLoadEntered = System.Console.ReadLine();
            while (!float.TryParse(weightOfCurrentLoadEntered, out weightOfCurrentLoad) || weightOfCurrentLoad < 0)
            {
                System.Console.Write("Please enter the weight of current load: ");
                weightOfCurrentLoadEntered = System.Console.ReadLine();
            }

            getGasEngineDetails(out selectedFuelType, out currentFuelInVehicleInLiters);
            try
            {
                vehicleCreated = m_GarageToManage.CreateTruck(i_BrandName, i_VehicleRegistration, currentFuelInVehicleInLiters, isCurrentLoadDangerous, weightOfCurrentLoad, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, selectedFuelType);
                m_GarageToManage.AddVehicleToGarage(i_OwnerName, i_OwnerPhoneNumber, i_VehicleRegistration, vehicleCreated);
                System.Console.WriteLine(string.Format("Successfuly added vehicle to the garage. Details:\n{0}", m_GarageToManage.DisplayCustomerInformation(i_VehicleRegistration)));
            }
            catch (Exception exception)
            {
                System.Console.WriteLine("An error has occurred: \n{0}", exception.Message);

            };
            
            
            pressEnterToContinue();
        }

        private void enterMotorCycleDetails(string i_VehicleRegistration, string i_BrandName, GarageLogic.eEngineType i_EngineType, string i_OwnerName, string i_OwnerPhoneNumber, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            GarageLogic.eLicenceType motorcycleLicense = GarageLogic.eLicenceType.A;
            string engineCCEntered = string.Empty;
            int engineCC = 0;
            GarageLogic.Vehicle vehicleCreated = null;

            System.Console.Clear();
            System.Console.WriteLine(string.Format(r_NewVehicleMenuEnterDetailsMotorcycle, r_LineSeperator, i_VehicleRegistration, "Motorcycle", i_EngineType));
            motorcycleLicense = (GarageLogic.eLicenceType)getLegalSelectionFromUser(1, 4);
            System.Console.Write("Please enter the CC of the engine: ");
            engineCCEntered = System.Console.ReadLine();
            while (!int.TryParse(engineCCEntered, out engineCC) || engineCC <= 0)
            {
                System.Console.Write("Please enter a valid number for the CC of the engine: : ");
                engineCCEntered = System.Console.ReadLine();
            }

            try
            {
                if (i_EngineType == GarageLogic.eEngineType.Gas)
                {
                    GarageLogic.eFuelType selectedFuelType = GarageLogic.eFuelType.Octan95;
                    float currentFuelInVehicleInLiters = 0;

                    getGasEngineDetails(out selectedFuelType, out currentFuelInVehicleInLiters);
                    vehicleCreated = m_GarageToManage.CreateMotorcycle(i_EngineType, motorcycleLicense, i_BrandName, i_VehicleRegistration, currentFuelInVehicleInLiters, engineCC, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, selectedFuelType);

                }
                else
                {
                    float currentChargeTimeInHours = 0;
                    getElectricEngineDetails(out currentChargeTimeInHours);
                    vehicleCreated = m_GarageToManage.CreateMotorcycle(i_EngineType, motorcycleLicense, i_BrandName, i_VehicleRegistration, currentChargeTimeInHours, engineCC, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, GarageLogic.eFuelType.None);
                }

                m_GarageToManage.AddVehicleToGarage(i_OwnerName, i_OwnerPhoneNumber, i_VehicleRegistration, vehicleCreated);
                System.Console.WriteLine(string.Format("Successfuly added vehicle to the garage. Details:\n{0}", m_GarageToManage.DisplayCustomerInformation(i_VehicleRegistration)));
            }
            catch (Exception exception)
            {
                System.Console.WriteLine("An error has occurred: \n{0}", exception.Message);
            };
            
            pressEnterToContinue();
        }

        private void enterCarDetails(string i_VehicleRegistration, string i_BrandName, GarageLogic.eEngineType i_EngineType, string i_OwnerName, string i_OwnerPhoneNumber, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            GarageLogic.eColor carColor = GarageLogic.eColor.Black;
            string numberOfDoorsEntered = string.Empty;
            int numberOfDoors = 0;
            GarageLogic.Vehicle vehicleCreated = null;

            System.Console.Clear();
            System.Console.WriteLine(string.Format(r_NewVehicleMenuEnterDetailsCarColor, r_LineSeperator, i_VehicleRegistration, "Car", i_EngineType));
            carColor = (GarageLogic.eColor)getLegalSelectionFromUser(1, 4);
            System.Console.Write("Please enter the number of doors in the car: ");
            numberOfDoorsEntered = System.Console.ReadLine();
            while (!int.TryParse(numberOfDoorsEntered, out numberOfDoors) || numberOfDoors <= 0)
            {
                System.Console.Write("Please enter a valid number of doors in the car: ");
                numberOfDoorsEntered = System.Console.ReadLine();
            }

            try
            {
                if (i_EngineType == GarageLogic.eEngineType.Gas)
                {
                    GarageLogic.eFuelType selectedFuelType = GarageLogic.eFuelType.Octan95;
                    float currentFuelInVehicleInLiters = 0;

                    getGasEngineDetails(out selectedFuelType, out currentFuelInVehicleInLiters);
                    vehicleCreated = m_GarageToManage.CreateCar(i_EngineType, i_BrandName, i_VehicleRegistration, currentFuelInVehicleInLiters, carColor, numberOfDoors, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, selectedFuelType);

                }
                else
                {
                    float currentChargeTimeInHours = 0;
                    getElectricEngineDetails(out currentChargeTimeInHours);
                    vehicleCreated = m_GarageToManage.CreateCar(i_EngineType, i_BrandName, i_VehicleRegistration, currentChargeTimeInHours, carColor, numberOfDoors, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, GarageLogic.eFuelType.None);
                }

                m_GarageToManage.AddVehicleToGarage(i_OwnerName, i_OwnerPhoneNumber, i_VehicleRegistration, vehicleCreated);
                System.Console.WriteLine(string.Format("Successfuly added vehicle to the garage. Details:\n{0}", m_GarageToManage.DisplayCustomerInformation(i_VehicleRegistration)));
            }
            catch (Exception exception)
            {
                System.Console.WriteLine("An error has occurred: \n{0}", exception.Message);
            };
            pressEnterToContinue();
        }

        private void getElectricEngineDetails(out float o_CurrentChargeTimeInHours)
        {
            string currentChargeTimeInHoursEntered = string.Empty;

            System.Console.Write("Please enter the amount of charge left in the vehicle (In hours): ");
            currentChargeTimeInHoursEntered = System.Console.ReadLine();
            while (!float.TryParse(currentChargeTimeInHoursEntered, out o_CurrentChargeTimeInHours) || o_CurrentChargeTimeInHours < 0)
            {
                System.Console.Write("Please enter the amount of charge left in the vehicle (In hours): ");
                currentChargeTimeInHoursEntered = System.Console.ReadLine();
            }
        }

        private void getGasEngineDetails(out GarageLogic.eFuelType o_SelectedFuelType, out float o_CurrentFuelInVehicleInLiters)
        {
            string currentFuelInVehicleEntered = string.Empty;

            System.Console.Clear();
            System.Console.Write(string.Format(r_NewVehicleMenuEnterDetailsGasEngineFuelType, r_LineSeperator));
            o_SelectedFuelType = (GarageLogic.eFuelType)getLegalSelectionFromUser(1, 4);
            System.Console.Write("Please enter the amount of fuel in liters currently in the vehicle: ");
            currentFuelInVehicleEntered = System.Console.ReadLine();
            while (!float.TryParse(currentFuelInVehicleEntered, out o_CurrentFuelInVehicleInLiters) || o_CurrentFuelInVehicleInLiters < 0)
            {
                System.Console.Write("Please enter the amount of fuel in liters currently in the vehicle: ");
                currentFuelInVehicleEntered = System.Console.ReadLine();
            }


        }

        private void enterWheelsDetails(out string o_ManufacturerName, out float o_CurrentAirPressure)
        {
            string airPressureEntered = string.Empty;

            System.Console.Write("Enter your wheels manufacturer name: ");
            o_ManufacturerName = System.Console.ReadLine();
            System.Console.Write("Enter your wheels current Air pressure: ");
            airPressureEntered = System.Console.ReadLine();
            while (!float.TryParse(airPressureEntered, out o_CurrentAirPressure) || o_CurrentAirPressure < 0)
            {
                System.Console.Write("Enter your wheels current Air pressure (please enter a valid number): ");
                airPressureEntered = System.Console.ReadLine();
            }
        }

        private void enterOwnerDetails(out string o_OwnerName, out string o_OwnerPhoneNumber)
        {
            System.Console.Write("Enter owner name: ");
            o_OwnerName = System.Console.ReadLine();
            System.Console.Write("Enter owner phone number: ");
            o_OwnerPhoneNumber = System.Console.ReadLine();
        }

        private GarageLogic.eEngineType getEngineTypeFromUser()
        {
            int userSelection = 0;

            System.Console.Write(r_NewVehicleMenuSelectEngineType);
            userSelection = getLegalSelectionFromUser(1, 2);

            return (GarageLogic.eEngineType)userSelection;
        }

        private GarageLogic.eVehicleOptions getVehicleTypeFromUser()
        {
            int userSelection = 0;

            System.Console.Write(r_NewVehicleMenuSelectVehicleType);
            userSelection = getLegalSelectionFromUser(1, 3);

            return (GarageLogic.eVehicleOptions)userSelection;
        }

        private void displayShowListOfRegistrationNumbersMenu()
        {
            int userSelection = -1;

            System.Console.Clear();
            System.Console.WriteLine(string.Format(r_ShowListOfRegistrationNumbersMenu, r_LineSeperator, r_ReturnToPreviousMenu, r_EnterChoice));
            userSelection = getLegalSelectionFromUser(0, 4);
            if (userSelection != 0)
            {
                int lineNumber = 1;
                GarageLogic.eClientStatus statusChosenByUser = (GarageLogic.eClientStatus)userSelection;
                List<string> registrationNumbersToDisplay = m_GarageToManage.ListOfAllLicenceNumbersInGarage(statusChosenByUser);


                foreach (string registratonNumber in registrationNumbersToDisplay)
                {
                    System.Console.WriteLine("{0}. Registration Number: {1}", lineNumber, registratonNumber);
                    lineNumber++;
                }

                pressEnterToContinue();

            }

        }

        private void displayChangeVehicleStatusMenu()
        {
            string vehicleRegistrationEntered = string.Empty;
            int userSelection = 0;

            System.Console.Clear();
            vehicleRegistrationEntered = getRegistrationNumberFromUser(r_ChangeVehicleStatusMenuHeader);

            // Check if the car is already in the garage, if so update its status, if not request more details
            bool registrationAlreadyInTheGarage = m_GarageToManage.IsVehicleInGerage(vehicleRegistrationEntered);

            if (registrationAlreadyInTheGarage)
            {
                System.Console.Clear();
                System.Console.WriteLine(string.Format(r_ChangeVehicleStatusMenu, r_LineSeperator, r_ReturnToPreviousMenu, vehicleRegistrationEntered));
                userSelection = getLegalSelectionFromUser(0, 3);
                if (userSelection != 0)
                {
                    GarageLogic.eClientStatus statusChosenByUser = (GarageLogic.eClientStatus)userSelection;
                    m_GarageToManage.ChangeStatusOfVehicle(statusChosenByUser, vehicleRegistrationEntered);
                }

            }
            else
            {
                vehicleNotFoundInTheSystem();
            }


        }

        private void displayFillAirInWheelsMenu()
        {
            string vehicleRegistrationEntered = string.Empty;

            System.Console.Clear();
            vehicleRegistrationEntered = getRegistrationNumberFromUser(r_FillAirInTheWheelsHeader);

            // Check if the car is already in the garage, if so update its status, if not request more details
            bool registrationInTheGarage = m_GarageToManage.IsVehicleInGerage(vehicleRegistrationEntered);

            if (registrationInTheGarage)
            {
                System.Console.WriteLine("Filling the wheels...");
                m_GarageToManage.FillAirInWheels(vehicleRegistrationEntered);
                System.Console.WriteLine("Succesfuly filled the air in the wheels.");
                pressEnterToContinue();

            }
            else
            {
                vehicleNotFoundInTheSystem();
            }

        }

        private void displayFillGasVehicleMenu()
        {
            string vehicleRegistrationEntered = string.Empty;

            System.Console.Clear();
            vehicleRegistrationEntered = getRegistrationNumberFromUser(r_FillGasInVehicleHeader);

            // Check if the car is already in the garage, if so update its status, if not request more details
            bool registrationInTheGarage = m_GarageToManage.IsVehicleInGerage(vehicleRegistrationEntered);

            if (registrationInTheGarage)
            {
                GarageLogic.eFuelType fuelTypeSelectedByUser;
                int amountOfFuelToFill = 0;

                fuelTypeSelectedByUser = getFuelTypeFromUser(vehicleRegistrationEntered);
                amountOfFuelToFill = getAmountOfFuelToFillFromUser(vehicleRegistrationEntered, fuelTypeSelectedByUser);
                System.Console.WriteLine("Filling gas...");
                try
                {
                    m_GarageToManage.FillGas(vehicleRegistrationEntered, amountOfFuelToFill, fuelTypeSelectedByUser);
                    System.Console.WriteLine("Filled gas succesfuly");
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine("An error has occurred: \n{0}", exception.Message);
                }
                
                pressEnterToContinue();
            }
            else
            {
                vehicleNotFoundInTheSystem();
            }
        }

        private int getAmountOfFuelToFillFromUser(string i_VehicleRegistration, GarageLogic.eFuelType i_fuelTypeToFill)
        {
            int amountEnteredByUser = 0;
            string userInput = string.Empty;

            System.Console.Clear();
            System.Console.WriteLine(string.Format(r_FillGasInVehicleAmountOfFuel, r_LineSeperator, i_VehicleRegistration, i_fuelTypeToFill));
            userInput = Console.ReadLine();
            while (!int.TryParse(userInput, out amountEnteredByUser) || amountEnteredByUser < 0)
            {
                System.Console.WriteLine("Please enter a valid amount: ");
                userInput = Console.ReadLine();
            }

            return amountEnteredByUser;
        }

        private GarageLogic.eFuelType getFuelTypeFromUser(string i_VehicleRegistration)
        {
            int userChoice = 0;

            Console.Clear();
            Console.WriteLine(string.Format(r_FillGasInVehicleFuelTypes, r_LineSeperator, i_VehicleRegistration));
            userChoice = getLegalSelectionFromUser(1, 4);

            return (GarageLogic.eFuelType)userChoice;
        }

        private void displayChargeElectricVehicleMenu()
        {
            string vehicleRegistrationEntered = string.Empty;

            System.Console.Clear();
            vehicleRegistrationEntered = getRegistrationNumberFromUser(r_ChargeBatteryInVehicleHeader);

            // TODO Check if the car is already in the garage, if so update its status, if not request more details
            bool registrationInTheGarage = m_GarageToManage.IsVehicleInGerage(vehicleRegistrationEntered);

            if (registrationInTheGarage)
            {

                float minutesToChargeIntoBattery = 0;
                minutesToChargeIntoBattery = getMinutesToChargeIntoBattery(vehicleRegistrationEntered);
                System.Console.WriteLine("Charging the vehicle.");
                try
                {
                    m_GarageToManage.ChargeBattery(vehicleRegistrationEntered, minutesToChargeIntoBattery);
                    System.Console.WriteLine("Charged Successful.");
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine("An error has occurred: \n{0}", exception.Message);
                }
                
            }
            else
            {
                vehicleNotFoundInTheSystem();
            }

            pressEnterToContinue();
        }

        private float getMinutesToChargeIntoBattery(string i_VehicleRegistration)
        {
            float amountEnteredByUser = 0;
            string userInput = string.Empty;

            System.Console.Clear();
            System.Console.WriteLine(string.Format(r_ChargeBatteryInVehicleGetMinutes, r_LineSeperator, i_VehicleRegistration));
            userInput = Console.ReadLine();
            while (!float.TryParse(userInput, out amountEnteredByUser) || amountEnteredByUser <= 0)
            {
                System.Console.WriteLine("Please enter a valid amount of minutes: ");
                userInput = Console.ReadLine();
            }

            return amountEnteredByUser;
        }

        private void displayShowFullVehicleDetailsMenu()
        {
            string vehicleRegistrationEntered = string.Empty;

            System.Console.Clear();
            vehicleRegistrationEntered = getRegistrationNumberFromUser(r_ShowFullDetailsOnTheVehicleHeader);

            // Check if the car is already in the garage, if so update its status, if not request more details
            bool registrationInTheGarage = m_GarageToManage.IsVehicleInGerage(vehicleRegistrationEntered);

            if (registrationInTheGarage)
            {
                System.Console.WriteLine(string.Format(r_ShowFullDetailsOnTheVehicleHeader, r_LineSeperator, vehicleRegistrationEntered));
                System.Console.WriteLine("Car Details");
                System.Console.WriteLine(m_GarageToManage.DisplayCustomerInformation(vehicleRegistrationEntered));

                pressEnterToContinue();
            }
            else
            {
                vehicleNotFoundInTheSystem();
            }
        }

        private int getLegalSelectionFromUser(int i_MinimumNumberChoice, int i_MaximumNumberChoice)
        {
            string userInput = string.Empty;
            int userSelection = -1;

            System.Console.Write(r_EnterChoice);
            userInput = System.Console.ReadLine();
            while (!int.TryParse(userInput, out userSelection) || userSelection < i_MinimumNumberChoice || userSelection > i_MaximumNumberChoice)
            {
                System.Console.Write(string.Format("{0} {1}", r_InvalidOption, r_EnterChoice));
                userInput = System.Console.ReadLine();
            }

            return userSelection;
        }

        private string getRegistrationNumberFromUser(string i_MenuHeader)
        {
            string vehicleRegistrationEntered = string.Empty;
            System.Console.WriteLine(string.Format(i_MenuHeader, r_LineSeperator, ""));
            System.Console.WriteLine(r_EnterCarRegistrationNumber);
            vehicleRegistrationEntered = System.Console.ReadLine();
            while (vehicleRegistrationEntered == string.Empty)
            {
                System.Console.Write("Please enter the registration number: ");
                vehicleRegistrationEntered = System.Console.ReadLine();
            }

            return vehicleRegistrationEntered;
        }

        private void vehicleNotFoundInTheSystem()
        {
            System.Console.WriteLine("The vehicle registration number is not in the system. Please add it as a new vehicle. (Press Enter to continue)");
            System.Console.ReadLine();
        }

        private void pressEnterToContinue()
        {
            System.Console.WriteLine("\nPress Enter to continue...");
            System.Console.ReadLine();
        }

    }
}
