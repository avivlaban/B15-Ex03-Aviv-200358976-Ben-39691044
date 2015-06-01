using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class Truck : Vehicle
    {
        internal const int k_NumberOfWheels = 16;
        private const string k_ToStringDetails =
@"{0}Number Of Wheels: {1}
Is carrying Dangerous Meterials?: {2}
Current Weight Carrying: {3}
";

        private float m_CurrentCarryingWeight;
        private bool m_IsCarryingDangerousMeterials;

        public Truck(string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, List<Wheel> i_Wheels, float i_CurrentCarryWeight, bool i_IsCarryingDangerousMaterials)
            : base(i_BrandName, i_RegistrationNumber, i_Wheels)
        {
            if (i_Wheels[0].CurrentPressureInWheel > i_Wheels[0].MaxAirPressure)
            {
                throw new ValueOutOfRangeException(i_Wheels[0].MaxAirPressure, 0, "Pressure in Wheels");
            }

            if (i_CurrentCarryWeight < 0)
            {
                throw new ArgumentException("Current Carry Weight is illegal");
            }
            else
            {
                m_CurrentCarryingWeight = i_CurrentCarryWeight;
            }

            m_IsCarryingDangerousMeterials = i_IsCarryingDangerousMaterials;
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
            return string.Format(k_ToStringDetails, base.ToString(), k_NumberOfWheels, m_IsCarryingDangerousMeterials, m_CurrentCarryingWeight);
        }
    }
}
