using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        private const string k_ToStringDetails =
@"Wheel Manufacturer Name: {0}
Current Pressure in Wheel: {1}
Maximal Pressure in Wheel: {2}";

        public Wheel(string i_ManufactureName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
            
            if (i_MaxAirPressure < 0)
            {
                throw new ArgumentException("Pressure needs to be Positive.");
            }

            if ((i_CurrentAirPressure > i_MaxAirPressure) || (i_CurrentAirPressure < 0))
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure, 0, "Air Pressure");
            }

            
            m_ManufacturerName = i_ManufactureName;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }
        
        public void fillAirInWheel(float i_AirToAdd) {
            if((i_AirToAdd + m_CurrentAirPressure) > m_MaxAirPressure) {
                throw new ValueOutOfRangeException(m_MaxAirPressure, 0, "Amount of air added to the wheel");
            }

            m_CurrentAirPressure = i_AirToAdd + m_CurrentAirPressure;
        }

        public string ManufactureName
        {
            get
            {
                return m_ManufacturerName;
            }
         }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
    }

        public float CurrentPressureInWheel
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public override string ToString()
        {
            return string.Format(k_ToStringDetails, m_ManufacturerName, m_CurrentAirPressure, m_MaxAirPressure);
        }
    }
}
