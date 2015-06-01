using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    

    public class CreateVehicleForGarage
    {

        private const float k_GasMotorCycleEngineVolume = 8f;
        private const float k_ElectricMotorCycleMaxChargeTime = 1.2f;
        private const float k_GasCarEngineVolume = 35f;
        private const float k_ElectricCarMaxChargeTime = 2.2f;
        private const float k_GasTruckEngineVolume = 170f;

        private const float k_GasMotorCycleWheelPressure = 34f;
        private const float k_ElectricMotorCycleMaxWheelPressure = 31f;
        private const float k_GasCarWheelPressure = 31f;
        private const float k_ElectricCarWheelPressure = 31f;
        private const float k_GasTruckWheelPressure = 25f;

        public Vehicle CreateMotorcycle(eEngineType i_EngineType, eLicenceType i_LicenceType, string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, int i_EngineVolume, string i_WheelManufactureName, float i_WheelCurrentPressure, eFuelType i_FuelType)
        {
            Vehicle motorcycle;
            if (i_EngineType.Equals(eEngineType.Electric))
            {
                motorcycle = new MotorCycle(i_BrandName, i_RegistrationNumber, i_EnergyLeft, CreateListOfWheels(i_WheelManufactureName, MotorCycle.k_NumberOfWheels, i_WheelCurrentPressure, k_ElectricMotorCycleMaxWheelPressure));
                ((MotorCycle)motorcycle).LicenceType = i_LicenceType;
                ((MotorCycle)motorcycle).EngineVolume = i_EngineVolume;
                motorcycle.Engine = new ElectricEngine(i_EnergyLeft, k_ElectricMotorCycleMaxChargeTime);
            }
            else if (i_EngineType.Equals(eEngineType.Gas))
            {
                motorcycle = new MotorCycle(i_BrandName, i_RegistrationNumber, i_EnergyLeft, CreateListOfWheels(i_WheelManufactureName, MotorCycle.k_NumberOfWheels, i_WheelCurrentPressure, k_GasMotorCycleWheelPressure));
                ((MotorCycle)motorcycle).LicenceType = i_LicenceType;
                ((MotorCycle)motorcycle).EngineVolume = i_EngineVolume;
                motorcycle.Engine = new GasEngine(i_EnergyLeft, k_GasMotorCycleEngineVolume, i_FuelType);
            }
            else {
                throw new ArgumentException();
            }

            return motorcycle;
        }

        public Vehicle CreateCar(eEngineType i_EngineType, string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, eColor i_CarColor, int i_NumberOfDoors, string i_WheelManufactureName, float i_WheelCurrentPressure, eFuelType i_FuelType)
        {
            Vehicle car;
            if (i_EngineType.Equals(eEngineType.Electric))
            {
                car = new Car(i_BrandName, i_RegistrationNumber, i_EnergyLeft, CreateListOfWheels(i_WheelManufactureName, Car.k_NumberOfWheels, i_WheelCurrentPressure, k_ElectricCarWheelPressure));
                ((Car)car).CarColor = i_CarColor;
                ((Car)car).NumberOfDoors = i_NumberOfDoors;
                car.Engine = new ElectricEngine(i_EnergyLeft, k_ElectricCarMaxChargeTime);
            }
            else if (i_EngineType.Equals(eEngineType.Gas))
            {
                car = new Car(i_BrandName, i_RegistrationNumber, i_EnergyLeft, CreateListOfWheels(i_WheelManufactureName, Car.k_NumberOfWheels, i_WheelCurrentPressure, k_GasCarWheelPressure));
                ((Car)car).CarColor = i_CarColor;
                ((Car)car).NumberOfDoors = i_NumberOfDoors;
                car.Engine = new GasEngine(i_EnergyLeft, k_GasCarEngineVolume, i_FuelType);
            }
            else
            {
                throw new ArgumentException();
            }

            return car;
        }

        public Vehicle CreateTruck(string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, bool i_IsCarryingDangerousMeterials, float i_CurrentCarryingWeight, string i_WheelManufactureName, float i_WheelCurrentPressure, eFuelType i_FuelType)
        {
            Vehicle truck;

            truck = new Truck(i_BrandName, i_RegistrationNumber, i_EnergyLeft, CreateListOfWheels(i_WheelManufactureName, Truck.k_NumberOfWheels, i_WheelCurrentPressure, k_GasTruckWheelPressure));
            ((Truck)truck).IsCarringDangerousMeterials = i_IsCarryingDangerousMeterials;
            ((Truck)truck).CurrentCarringWeight = i_CurrentCarryingWeight;
            truck.Engine = new GasEngine(i_EnergyLeft, k_GasTruckEngineVolume, i_FuelType);

            return truck;
        }

        private List<Wheel> CreateListOfWheels(string i_ManufacorsName, int i_NumberOfWheels, float i_CurrentPressure, float i_MaxManufactorPressure) {
            List<Wheel> wheels = new List<Wheel>();
            try
            {
                for (int i = 0; i < i_NumberOfWheels; i++)
                {
                    wheels.Add(new Wheel(i_ManufacorsName, i_CurrentPressure, i_MaxManufactorPressure));
                }
            }
            catch (FormatException e)
            {
                throw e;
            }

            return wheels;
        }
    }
}
