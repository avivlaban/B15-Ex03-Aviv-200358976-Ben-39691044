using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Car : Vehicle
    {
        eColor m_CarColor;
        int m_NumberOfDoors;
        internal const int k_NumberOfWheels = 4;
        internal const float k_MaxPressureInWheels = 31;

        public Car(string i_BrandName, string i_RegistrationNumber, float i_AmountOfEnergyLeft, List<Wheel> i_Wheels)
            : base(i_BrandName, i_RegistrationNumber, i_AmountOfEnergyLeft, i_Wheels)
        {
            if (i_Wheels[0].CurrentPressureInWheel > k_MaxPressureInWheels)
            {
                throw new ValueOutOfRangeException(k_MaxPressureInWheels, 0, "Pressure in wheels");
            }
        }

        public int NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public eColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = (eColor)value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Number of Doors: {1), Number Of Wheels: {2}, Maximal Air Pressure in the Wheels: {3}, Car's Color: {4}\n", m_NumberOfDoors, k_NumberOfWheels, k_MaxPressureInWheels, m_CarColor);
        }
    }
}
