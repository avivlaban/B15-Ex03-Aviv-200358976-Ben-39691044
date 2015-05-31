using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 16;
        private const float k_MaxPressure = 25;
        
        private float m_CurrentCarryingWeight;
        private bool m_IsCarryingDangerousMeterials;

        public Truck(string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, List<Wheel> i_Wheels)
            : base(i_BrandName, i_RegistrationNumber, i_EnergyLeft, i_Wheels)
        {
            if (i_Wheels[0].CurrentPressureInWheel > k_MaxPressure)
            {
                throw new ValueOutOfRangeException(k_MaxPressure, 0, "Pressure in Wheels");
            }
        }

        public float CurrentCarringWeight
        {
            get
            {
                return m_CurrentCarryingWeight;
            }
            set
            {
                m_CurrentCarryingWeight = value;
            }
        }

        public bool IsCarringDangerousMeterials
        {
            get
            {
                return m_IsCarryingDangerousMeterials;
            }
            set
            {
                m_IsCarryingDangerousMeterials = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Number Of Wheels: {1}, Is carrying Dangerous Meterials?: {2}, Maximal Pressure in Wheels: {3}, Current Weight Carrying: {4}", base.ToString(), k_NumberOfWheels, m_IsCarryingDangerousMeterials, k_MaxPressure, m_CurrentCarryingWeight);
        }
    }
}
