using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class GarageLogic
    {
        private Dictionary<string, Customer> m_GarageLog = new Dictionary<string,Customer>();

        public Vehicle CreateMotorcycle(eEngineType i_EngineType, eLicenceType i_LicenceType, string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, int i_EngineVolume, string i_WheelManufactureName, float i_WheelCurrentPressure, eFuelType i_FuelType)
        {
            CreateVehicleForGarage newVehicle = new CreateVehicleForGarage();
            Vehicle motorcycle = newVehicle.CreateMotorcycle(i_EngineType, i_LicenceType, i_BrandName, i_RegistrationNumber, i_EnergyLeft, i_EngineVolume, i_WheelManufactureName, i_WheelCurrentPressure, i_FuelType);
            return motorcycle;
        }

        public Vehicle CreateCar(eEngineType i_EngineType, string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, eColor i_CarColor, int i_NumberOfDoors, string i_WheelManufactureName, float i_WheelCurrentPressure, eFuelType i_FuelType)
        {
            CreateVehicleForGarage newVehicle = new CreateVehicleForGarage();
            Vehicle car = newVehicle.CreateCar(i_EngineType, i_BrandName, i_RegistrationNumber, i_EnergyLeft, i_CarColor, i_NumberOfDoors, i_WheelManufactureName, i_WheelCurrentPressure, i_FuelType);
            return car;
        }

        public Vehicle CreateTruck(string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, bool i_IsCarryingDangerousMeterials, float i_CurrentCarryingWeight, string i_WheelManufactureName, float i_WheelCurrentPressure, eFuelType i_FuelType)
        {
            CreateVehicleForGarage newVehicle = new CreateVehicleForGarage();
            Vehicle truck = newVehicle.CreateTruck(i_BrandName, i_RegistrationNumber, i_EnergyLeft, i_IsCarryingDangerousMeterials, i_CurrentCarryingWeight, i_WheelManufactureName, i_WheelCurrentPressure, i_FuelType);
            return truck;
        }

        public string DisplayCustomerInformation(string i_RegistrationNumber)
        {
            string informationToDislpay = string.Empty;

            if (IsVehicleInGerage(i_RegistrationNumber))
            {
                Customer vehicleToAttend = m_GarageLog[i_RegistrationNumber];
                informationToDislpay = vehicleToAttend.ToString();
            }
            else
            {
                throw new FormatException("The vehicle is not in the Garage!");
            }

            return informationToDislpay;
        }
        
        public bool IsVehicleInGerage(string i_RegistrationNumber)
        {
            bool isVehicleInGarage = false;
            if (m_GarageLog.ContainsKey(i_RegistrationNumber))
            {
                isVehicleInGarage = true;
            }

            return isVehicleInGarage;
        }

        public void AddVehicleToGarage(string i_OwnerName, string i_OwnerPhone, string i_RegistrationNumber, Vehicle i_Vehicle)
        {
            if (IsVehicleInGerage(i_RegistrationNumber))
            {
                m_GarageLog[i_RegistrationNumber].ClientStatus = eClientStatus.InRepair;
            }
            else
            {
                m_GarageLog.Add(i_RegistrationNumber, new Customer(i_OwnerName, i_OwnerPhone, i_Vehicle));
            }
        }

        public List<string> ListOfAllLicenceNumbersInGarage(eClientStatus i_ClientStatus)
        {
            List<string> licenceNumbersToReturn = new List<string>();
            if(i_ClientStatus == eClientStatus.All)
            {
                foreach(KeyValuePair<string, Customer> client in m_GarageLog)
                {
                    licenceNumbersToReturn.Add(client.Key);
                }
            }
            else
            {
                foreach(KeyValuePair<string, Customer> client in m_GarageLog)
                {
                    if(client.Value.ClientStatus == i_ClientStatus)
                    {
                        licenceNumbersToReturn.Add(client.Key);
                    }
                }
            }

            return licenceNumbersToReturn;
        }

        public void ChangeStatusOfVehicle(eClientStatus i_ClientStatus, string i_RegistrationNumber)
        {
            Customer vehicleToChange;
            if(!IsVehicleInGerage(i_RegistrationNumber))
            {
                throw new FormatException("The vehicle is not in the Garage!");
            }
            else
            {
                vehicleToChange = m_GarageLog[i_RegistrationNumber];
                vehicleToChange.ClientStatus = i_ClientStatus;
            }
        }

        public void FillGas(string i_RegistrationNumber, float i_LitersToFill, eFuelType i_FuelType)
        {
            float hoursToFill = i_LitersToFill;
            Customer vehicleToAttend;
            if (IsVehicleInGerage(i_RegistrationNumber))
            {
                vehicleToAttend = m_GarageLog[i_RegistrationNumber];
                GasEngine engineAsGasEngine = vehicleToAttend.Vehicle.Engine as GasEngine;
                if (engineAsGasEngine != null)
                {
                    engineAsGasEngine.fillGas(hoursToFill, i_FuelType);
                }
                else
                {
                    throw new FormatException("You cannot fill gas in this kind of Vehicle!");
                }
            }
            else
            {
                throw new FormatException("The vehicle is not in the Garage!");
            }
        }

        public void ChargeBattery(string i_RegistrationNumber, float i_MinToFill)
        {
            float hoursToCharge = i_MinToFill / 60;
            Customer vehicleToAttend;
            if (IsVehicleInGerage(i_RegistrationNumber))
            {
                vehicleToAttend = m_GarageLog[i_RegistrationNumber];
                ElectricEngine engineAsElectricEngine = vehicleToAttend.Vehicle.Engine as ElectricEngine;
                if (engineAsElectricEngine != null)
                {
                    engineAsElectricEngine.ChargeBattery(hoursToCharge);
                }
                else
                {
                    throw new FormatException("You cannot fill gas in this kind of Vehicle!");
                }
            }
            else
            {
                throw new FormatException("The vehicle is not in the Garage!");
            }
        }

        public void FillAirInWheels(string i_RegistrationNumber)
        {
            float airToFill;
            Customer vehicleToAttend;
            if (!IsVehicleInGerage(i_RegistrationNumber))
            {
                throw new FormatException("The vehicle is not in the Garage!");
            }
            else
            {
                vehicleToAttend = m_GarageLog[i_RegistrationNumber];
                foreach (Wheel wheel in vehicleToAttend.Vehicle.Wheels)
                {
                    airToFill = wheel.MaxAirPressure - wheel.CurrentPressureInWheel;
                    wheel.fillAirInWheel(airToFill);
                }
            }
        }
    }
}
