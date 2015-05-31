using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GarageLogic
    {
        private Dictionary<string, Coustumer> m_GarageLog;

        public Coustumer CoustumersVehicle(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            return new Coustumer(i_OwnerName, i_OwnerPhone, i_Vehicle);
        }

        public Vehicle CreateMotorcycle(eVehicleOptions i_VehicleOption, eLicenceType i_LicenceType, string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, float i_MaxEnergy, int i_EngineVolume, string i_WheelManufactureName, float i_WheelCurrentPressure, float i_MaxPressureInWheels, eFuelType i_FuelType)
        {
            CreateVehicleForGarage newVehicle = new CreateVehicleForGarage();
            Vehicle motorcycle = newVehicle.CreateMotorcycle(i_VehicleOption, i_LicenceType, i_BrandName, i_RegistrationNumber, i_EnergyLeft, i_MaxEnergy, i_EngineVolume, i_WheelManufactureName, i_WheelCurrentPressure, i_MaxPressureInWheels, i_FuelType);
            return motorcycle;
        }

        public Vehicle CreateCar(eVehicleOptions i_VehicleOption, string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, float i_MaxEnergy, eColor i_CarColor, int i_NumberOfDoors, string i_WheelManufactureName, float i_WheelCurrentPressure, eFuelType i_FuelType)
        {
            CreateVehicleForGarage newVehicle = new CreateVehicleForGarage();
            Vehicle car = newVehicle.CreateCar(i_VehicleOption, i_BrandName, i_RegistrationNumber, i_EnergyLeft, i_MaxEnergy, i_CarColor, i_NumberOfDoors, i_WheelManufactureName, i_WheelCurrentPressure, i_FuelType);
            return car;
        }

        public Vehicle CreateTruck(string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, float i_MaxEnergy, bool i_IsCarryingDangerousMeterials, float i_CurrentCarryingWeight, string i_WheelManufactureName, float i_WheelCurrentPressure, eFuelType i_FuelType)
        {
            CreateVehicleForGarage newVehicle = new CreateVehicleForGarage();
            Vehicle truck = newVehicle.CreateTruck(i_BrandName, i_RegistrationNumber, i_EnergyLeft, i_MaxEnergy, i_IsCarryingDangerousMeterials, i_CurrentCarryingWeight, i_WheelManufactureName, i_WheelCurrentPressure, i_FuelType);
            return truck;
        }

        public string DisplayVehicleInformation(string i_RegistrationNumber)
        {
            string informationToDislpay = string.Empty;

            if (IsVehicleInGerage(i_RegistrationNumber))
            {
                Coustumer vehicleToAttend = m_GarageLog[i_RegistrationNumber];
                informationToDislpay = vehicleToAttend.Vehicle.ToString();
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

        public void AddVehicleToGarage(string i_RegiatrationNumber, Coustumer i_Vehicle)
        {
            if (IsVehicleInGerage(i_RegiatrationNumber))
            {
                i_Vehicle.ClientStatus = eClientStatus.InRepair;
            }
            else
            {
                m_GarageLog.Add(i_RegiatrationNumber, i_Vehicle);
            }
        }

        public List<string> ListOfAllLicenceNumbersInGarage(eClientStatus i_ClientStstus)
        {
            List<string> licenceNumbersToReturn = new List<string>();
            if(i_ClientStstus == eClientStatus.All)
            {
                foreach(KeyValuePair<string, Coustumer> client in m_GarageLog)
                {
                    licenceNumbersToReturn.Add(client.Key);
                }
            }
            else
            {
                foreach(KeyValuePair<string, Coustumer> client in m_GarageLog)
                {
                    if(client.Value.ClientStatus == i_ClientStstus)
                    {
                        licenceNumbersToReturn.Add(client.Key);
                    }
                }
            }

            return licenceNumbersToReturn;
        }

        public void ChangeStatusOfVehicle(eClientStatus i_ClientStatus, string i_RegistrationNumber)
        {
            Coustumer vehicleToChange;
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

        public void FillGas(string i_RegistrationNumber, float i_MinToFill, eFuelType i_FuelType)
        {
            float hoursToFill = i_MinToFill / 60;
            Coustumer vehicleToAttend;
            if (IsVehicleInGerage(i_RegistrationNumber))
            {
                vehicleToAttend = m_GarageLog[i_RegistrationNumber];
                if (vehicleToAttend.Vehicle.Engine is GasEngine)
                {
                    (vehicleToAttend.Vehicle.Engine as GasEngine).fillGas(hoursToFill, i_FuelType);
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
            Coustumer vehicleToAttend;
            if (IsVehicleInGerage(i_RegistrationNumber))
            {
                vehicleToAttend = m_GarageLog[i_RegistrationNumber];
                if (vehicleToAttend.Vehicle.Engine is ElectricEngine)
                {
                    (vehicleToAttend.Vehicle.Engine as ElectricEngine).ChargeBattery(hoursToCharge);
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
            Coustumer vehicleToAttend;
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
