using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class Car : Vehicle
    {
        eColor m_CarColor;
        int m_NumberOfDoors;
        internal const int k_NumberOfWheels = 4;
        internal const int k_MaxNumberOfDoors = 5;
        internal const int k_MinNumberOfDoors = 2;
        private const string k_ToStringDetails =
@"{0}Number of Doors: {1}
Number Of Wheels: {2}
Car's Color: {3}
";

        public Car(string i_BrandName, string i_RegistrationNumber, float i_AmountOfEnergyLeft, List<Wheel> i_Wheels, eColor i_CarColor, int i_NumberOfDoors)
            : base(i_BrandName, i_RegistrationNumber, i_Wheels)
        {
            if (i_Wheels[0].CurrentPressureInWheel > i_Wheels[0].MaxAirPressure)
            {
                throw new ValueOutOfRangeException(i_Wheels[0].MaxAirPressure, 0, "Pressure in wheels");
            }

            if (i_NumberOfDoors > k_MaxNumberOfDoors || i_NumberOfDoors < k_MinNumberOfDoors)
            {
                throw new ValueOutOfRangeException(k_MaxNumberOfDoors, k_MinNumberOfDoors, "number of doors");
            }
            else
            {
                m_NumberOfDoors = i_NumberOfDoors;
            }

            m_CarColor = i_CarColor;

        }

        public override string ToString()
        {
            return string.Format(k_ToStringDetails, base.ToString(), m_NumberOfDoors, k_NumberOfWheels, m_CarColor);
        }
    }
}
